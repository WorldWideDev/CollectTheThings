using System.Collections;
using System;
using UnityEngine;

public class eCollectables : MonoBehaviour {

    // delegate delaration, delegates are references to functions
    public delegate void CollectableHandler(GameObject sender);

    // declare our event as conforming to the delegate
    public static event CollectableHandler onCollected;

    // function that broadcasts the event
    public static void collectedSphere(GameObject sender)
    {
        // null checks like this are good practice
        if (onCollected != null)
            onCollected(sender);
    }

    public static void LoadedScene(GameObject sender)
    {
        if (onCollected != null)
            onCollected(sender);
    }
}
