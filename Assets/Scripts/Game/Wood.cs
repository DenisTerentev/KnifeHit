using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    float speed = 3;
    bool differentRotate = false;
    bool slowingDown = false;
    public GameObject knife;
    public GameObject apple;
    bool tern = false;

    void FixedUpdate()
    {
        if (slowingDown)
        {
            if (Random.Range(1, 30) == 1)
            {
                if (differentRotate && speed >= -6 && !tern)
                {
                    speed -= Random.Range(1, 2);
                    if (speed <= -6) tern = !tern;
                }
                else if (differentRotate && speed <= 6 && tern)
                {
                    speed += Random.Range(1, 2);
                    if (speed >= 6) tern = !tern;
                }
                if (!differentRotate && speed >= 1 && !tern)
                {
                    speed -= Random.Range(1, 2);
                    if (speed <= 1) tern = !tern;
                }
                else if (!differentRotate && speed <= 5 && tern)
                {
                    speed += Random.Range(1, 2);
                    if (speed >= 5) tern = !tern;
                }
            }
        }
        transform.Rotate(0, 0, speed);

    }
    public void ChuseDifficult(int difficult)
    {
        if (difficult == 1)
        {
            speed = 3;
            differentRotate = false;
            slowingDown = false;
        }
        else if (difficult == 2)
        {
            speed = 5;
            slowingDown = true;
            differentRotate = false;

        }
        else
        {
            speed = 6;
            differentRotate = true;
            slowingDown = true;
        }
    }


    public void DeleteChilds()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Collider2D>().isTrigger = false;
            child.transform.parent = null;
            child.GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(child.gameObject, 0.7f);
        }
    }

    public void AddKnifesAndApples(int knifes, int apples)
    {
        float radius = this.GetComponent<CircleCollider2D>().radius;
        List<Vector3> vectors = new List<Vector3>();

        if (knifes > 0)
            for (int i = 0; i < knifes; i++)
            {
                Vector3 vector = RandomCircle(transform.position, radius, vectors);
                Instantiate(knife, vector, Quaternion.LookRotation(Vector3.forward, transform.position - vector));
            }

        if (apples > 0)
            for (int i = 0; i < apples; i++)
            {
                Vector3 vector = RandomCircle(transform.position, radius + 0.3f, vectors);
                Instantiate(apple, vector, Quaternion.LookRotation(Vector3.forward, vector - transform.position));
                Messenger.Broadcast(GameEvent.Apple_Start);
            }
    }

    Vector3 RandomCircle(Vector3 center, float radius, List<Vector3> vectors)
    {

        bool add = true;
        float angle = Random.value * 360;
        Vector3 newVector = new Vector3(radius * Mathf.Cos(angle * Mathf.Deg2Rad) + center.x,
                                     radius * Mathf.Sin(angle * Mathf.Deg2Rad) + center.y);
        foreach (Vector3 vector in vectors)
        {
            add = false;
            Vector3 check = vector - newVector;
            if (check.magnitude < 0.6f)
            {
                newVector = RandomCircle(center, radius, vectors);
                break;
            }
            else add = true;
        }
        if (add) vectors.Add(newVector);
        return newVector;
    }
}
