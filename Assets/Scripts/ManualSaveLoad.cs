using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualSaveLoad : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            SaveLoad.Save();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveLoad.Load();
        }
	}
}
