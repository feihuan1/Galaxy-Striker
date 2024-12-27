using System;
using TMPro;
using UnityEngine;

public class DialogueLine : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;

     String[] timelineTextlines = {
        "We're glad to have you here lieutenant.  We could really use your help!",
        "Like shooting fish in a barrel!",
        "It's a trap!  Get out of there.",
        "Crikey!  Looks like you could use a hand.",
        "Never thought I'd see your face around here general...",
        "Righteo let's finish this once and for all.",
        "Struth!  Looks like the galaxy just got a little more safe.",
        "Yeeeehaw!!  You did it!",
    };

    
    int currentLine = 0;

    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = timelineTextlines[currentLine];
        Debug.Log(currentLine);
    }
}
