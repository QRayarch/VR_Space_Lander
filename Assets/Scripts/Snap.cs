using UnityEngine;
using System.Collections;

public class Snap : MonoBehaviour {
    
    private GameObject lController;
    private GameObject rController;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider collider)
    {
        lController = GameObject.Find("Controller (left)");
        rController = GameObject.Find("Controller (right)");

        if(collider.gameObject.transform.parent == lController)
        {
            GameObject lpickup = lController.GetComponent<Controller>().pickup;
            if(lpickup.name == "Battery")
            {
                SnapObject(lpickup);
                lController.GetComponent<Controller>().pickup = null;
            }
        }
        if(collider.gameObject.transform.parent == rController)
        {
            GameObject rpickup = rController.GetComponent<Controller>().pickup;
            if(rpickup.gameObject.name == "Battery")
            {
                SnapObject(rpickup);
                rController.GetComponent<Controller>().pickup = null;
            }
        }
    }

    private void SnapObject(GameObject pickup)
    {
        pickup.transform.parent = null;
        pickup.transform.position = this.transform.position;
        pickup.transform.rotation = this.transform.rotation;
    }
}
