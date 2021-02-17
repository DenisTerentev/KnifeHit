using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] GameObject buttinClick;
    [SerializeField] GameObject knifeInWood;
    [SerializeField] GameObject knifeInKnife;
    [SerializeField] GameObject throwSound;
    [SerializeField] GameObject mainMusic;
    public static bool knife=false;

    void Awake()
    {
        Messenger.AddListener(GameEvent.Knifes_Throw, ThrowSound);
        Messenger.AddListener(GameEvent.Knife_Dont_Match_Sound, KnifeInKnife);
        Messenger.AddListener(GameEvent.Knife_Hit, KnifeInWood);
        Messenger.AddListener(GameEvent.Next_Level, Win);
        Vibration.Init();

    }
    void Start()
    {
        Instantiate(mainMusic, transform);
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
            Vibration.VibratePeek();                    
        }
    }
    void Win()
    {
        Vibration.Vibrate();
    }
    void KnifeInKnife()
    {
        knife = true;
        Instantiate(knifeInKnife, transform.position, Quaternion.identity);
        Vibration.Vibrate();
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
        Messenger.RemoveListener(GameEvent.Next_Level, Win);
        Vibration.Cancel();
    }
}
