using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public void ChangeSize()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        StartCoroutine(ChangeBack());
    }
    private IEnumerator ChangeBack()
    {
        yield return new WaitForSeconds(0.2f);
        transform.localScale = Vector3.one;
    }
}
