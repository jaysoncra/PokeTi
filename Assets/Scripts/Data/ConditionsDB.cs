using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionsDB
{
    public static void Init()
    {
        foreach(var kvp in Conditions)
        {
            var conditionId = kvp.Key;
            var condition = kvp.Value;

            condition.Id = conditionId;
        }
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
        },
        {
            ConditionID.gel,
            new Condition()
            {
                Name = "Gel",
                StartMessage = "est gelé !",
                OnBeforeMove = (Pokemon pokemon) =>
                {
                    if(Random.Range(1, 5) == 1)
                    {
                        pokemon.CureStatus();
                        pokemon.StatusChanges.Enqueue($"{pokemon.Base.Name} n'est plus gelé !");
                        return true;
                    }
                    return false;
                }
            }
        },
        {
            ConditionID.som,
            new Condition()
            {
                Name = "Sommeil",
                StartMessage = "est endormi !",
                OnStart = (Pokemon pokemon) =>
                {
                    pokemon.StatusTime = Random.Range(1, 4);
                    Debug.Log($"Will be asleep for {pokemon.StatusTime} move");
                },
                OnBeforeMove = (Pokemon pokemon) =>
                {
                    if (pokemon.StatusTime <= 0)
                    {
                        pokemon.CureStatus();
                        pokemon.StatusChanges.Enqueue($"{pokemon.Base.Name} s'est réveillé !");
                        return true;

                    }

                    pokemon.StatusTime--;
                    pokemon.StatusChanges.Enqueue($"{pokemon.Base.Name} dort profondément !");
                    return false;
                }
            }
        }
    };
}

public enum ConditionID
{
    none, psn, bru, som, par, gel
}