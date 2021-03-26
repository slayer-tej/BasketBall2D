
using UnityEngine;
using UnityEngine.UI;


public class SetScore : MonoBehaviour
{
    [SerializeField]
    private Text entryScoreText;

    public void SetBoard(ScoreBoardEntryData scoreBoardEntryData)
    {
        entryScoreText.text = scoreBoardEntryData.entryScore.ToString();
    }

}
