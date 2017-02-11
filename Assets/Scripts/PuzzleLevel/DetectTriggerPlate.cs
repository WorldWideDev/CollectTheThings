using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTriggerPlate : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            print("hello");
            PlateEvents.ActivatePlate(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            PlateEvents.DeactivatePlate(other.gameObject);
        }
    }
}
