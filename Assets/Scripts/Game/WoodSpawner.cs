using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] woods;
    [SerializeField] GameObject[] parts;
    GameObject wood;
    GameObject part;
    Animator anim;
    int _numberWood;

    void Awake()
    {
        Messenger<int>.AddListener(GameEvent.Type_Of_Wood,AddWood);
        Messenger<int, int>.AddListener(GameEvent.Knifes_And_Apples_In_Wood, AddKnifesAndApples);
        Messenger.AddListener(GameEvent.Delete_Wood_Childs, DeleteWoodChilds);
        Messenger.AddListener(GameEvent.Knife_Hit, WoodShake);
        Messenger<int>.AddListener(GameEvent.Difficult, ChangeDifficult);
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void AddWood(int Wood)
    {
        _numberWood = Wood;
        DeleteChilds();
        wood=Instantiate(woods[Wood], transform);
    }

    void DeleteChilds()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    void AddKnifesAndApples(int knifes,int apples)
    {
        wood.GetComponent<Wood>().AddKnifesAndApples(knifes, apples);
    }
    void DeleteWoodChilds()
    {
        part=Instantiate(parts[_numberWood], transform);
        part.transform.parent = null;
        wood.GetComponent<Wood>().DeleteChilds();
        DeleteChilds();
        Destroy(part, 1f);
    }
    void WoodShake()
    {
        anim.SetTrigger("Shake");
    }
    void ChangeDifficult(int difficult)
    {
        wood.GetComponent<Wood>().ChuseDifficult(difficult);
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.Type_Of_Wood,AddWood);
        Messenger<int, int>.RemoveListener(GameEvent.Knifes_And_Apples_In_Wood, AddKnifesAndApples);
        Messenger.RemoveListener(GameEvent.Delete_Wood_Childs, DeleteWoodChilds);
        Messenger.RemoveListener(GameEvent.Knife_Hit, WoodShake);
        Messenger<int>.RemoveListener(GameEvent.Difficult, ChangeDifficult);
    }

}
