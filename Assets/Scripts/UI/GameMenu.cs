using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Text stageText;
    [SerializeField] Text scoreText;
    [SerializeField] Text appleScoreText;

    public void SetLevel(int level)
    {
        stageText.text = "Stage " + (level + 1);
        stageText.transform.localScale = new Vector3(4.8f, 3.8f, 1.1f);
        if(this.isActiveAndEnabled) StartCoroutine(ChangeScale(stageText));
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
        scoreText.transform.localScale = new Vector3(4.8f, 3.8f, 1.1f);
        if (this.isActiveAndEnabled) StartCoroutine(ChangeScale(scoreText));
    }

    public void SetApple(int apple)
    {
        appleScoreText.text = apple.ToString();
        appleScoreText.transform.localScale = new Vector3(4.8f, 3.8f, 1.1f);
        if (this.isActiveAndEnabled) StartCoroutine(ChangeScale(appleScoreText));
    }
    IEnumerator ChangeScale(Text text)
    {
        yield return new WaitForSeconds(0.3f);
        text.transform.localScale = new Vector3(4,3,1);
    }
}
