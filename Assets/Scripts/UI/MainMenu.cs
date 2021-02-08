using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Text levelMax;
    [SerializeField] Text scoreMax;
    [SerializeField] Text apples;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settings;
    void Start()
    {
        SetLevel(SaveManager.Load("PLAYER_STAGE"));
        SetScore(SaveManager.Load("PLAYER_SCORE"));
        SetApples(SaveManager.Load("APPLE_QUANTITY"));
    }

    public void SetLevel(int level)
    {
        levelMax.text = "Stage " + level.ToString();
    }
    public void SetScore(int score)
    {
        scoreMax.text = "Score " + score.ToString();
    }
    public void SetApples(int appleScore)
    {
        apples.text = appleScore.ToString();
    }
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void CloseSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }
}
