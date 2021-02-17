using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePlace : MonoBehaviour
{
    public KnifeSlot[] slots;
    int startQuantity;
    int _quantity;
    int knifeHit=0;
    int startKnifeInWood = 0;

    void Awake()
    {
        Messenger<int>.AddListener(GameEvent.Knifes_Quantity, CompleteSlots);
        Messenger.AddListener(GameEvent.Knifes_Throw, ChangeAfterThrow);
        Messenger.AddListener(GameEvent.Knife_Hit, CountKnifeHits);
        Messenger<int, int>.AddListener(GameEvent.Knifes_And_Apples_In_Wood, AddKnifeInWood);
    }

    public void CompleteSlots(int quantity)
    {
        knifeHit = 0;
        DeleteSlots();
        startQuantity = quantity;
        _quantity = quantity;
        for(int i=0;i<quantity;i++)
        {
            slots[i].AddKnifeFull();
        }
    }

    public void DeleteSlots()
    {
        foreach(KnifeSlot slot in slots)
        {
            slot.DeleteSlot();
        }
    }

    void AddKnifeInWood(int knife,int apple)
    {
        startKnifeInWood = knife;
    }

    public void CountKnifeHits()
    {
        knifeHit++;
        
        if (knifeHit == startQuantity + startKnifeInWood)
        {
            knifeHit = 0;
            startKnifeInWood = 0;
            UIController.canThrow = false;
            Messenger.Broadcast(GameEvent.Delete_Wood_Childs);
            StartCoroutine(NextLevel());
        }
    }
    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        if (UIController.canThrow == false)
        {
            Messenger.Broadcast(GameEvent.Next_Level);
        }
    }

    public void ChangeAfterThrow()
    {
        if(_quantity>=1)
        {
            _quantity -= 1;
            slots[_quantity].AddKnifeEmpty();
        }       
    }


    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.Knifes_Quantity, CompleteSlots);
        Messenger.RemoveListener(GameEvent.Knifes_Throw, ChangeAfterThrow);
        Messenger.RemoveListener(GameEvent.Knife_Hit, CountKnifeHits);
        Messenger<int, int>.RemoveListener(GameEvent.Knifes_And_Apples_In_Wood, AddKnifeInWood);
    }
}
