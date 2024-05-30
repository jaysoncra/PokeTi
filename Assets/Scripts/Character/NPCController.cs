using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void Interact()
    {
        //StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        StartCoroutine(character.Move(new Vector2(0, 2)));
    }
}
