using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text score;
    public Text level;

    void Awake()
    {
        // register our function to listen for onLevelUp
        eLevelUp.onLevelUp += levelingUp;
        eCollectables.onCollected += collectedSphere;
    }

    void Start()
    {
        // we want our text to display on start
        updateScoreDisplay();
        updateLevelDisplay();
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

    public void levelingUp()
    {
        // increment our gamemanager singleton's level variable
        ++gameManager.Instance.level;
        // re render UI when leveling
        updateLevelDisplay();
    }

    void updateLevelDisplay()
    {
        // rendering ui
        level.text = "Level: " + gameManager.Instance.level;
    }

    void updateScoreDisplay()
    {
        // render our UI
        score.text = "Score: " + gameManager.Instance.score;
    }

    public void Destroy()
    {
        // its good practice to unregister our event functions on the Destroy method
        eCollectables.onCollected -= collectedSphere;
        eLevelUp.onLevelUp -= levelingUp;
    }

    
}
