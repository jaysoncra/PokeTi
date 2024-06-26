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
    [SerializeField] bool alwaysHits; //Si l'attaque touche toujours l'enemi
    [SerializeField] int pp; //Nombre de fois que l'attaque peut �tre utilis�e
    [SerializeField] int priority; //Attaque de priorit� ou non
    [SerializeField] MoveCategory category; //Categorie de l'attaque
    [SerializeField] MoveEffects effects; //Effet de l'attaque
    [SerializeField] List<SecondaryEffects> secondaries; //Effet secaondaire de l'attaque
    [SerializeField] MoveTarget target; //Cible de l'attaque

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

    public bool AlwaysHits
    {
        get { return alwaysHits; }
    }

    public int PP
    {
        get { return pp; }
    }

    public int Priority
    {
        get { return priority; }
    }
    public MoveCategory Category
    {
        get { return category; }
    }

    public MoveEffects Effects
    {
        get { return effects; }
    }

    public List<SecondaryEffects> Secondaries
    {
        get { return secondaries; }
    }

    public MoveTarget Target
    {
        get { return target; }
    }
}

[System.Serializable]
public class MoveEffects
{
    [SerializeField] List<StatBoost> boosts;
    [SerializeField] ConditionID status;
    [SerializeField] ConditionID volatileStatus;
    public List<StatBoost> Boosts
    {
        get { return boosts; }
    }

    public ConditionID Status
    {
        get { return status; }
    }

    public ConditionID VolatileStatus
    {
        get { return volatileStatus; }
    }
}

[System.Serializable]
public class SecondaryEffects : MoveEffects
{
    [SerializeField] int chance;
    [SerializeField] MoveTarget target;

    public int Chance
    {
        get { return chance; }
    }

    public MoveTarget Target
    {
        get { return target; }
    }
}

[System.Serializable]
public class StatBoost
{
    public Stat stat;
    public int boost;
}

public enum MoveCategory
{
    Physical, Special, Status
}

public enum MoveTarget
{
    Foe, Self
}