using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private bool _inWood = false;
    [SerializeField] GameObject applePart;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wood")
        {
            Messenger.Broadcast(GameEvent.Knife_Hit);
            rigidbody.velocity = Vector2.zero;
            transform.parent = other.transform;
            _inWood = true;          
        }
        if(other.gameObject.tag == "Knife" && !_inWood)
        {
            Messenger.Broadcast(GameEvent.Knife_Dont_Match_Sound);
            rigidbody.gravityScale = 1;
            UIController.canThrow = false;
            StartCoroutine(WaitMessage());
        }
        if(other.gameObject.tag == "Apple")
        {
            Messenger.Broadcast(GameEvent.Knife_In_Apple);
            Destroy(other.gameObject);
            Vector3 vect = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            Instantiate(applePart, vect, Quaternion.identity);
            vect = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            Instantiate(applePart, vect, Quaternion.identity);
        }
    }

    private IEnumerator WaitMessage()
    {
        yield return new WaitForSeconds(1);
        Messenger.Broadcast(GameEvent.Knife_Dont_Match);
    }
}
