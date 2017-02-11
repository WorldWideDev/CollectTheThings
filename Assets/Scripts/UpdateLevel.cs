using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour {

    Text levelText;
    public void Awake()
    {
        // register our function to listen for onLevelUp
        eLevelUp.onLevelUp += levelingUp;

        // grabbing the Text component from our game object
        levelText = GetComponent<Text>();
    }

    public void Destroy()
    {
        eLevelUp.onLevelUp -= updateLevelDisplay;
    }

    public void Start()
    {
        // render UI on start
        updateLevelDisplay();
    }

    public void levelingUp()
    {
        // increment our gamemanager singleton's level variable
        ++gameManager.Instance.level;
        // re render UI when leveling
        updateLevelDisplay();
        SaveLoad.Save();
    }

    void updateLevelDisplay()
    {
        // rendering ui
        levelText.text = "Level: " + gameManager.Instance.level;
    }
    
}
