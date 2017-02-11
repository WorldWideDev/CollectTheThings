using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateEvents : MonoBehaviour {

    public delegate void PlateActiveHandler(GameObject sender);
    public static event PlateActiveHandler onPlateActive;
    public static event PlateActiveHandler onPlateInactive;

    public static void ActivatePlate(GameObject sender)
    {
        if (onPlateActive != null)
        {
            onPlateActive(sender);
        }
    }

    public static void DeactivatePlate(GameObject sender)
    {
        if (onPlateInactive != null)
        {
            onPlateInactive(sender);
        }
    }
}
