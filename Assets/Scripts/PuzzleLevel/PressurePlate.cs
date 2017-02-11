using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        PlateEvents.onPlateActive += SetPlateToActive;
        PlateEvents.onPlateInactive += SetPlateToInactive;
        anim = GetComponent<Animator>();
       
    }

    void SetPlateToActive(GameObject sender)
    {
        anim.SetBool("isActive", true);
    }

    void SetPlateToInactive(GameObject sender)
    {
        anim.SetBool("isActive", false);
    }

    void OnDestroy()
    {
        PlateEvents.onPlateActive -= SetPlateToActive;
        PlateEvents.onPlateInactive -= SetPlateToInactive;
    }

}
