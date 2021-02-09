using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] GameObject buttinClick;
    [SerializeField] GameObject knifeInWood;
    [SerializeField] GameObject knifeInKnife;
    [SerializeField] GameObject throwSound;
    bool knife=false;
    void Awake()
    {
        Messenger.AddListener(GameEvent.Knifes_Throw, ThrowSound);
        Messenger.AddListener(GameEvent.Knife_Dont_Match_Sound, KnifeInKnife);
        Messenger.AddListener(GameEvent.Knife_Hit, KnifeInWood);
        
    }
    public void ButtonClick()
    {
        Instantiate(buttinClick, transform.position, Quaternion.identity);
    }
    void KnifeInWood()
    {
        if (!knife)
        {
            Instantiate(knifeInWood, transform.position, Quaternion.identity);
            knife = false;
            Vibration.Init();
            Vibration.Vibrate();
            Vibration.Cancel();
        }
    }
    void KnifeInKnife()
    {
        knife = true;
        Instantiate(knifeInKnife, transform.position, Quaternion.identity);
    }
    void ThrowSound()
    {
        Instantiate(throwSound, transform.position, Quaternion.identity);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.Knifes_Throw, ThrowSound);
        Messenger.RemoveListener(GameEvent.Knife_Hit, KnifeInWood);
        Messenger.RemoveListener(GameEvent.Knife_Dont_Match_Sound, KnifeInKnife);
    }
}
