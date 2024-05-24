using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsDB
{
    static void PoisonEffect(Pokemon pokemon)
    {

    }

    public static Dictionary<ConditionID, Condition> Conditions { get; set; } = new Dictionary<ConditionID, Condition>()
    {
        {
            ConditionID.psn,
            new Condition()
            {
                Name = "Poison",
                StartMessage = "est empoisonné !",
                OnAfterTurn = (Pokemon pokemon) =>
                {
                    pokemon.UpdateHP(pokemon.MaxHp / 8);
                    pokemon.StatusChanges.Enqueue($"{pokemon.Base.Name} souffre du poison !");
                }
            }
        },
        {
            ConditionID.bru,
            new Condition()
            {
                Name = "Brulure",
                StartMessage = "est brulé !",
                OnAfterTurn = (Pokemon pokemon) =>
                {
                    pokemon.UpdateHP(pokemon.MaxHp / 16);
                    pokemon.StatusChanges.Enqueue($"{pokemon.Base.Name} souffre de sa brûlure !");
                }
            }
        },
        {
            ConditionID.par,
            new Condition()
            {
                Name = "Paralysie",
                StartMessage = "est paralysé ! Il aura du mal à attaquer !",
                OnBeforeMove = (Pokemon pokemon) =>
                {
                    if(Random.Range(1, 5) == 1)
                    {
                        pokemon.StatusChanges.Enqueue($"{pokemon.Base.Name} est paralysé ! Il n'a pas pu attaquer !");
                        return false;
                    }
                    return true;
                }
            }
        }
    };
}

public enum ConditionID
{
    none, psn, bru, som, par, gel
}