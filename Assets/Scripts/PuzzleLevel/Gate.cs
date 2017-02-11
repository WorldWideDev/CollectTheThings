using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    Animator gateAnim;

	void Awake()
    {
        gateAnim = GetComponent<Animator>();
        PlateEvents.onPlateActive += OpenGate;
        PlateEvents.onPlateInactive += CloseGate;
    }

    void OpenGate(GameObject sender)
    {
        gateAnim.SetBool("isActive", true);
    }

    void CloseGate(GameObject sender)
    {
        gateAnim.SetBool("isActive", false);
    }

    void OnDestroy()
    {
        PlateEvents.onPlateActive -= OpenGate;
        PlateEvents.onPlateInactive -= CloseGate;
    }
}
