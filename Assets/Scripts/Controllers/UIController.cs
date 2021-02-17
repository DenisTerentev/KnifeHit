using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gameController;
    [SerializeField] KnifeThrower thrower;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject resultMenu;
    [SerializeField] GameObject baner;
    
    public static bool canThrow=true;

    void Awake()
    {
        Messenger.AddListener(GameEvent.Knife_Dont_Match, Loose);
        Messenger<int>.AddListener(GameEvent.Level, SetLevel);
        Messenger<int>.AddListener(GameEvent.Change_Score, SetScore);
        Messenger<int>.AddListener(GameEvent.Apple_Score, SetAppleScore);
        Messenger.AddListener(GameEvent.Restart, OpenGame);
    }
    public void Throw()
    {
        if(canThrow)
        {
            thrower.Throw();
        }

    }
    public void Restart()
    {
        gameController.GetComponent<GameController>().LevelRestart();
        resultMenu.GetComponent<Animator>().SetTrigger("Restart");
    }

    void OpenResult()
    {
        gameMenu.SetActive(false);
        mainMenu.SetActive(false);
        resultMenu.SetActive(true);
        resultMenu.GetComponent<ResultMenu>().SetLevel(gameController.GetComponent<GameController>().GetLevel());
        resultMenu.GetComponent<ResultMenu>().SetScore(gameController.GetComponent<GameController>().GetScore());
    }
    public void OpenGame()
    {
        StartCoroutine(WaitForOpenGame());
        baner.GetComponent<Animator>().SetTrigger("BanerOut");
    }
    IEnumerator WaitForOpenGame()
    {
        yield return new WaitForSeconds(1);
        mainMenu.SetActive(false);
        resultMenu.SetActive(false);
        gameMenu.SetActive(true);
        canThrow = true;
    }

    void SetLevel(int level)
    {
        
        gameMenu.GetComponent<GameMenu>().SetLevel(level);
        gameMenu.GetComponent<GameMenu>().SetApple(gameController.GetComponent<GameController>().GetAppleScore());
        
    }
    void SetScore(int score)
    {
        gameMenu.GetComponent<GameMenu>().SetScore(score);
    }
    void SetAppleScore(int appleScore)
    {
        gameMenu.GetComponent<GameMenu>().SetApple(appleScore);
    }



    void Loose()
    {
        SaveManager.Save("PLAYER_SCORE", gameController.GetComponent<GameController>().GetScore());
        SaveManager.Save("PLAYER_STAGE", gameController.GetComponent<GameController>().GetLevel());
        SaveManager.Save("APPLE_QUANTITY", gameController.GetComponent<GameController>().GetAppleScore());
        OpenResult();
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.Knife_Dont_Match, OpenResult);
        Messenger<int>.RemoveListener(GameEvent.Level, SetLevel);
        Messenger<int>.RemoveListener(GameEvent.Change_Score, SetScore);
        Messenger<int>.RemoveListener(GameEvent.Apple_Score, SetAppleScore);
        Messenger.RemoveListener(GameEvent.Restart, OpenGame);
    }
}
