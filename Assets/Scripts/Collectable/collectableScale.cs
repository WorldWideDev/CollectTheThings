using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScale : MonoBehaviour {
    public float scaleAmount = .5f;
    public float pulseSpeed = 1.0f;
    public float size = 0.5f;

    void Start()
    {
       // Time.timeScale = .3f;
    }
	
	// Update is called once per frame
	void Update () {
        // ping pong interpolates b/w 2 values, this gives us a pulse effect when we apply to scale of transform
        float scaleAmt = Mathf.PingPong(pulseSpeed * Time.time, size) + scaleAmount;
        transform.localScale = new Vector3(scaleAmt, scaleAmt, scaleAmt);
	}
}
