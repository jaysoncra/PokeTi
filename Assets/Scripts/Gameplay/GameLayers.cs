using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer; //Variable qui represente le layer des objet solides
    [SerializeField] LayerMask interactableLayer; //Variable qui represente le layer des objet interactif
    [SerializeField] LayerMask grassLayer; //Variable qui represente le layer des hautes herbes
    [SerializeField] LayerMask playerLayer; //Variable qui represente le layer du joueur
    [SerializeField] LayerMask fovLayer; //Variable qui represente le layer du joueur

    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask SolidLayer
    {
        get => solidObjectsLayer;
    }

    public LayerMask InteractableLayer
    {
        get => interactableLayer;
    }

    public LayerMask GrassLayer
    {
        get => grassLayer;
    }

    public LayerMask PlayerLayer
    {
        get => playerLayer;
    }

    public LayerMask FovLayer
    {
        get => fovLayer;
    }
}
