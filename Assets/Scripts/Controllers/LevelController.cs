using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<Level> levels;
    [SerializeField] AppleChance chance;

    void Awake()
    {
        Init();
        Messenger<int>.AddListener(GameEvent.Level, MessageLevel);
    }

    void Init()
    {
        TextAsset levelsConfig = Resources.Load<TextAsset>("Config/Levels");

        XmlDocument levelsXml = new XmlDocument();
        using (var reader = new StringReader(levelsConfig.ToString()))
        {
            levelsXml.Load(reader);
        }

        XmlElement rootElem = levelsXml.DocumentElement;
        foreach (XmlNode node in rootElem.SelectNodes("level"))
        {
            Level level = ParseOrder(node);
            levels.Add(level);
        }
        
    }
    Level ParseOrder(XmlNode node)
    {
        int apple = 0;
        
        if (UnityEngine.Random.Range(1,(int)((1/(chance.appleChance/100f))+1))==1)
        {
            apple = 1;
        }
        Level level = new Level(Int32.Parse(node.Attributes[0].InnerText),
                                apple,
                                Int32.Parse(node.Attributes[1].InnerText),
                                Int32.Parse(node.Attributes[2].InnerText),
                                Int32.Parse(node.Attributes[3].InnerText),
                                Int32.Parse(node.Attributes[4].InnerText));
        return level ;
    }
    public void MessageLevel(int levelNumber)
    {
        Messenger<int, int>.Broadcast(GameEvent.Knifes_And_Apples_In_Wood, levels[levelNumber].knifesInWood, levels[levelNumber].appleQuantity);
        Messenger<int>.Broadcast(GameEvent.Knifes_Quantity, levels[levelNumber].knifes);
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.Level, MessageLevel);
    }

}
