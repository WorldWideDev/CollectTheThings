using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSunrise : MonoBehaviour {

    // rise is of type Animation
    Animation rise;

	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        // grab the Animation component from this game object
        rise = GetComponent<Animation>();

        // set rate on the anim, this would be better to set to a public variable that we could control from the scene
        rise["sunrise"].speed = .5f;

        // register our function to listen for the onLevelUp event
        eLevelUp.onLevelUp += triggerSunrise;
    }
    void Destroy()
    {
        eLevelUp.onLevelUp -= triggerSunrise;
    }

    public void triggerSunrise()
    {
        // play the animation
        rise.Play();
    }
	
}
