using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberUI : MonoBehaviour
{
    [SerializeField] Text nameText; //Remplace le texte par le nom du pokemon
    [SerializeField] Text levelText; //Remplace le texte par le niveau du pokemon
    [SerializeField] HPBar hpBar; //Fait le lien entre HPBar.cs et BattleHud.cs

    [SerializeField] Color highlightedColor;

    Pokemon _pokemon; //Represente le pokemon

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        nameText.text = pokemon.Base.Name;
        levelText.text = "Niv " + pokemon.Level;
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            nameText.color = highlightedColor;
        }
        else
        {
            nameText.color = Color.black;
        }
    }
}
