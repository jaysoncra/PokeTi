using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText; //Remplace le texte par le nom du pokemon
    [SerializeField] Text levelText; //Remplace le texte par le niveau du pokemon
    [SerializeField] Text statusText; //Remplace le texte par le status du pokemon (vide si pas de status)
    [SerializeField] HPBar hpBar; //Fait le lien entre HPBar.cs et BattleHud.cs

    [SerializeField] Color psnColor; //Couleur d'ecriture du statuts poison
    [SerializeField] Color bruColor; //Couleur d'ecriture du statuts brûlure
    [SerializeField] Color somColor; //Couleur d'ecriture du statuts sommeil
    [SerializeField] Color parColor; //Couleur d'ecriture du statuts paralysie
    [SerializeField] Color gelColor; //Couleur d'ecriture du statuts gel


    Pokemon _pokemon; //Represente le pokemon
    Dictionary<ConditionID, Color> statusColors;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        nameText.text = pokemon.Base.Name;
        levelText.text = "Niv " + pokemon.Level;
        hpBar.SetHP((float) pokemon.HP / pokemon.MaxHp);

        statusColors = new Dictionary<ConditionID, Color>()
        {
            {ConditionID.psn, psnColor},
            {ConditionID.bru, bruColor},
            {ConditionID.som, somColor},
            {ConditionID.par, parColor},
            {ConditionID.gel, gelColor},
        };

        SetStatusText();
        _pokemon.OnStatusChanged += SetStatusText;
    }

    void SetStatusText()
    {
        if (_pokemon.Status == null)
        {
            statusText.text = "";
        }
        else
        {
            statusText.text = _pokemon.Status.Id.ToString().ToUpper();
            statusText.color = statusColors[_pokemon.Status.Id];
        }
    }

    public IEnumerator UpdateHP()
    {
        if (_pokemon.HpChanged)
        {
            yield return hpBar.SetHPSmooth((float)_pokemon.HP / _pokemon.MaxHp);
            _pokemon.HpChanged = false;
        }
    }
}
