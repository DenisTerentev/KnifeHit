using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelNumber;
    public int appleQuantity;
    public int knifes;
    public int knifesInWood;
    public int tipeOfWood;
    public int difficult;

    public Level(int LevelNumber, int AppleQuantity, int Knifes, int KnifesInWood, int TipeOfWood, int Difficult)
    {
        levelNumber = LevelNumber;
        appleQuantity = AppleQuantity;
        knifes = Knifes;
        knifesInWood = KnifesInWood;
        tipeOfWood = TipeOfWood;
        difficult = Difficult;
    }
}
