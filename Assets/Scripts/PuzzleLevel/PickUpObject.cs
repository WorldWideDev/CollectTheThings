using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public float carryDistance = 1;
    public float raycastDistance = 25f;
    public float smooth = 4;
    public float shootForce = 100f;

    Camera mainCam;
    bool isCarrying = false;
    GameObject carriedObject;
	// Use this for initialization
	void Start () {
        mainCam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (isCarrying)
        {
            Carry(carriedObject);
            CheckDrop();
            CheckThrow();
        } else
        {
            PickUp();
        }
        Debug.DrawRay(mainCam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0)), mainCam.transform.forward * raycastDistance, Color.green);
	}

    void Carry(GameObject go)
    {
        go.transform.position = Vector3.Lerp(go.transform.position, mainCam.transform.position + mainCam.transform.forward * carryDistance, Time.deltaTime * smooth);

    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 origin = mainCam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(origin, mainCam.transform.forward, out hit, raycastDistance))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p != null)
                {
                    print("hit");

                    isCarrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    void CheckDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropObject();
        }
    }

    void CheckThrow()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("pressed mount rclick");
            Vector3 origin = mainCam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(origin, mainCam.transform.forward, out hit, raycastDistance))
            {
                isCarrying = false;
                carriedObject.GetComponent<Rigidbody>().isKinematic = false;
                StartCoroutine(ThrowObject(hit, mainCam.transform.forward));
                carriedObject = null;

            }
        }
    }

    IEnumerator ThrowObject(RaycastHit hit, Vector3 launchAngle)
    {
        print(hit.normal);
        hit.rigidbody.AddForce(launchAngle * shootForce);
        yield return new WaitForSeconds(1);
    }

    void DropObject()
    {
        isCarrying = false;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }

    
}
