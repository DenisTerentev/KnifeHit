using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] AppleData[] data;

    void Awake()
    {
        Messenger.AddListener(GameEvent.Apple_Start, StartApple);
        Messenger.AddListener(GameEvent.Knife_In_Apple, HitApple);
    }
    void StartApple()
    {
        GetComponent<SpriteRenderer>().sprite = data[0].MainSprite;
        this.tag = data[0].Tag;
        GetComponent<Rigidbody2D>().gravityScale = data[0].Gravity;
    }
    void HitApple()
    {
        GetComponent<SpriteRenderer>().sprite = data[1].MainSprite;
        this.tag = data[1].Tag;
        GetComponent<Rigidbody2D>().gravityScale = data[1].Gravity;
        StartCoroutine(AppleNull());
    }
    private IEnumerator AppleNull()
    {
        yield return new WaitForSeconds(0.9f);

        GetComponent<SpriteRenderer>().sprite = data[2].MainSprite;
        this.tag = data[2].Tag;
        GetComponent<Rigidbody2D>().gravityScale = data[2].Gravity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wood")
        {
            transform.parent = other.transform;
        }
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.Apple_Start, StartApple);
        Messenger.RemoveListener(GameEvent.Knife_In_Apple, HitApple);
    }
}
