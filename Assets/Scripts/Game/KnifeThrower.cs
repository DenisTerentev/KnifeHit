using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    GameObject spawner;
    public GameObject knifePrefab;
    public float speed;

    public void Throw()
    {
        Messenger.Broadcast(GameEvent.Knifes_Throw);
        spawner = Instantiate(knifePrefab, transform);
        spawner.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed, ForceMode2D.Impulse);   
    }
}
