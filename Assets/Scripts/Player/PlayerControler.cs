using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed; //Variable pour la vitesse de déplacement
    public LayerMask solidObjectsLayer; //Variable qui represente le layer des objet solides
    public LayerMask grassLayer; //Variable qui represente le layer des hautes herbes

    public event Action OnEncountered; //Rencontre avec un pokemon

    private bool isMoving; //Variable qui regarde si le joueur bouge
    private Vector2 input; //Variable qui regarde l'entrée du joueur
    private Animator animator; //Variable pour les animation de déplacement

    private void Awake()
    {
        animator = GetComponent<Animator> ();
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0) input.y = 0; //Permet de retirer le déplacemnt en diagonale

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    //Cette fonction permet de regarder si le joueur ce deplace d'au moins une case
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;

        CheckForeEncounters();
    }

    //Cette fonction permet de regarder si un objet bloque la route du joueur
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }

    //Cette fonction permet de savoir si un pokemon va sortir des hautes herbes ou non
    private void CheckForeEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if(UnityEngine.Random.Range(1, 101) <= 10)
            {
                animator.SetBool("isMoving", false);
                OnEncountered();
            }
        }
    }
}
