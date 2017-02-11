using System.Collections;
using System;
using UnityEngine;

public class detectCollect : MonoBehaviour {

    MeshRenderer _renderer;
    Collider _collider;
    // detect collision with player
    // OnTriggerEnter is a monobehaviour that fires when a collision is dectected from the gameobject (and isTrigger == true)

    void Awake()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();
        _collider = gameObject.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        // trigger an event on eCollectables
        eCollectables.collectedSphere(gameObject);

        _renderer.enabled = false;
        _collider.enabled = false;

        // destroy self when collected

        Destroy(gameObject, collectableAudio.clipToPlay.length);

    }
}
