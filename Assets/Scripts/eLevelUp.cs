using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eLevelUp : MonoBehaviour {

    public delegate void LevelHandler();
    public static event LevelHandler onLevelUp;

    public static void levelUp()
    {
        // this is the cool new way to invoke delegate, will never throw a NullRefrenceException
        if (onLevelUp != null)
            onLevelUp();
    }


}
