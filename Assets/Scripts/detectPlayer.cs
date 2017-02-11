using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour {

    public float raycastDist = 20;

    void FixedUpdate () {

        RaycastHit hit;
        Ray forwardRay = new Ray(transform.position, transform.TransformDirection(Vector3.right));

        Vector3 forward = transform.TransformDirection(Vector3.right) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
       // Physics.SphereCast()
        if (Physics.Raycast(forwardRay, out hit, raycastDist))
        {
            if(hit.collider.tag == "Player")
            {
                Debug.Log(hit.collider.tag);
            }
            
        }
	}
}
