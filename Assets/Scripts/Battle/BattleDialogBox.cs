using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond; //Vitesse d'apparition des lettres en seconde
    [SerializeField] Color highlightedColor; //Couleur pour savoir sur quelle action/attaque nous sommes

    [SerializeField] Text dialogText; //Fait reference au text d'intro au combat
    [SerializeField] GameObject actionSelector; //Fait reference au selecteur d'action
    [SerializeField] GameObject moveSelector; //Fait reference au selecteur d'attaque
    [SerializeField] GameObject moveDetails; //Fait reference aux infos des attaques

    [SerializeField] List<Text> actionTexts; //Liste de toute les action réalisable en combat
    [SerializeField] List<Text> moveTexts; //Liste de toute les attaques apprise par le pokemon

    [SerializeField] Text ppText; //Fait reference au text du nombre de pp de l'attaque
    [SerializeField] Text typeText; //Fait reference au text du type de l'attaque


    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //Fait une "animation" pour l'affichage du text
    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1F/lettersPerSecond);
        }

        yield return new WaitForSeconds(1f);
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for (int i = 0; i < actionTexts.Count; i++)
        {
            if (i == selectedAction)
                actionTexts[i].color = highlightedColor;
            else
                actionTexts[i].color = Color.black;
        }
    }

    public void UpdateMoveSelection(int selectedMove, Move move)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (i == selectedMove)
                moveTexts[i].color = highlightedColor;
            else
                moveTexts[i].color = Color.black;
        }

        ppText.text = $"PP {move.PP}/{move.Base.PP}";
        typeText.text = move.Base.Type.ToString();

        if (move.PP == 0)
        {
            ppText.color = Color.red;
        }
        else
        {
            ppText.color = Color.black;
        }
    }

    public void SetMoveNames(List<Move> moves)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (i < moves.Count)
                moveTexts[i].text = moves[i].Base.Name;
            else
                moveTexts[i].text = "-";
        }
    }
}
