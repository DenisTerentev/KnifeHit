using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    private static int score;
    private static string scoreKey = "PLAYER_SCORE";

    private static int stage;
    private static string stageKey = "PLAYER_STAGE";

    private static int apples;
    private static string appleKey = "APPLE_QUANTITY";

    public static Dictionary<string, int> keys = new Dictionary<string, int>
    {
        [scoreKey]=score,
        [stageKey]=stage,
        [appleKey]=apples
    };
    
    public static void Save(string key, int value)
    {
        if (SaveManager.Load(key) < value)
        {
            keys[key] = value;
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
    }

     

    public static int Load(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            keys[key] = PlayerPrefs.GetInt(key);
            return keys[key];
        }
        else return 0;
    }
}
