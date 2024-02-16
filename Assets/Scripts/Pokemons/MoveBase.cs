using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

[CreateAssetMenu(fileName = "Attaque", menuName = "Pokemon/Cr�er une nouvelle attaque")] //Permet de cr�er un menu dans unity pour cr�er les attaques
public class MoveBase : ScriptableObject
{
    [SerializeField] string name; //Nom de l'attaque

    [TextArea]
    [SerializeField] string description; //Description de l'attaque

    [SerializeField] PokemonType type; //Type de l'attaque
    [SerializeField] int power; //D�gat de l'attaque
    [SerializeField] int accuracy; //Pr�cision de l'attaque
    [SerializeField] int pp; //Nombre de fois que l'attaque peut �tre utilis�e
    [SerializeField] bool isSpecial; //Attaque special ou physique

    public string Name
    { 
        get { return name; } 
    }

    public string Description
    {
        get { return description; }
    }

    public PokemonType Type
    { 
        get { return type; }
    }

    public int Power
    {
        get { return power; }
    }

    public int Accuracy
    {
        get { return accuracy; }
    }

    public int PP
    {
        get { return pp; }
    }

    public bool IsSpecial
    {
        get { return isSpecial; }
    }
}
