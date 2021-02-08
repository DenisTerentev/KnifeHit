using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] Text stageText;
    [SerializeField] Text scoreText;

    public void SetLevel(int level)
    {
        stageText.text = "Stage " + (level + 1);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
