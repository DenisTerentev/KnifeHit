using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeSlot : MonoBehaviour
{
    public GameObject knifeFull;
    GameObject slot;
    public void AddKnifeFull()
    {
        slot=Instantiate(knifeFull, transform);
    }
    public void AddKnifeEmpty()
    {
        slot.GetComponent<Image>().color = new Color(225,225 ,225 , 0.5f);
    }
    public void DeleteSlot()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
