using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private bool _inWood = false;
    private bool _inKnife = false;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wood" && !_inKnife)
        {
            Messenger.Broadcast(GameEvent.Knife_Hit);
            rigidbody.velocity = Vector2.zero;
            transform.parent = other.transform;
            _inWood = true;          
        }
        if(other.gameObject.tag == "Knife" && !_inWood)
        {
            Messenger.Broadcast(GameEvent.Knife_Dont_Match_Sound);
            _inKnife = true;          
            rigidbody.velocity = Vector2.zero;
            transform.parent = other.transform;
            rigidbody.gravityScale = 1;
            UIController.canThrow = false;

            StartCoroutine(WaitMessage());
        }
        if(other.gameObject.tag == "Apple")
        {
            Messenger.Broadcast(GameEvent.Knife_In_Apple);
        }
    }

    private IEnumerator WaitMessage()
    {
        yield return new WaitForSeconds(1);
        Messenger.Broadcast(GameEvent.Knife_Dont_Match);
    }
}
