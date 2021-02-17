using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewAppleChance",menuName ="Apple Chance",order =52)]
public class AppleChance : ScriptableObject
{
    [Range(1, 100)] public int appleChance = 25;
}
