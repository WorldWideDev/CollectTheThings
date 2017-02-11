using System.Collections;
using System;
using UnityEngine;

public class collectableAudio : MonoBehaviour {

    public AudioClip[] pops;
    public static AudioClip clipToPlay;
    AudioSource PulseLoop;

    AudioSource a;

    void Awake()
    {
        a = gameObject.GetComponent<AudioSource>();
        eCollectables.onCollected += PlayCollect;
        PulseLoop = transform.GetChild(0).GetComponent<AudioSource>();
    }
    void OnDestroy()
    {
        eCollectables.onCollected -= PlayCollect;
    }
    void PlayCollect(GameObject sender)
    {
        if(sender == gameObject)
        {
            AudioClip randomPop = pops[UnityEngine.Random.Range(0, pops.Length - 1)];
            clipToPlay = randomPop;
            a.PlayOneShot(randomPop);
            PulseLoop.volume = Mathf.Lerp(PulseLoop.volume, 0, clipToPlay.length);
        }
        
    }
}
