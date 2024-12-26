using TMPro;
using UnityEngine;


public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text textBoard;

    int score = 0;

    public void increaseScore(int amount)
    { 
        score += amount;
        textBoard.text = $"SCORE: {score.ToString()}";
    }
}
