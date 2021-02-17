using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AppleData", menuName = "Apple Data", order = 51)]
public class AppleData : ScriptableObject
{
    [SerializeField] Sprite mainSprite;
    public Sprite MainSprite
    {
        get
        {
            return mainSprite;
        }
    }
    [SerializeField] string tag;
    public string Tag
    {
        get
        {
            return tag;
        }
    }
    [SerializeField] int gravity;
    public int Gravity
    {
        get
        {
            return gravity;
        }
    }
}
