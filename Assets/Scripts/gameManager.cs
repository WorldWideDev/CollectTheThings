using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;



public class gameManager : MonoBehaviour {

    public int score = 0;
    public int level = 1;
    public int scoreToLevel = 4;



	public static gameManager Instance
    {
        get
        {// create gameManager GameObject is required
            if (instance == null) instance = new GameObject("gameManager").AddComponent<gameManager>();
            return instance;
        }
    }
    private static gameManager instance = null;

    void Awake()
    {
        SaveLoad.Init();
        if (instance)
            Destroy(gameObject); //delete  any dupes
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //set as do not destroy
        }
    }

}
