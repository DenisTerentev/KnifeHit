using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    int level=0;
    int applesScore;
    int score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.Knife_In_Apple, AddApplesScore);
        Messenger.AddListener(GameEvent.Knife_Hit, AddScore);
        Messenger.AddListener(GameEvent.Next_Level, LevelNext);
    }

    void Start()
    {
        applesScore = SaveManager.Load("APPLE_QUANTITY");
        SendLevel();
    }
    public int GetLevel()
    {
        return level;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetAppleScore()
    {
        return applesScore;
    }

    public void SendLevel()//добавить рассылку типа дерева
    {
        Messenger<int>.Broadcast(GameEvent.Type_Of_Wood, levelController.levels[level].tipeOfWood);
        Messenger<int>.Broadcast(GameEvent.Level, level);
        Messenger<int>.Broadcast(GameEvent.Knifes_Quantity, levelController.levels[level].knifes);
        Messenger<int>.Broadcast(GameEvent.Difficult, levelController.levels[level].difficult);
        score -= levelController.levels[level].knifesInWood;
        Messenger<int>.Broadcast(GameEvent.Change_Score, score);
        UIController.canThrow = true;
    }

    public void AddApplesScore()
    {
        applesScore++;
        Messenger<int>.Broadcast(GameEvent.Apple_Score, applesScore);
    }
    public void AddScore()
    {
        score++;
        Messenger<int>.Broadcast(GameEvent.Change_Score, score);
    }
    public void LevelRestart()
    {
        score = 0;
        level = 0;
        Messenger<int>.Broadcast(GameEvent.Apple_Score, applesScore);
        Messenger<int>.Broadcast(GameEvent.Change_Score, score);
        SendLevel();        
        Messenger.Broadcast(GameEvent.Restart);
    }
    public void LevelNext()
    {
        StartCoroutine(WaitLevelNext());
    }

    IEnumerator WaitLevelNext()
    {
        yield return new WaitForSeconds(1.1f);
        Messenger.Broadcast(GameEvent.Delete_Wood_Childs);
        level++;
        SendLevel();
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.Knife_In_Apple, AddApplesScore);
        Messenger.RemoveListener(GameEvent.Knife_Hit, AddScore);
        Messenger.RemoveListener(GameEvent.Next_Level, LevelNext);
    }
}
