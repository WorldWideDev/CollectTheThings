using System.Collections;
using System;
using UnityEngine;

// we use this namespace for manipulating UI elements in the scene
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

    // declare our scoreText variable, of type Text
    Text scoreText;

    public void Awake()
    {
        // register our collectedSphere function to the delegate
        eCollectables.onCollected += collectedSphere;

        // find any Text component on this game object and assign to our varibale
        scoreText = GetComponent<Text>();
    }

    public void Start()
    {
        // we want our text to display on start
        updateScoreDisplay();

    }

    public void Destroy()
    {
        // its good practice to unregister our event functions on the Destroy method
        eCollectables.onCollected -= collectedSphere;
    }

    public void collectedSphere(object sender)
    {
        // our sphere has been collected, we:

        // update the gameManager singleton
        ++gameManager.Instance.score;

        // render our UI again
        updateScoreDisplay();

        // check to see if we can level up, and do so if we reached the required score
        if (gameManager.Instance.score == gameManager.Instance.scoreToLevel)
            eLevelUp.levelUp();
    }
    
    void updateScoreDisplay()
    {
        // render our UI
        scoreText.text = "Score: "+gameManager.Instance.score;
    }

}
