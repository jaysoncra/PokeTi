using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Créer un nouveau pokemon")] //Permet de créer un menu dans unity pour créer les pokemons
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name; //Le nom du pokemon

    [TextArea]
    [SerializeField] string description; //La description du pokedex du pokemon

    [SerializeField] Sprite frontSprite; //Le sprite de face du pokemon
    [SerializeField] Sprite backSprite; //Le sprite de dos du pokemon

    [SerializeField] PokemonType type1; //Le premier type du pokemon
    [SerializeField] PokemonType type2; //Le deuxième type du pokemon

    //Stat de base des pokemons
    [SerializeField] int maxHp; //Les points de vie max
    [SerializeField] int attack; //L'attaque
    [SerializeField] int defense; //La défense
    [SerializeField] int spAttack; //L'attaque spéciale
    [SerializeField] int spDefense; //La defense spéciale
    [SerializeField] int speed; //La vitesse

    [SerializeField] List<LearnableMove> learnableMoves; //Permet de créer une liste des attaques que le pokemon peut apprendre

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public PokemonType Type1
    {
        get { return type1; }
    }

    public PokemonType Type2
    {
        get { return type2; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SpAttack
    {
        get { return spAttack; }
    }

    public int SpDefense
    {
        get { return spDefense; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

//Permet de savoir quelle attaque peut être apprise par un pokemon en fonction de son niveau
[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

//Les différents type de pokemon
public enum PokemonType
{
    None,
    Acier,
    Combat,
    Dragon,
    Eau,
    Électrik,
    Fée,
    Feu,
    Glace,
    Insecte,
    Normal,
    Plante,
    Poison,
    Psy,
    Roche,
    Sol,
    Spectre,
    Ténèbres,
    Vol
}

public enum Stat
{
    Attack,
    Defense,
    SpAttack,
    SpDefense,
    Speed
}

public class TypeChart
{
    static float[][] chart =
    {
        new float[] {0.5f, 1f, 1f, 0.5f, 0.5f, 2f, 0.5f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 1f}, //Acier
        new float[] {2f, 1f, 1f, 1f, 1f, 0.5f, 1f, 2f, 0.5f, 2f, 1f, 0.5f, 0.5f, 2f, 1f, 0f, 2f, 0.5f}, //Combat
        new float[] {0.5f, 1f, 2f, 1f, 1f, 0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f}, //Dragon
        new float[] {1f, 1f, 0.5f, 0.5f, 1f, 1f, 2f, 1f, 1f, 1f, 0.5f, 1f, 1f, 2f, 2f, 1f, 1f, 1f}, //Eau
        new float[] {1f, 1f, 0.5f, 2f, 0.5f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 0f, 1f, 1f, 2f}, //Electrik
        new float[] {0.5f, 2f, 2f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f, 2f, 1f}, //Fée
        new float[] {2f, 1f, 0.5f, 0.5f, 1f, 1f, 0.5f, 2f, 2f, 1f, 2f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f}, //Feu
        new float[] {0.5f, 1f, 2f, 0.5f, 1f, 1f, 0.5f, 0.5f, 1f, 1f, 2f, 1f, 1f, 1f, 2f, 1f, 1f, 2f}, //Glace
        new float[] {0.5f, 0.5f, 1f, 1f, 1f, 0.5f, 0.5f, 1f, 1f, 1f, 2f, 0.5f, 2f, 1f, 1f, 0.5f, 2f, 0.5f}, //Insecte
        new float[] {0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 0f, 1f, 1f}, //Normal
        new float[] {0.5f, 1f, 0.5f, 2f, 1f, 1f, 0.5f, 1f, 0.5f, 1f, 0.5f, 0.5f, 1f, 2f, 2f, 1f, 1f, 0.5f}, //Plante
        new float[] {0f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 1f, 2f, 0.5f, 1f, 0.5f, 0.5f, 0.5f, 1f, 1f}, //Poison
        new float[] {0.5f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 0.5f, 1f, 1f, 1f, 0f, 1f}, //Psy
        new float[] {0.5f, 0.5f, 1f, 1f, 1f, 1f, 2f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 2f}, //Roche
        new float[] {2f, 1f, 1f, 1f, 2f, 1f, 2f, 1f, 0.5f, 1f, 0.5f, 2f, 1f, 2f, 1f, 1f, 1f, 0f}, //Sol
        new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0f, 1f, 1f, 2f, 1f, 1f, 2f, 0.5f, 1f}, //Spectre
        new float[] {1f, 0.5f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 2f, 0.5f, 1f}, //Ténèbres
        new float[] {0.5f, 2f, 1f, 1f, 0.5f, 1f, 1f, 1f, 2f, 1f, 2f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f} //Vol
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if (attackType == PokemonType.None || defenseType == PokemonType.None)
            return 1;
        
        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}
