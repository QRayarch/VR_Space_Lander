using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    public GameObject pickup;
    public SteamVR_Controller.DeviceRelation hand;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device controller {  get { return SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(hand)); } }

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {
        // If we can't find the controller do nothing
        if (controller == null)
        {
            return;
        }
        if (controller.GetPressUp(gripButton))
        {
            Drop();
        }
    }

    private void Drop()
    {
        if (pickup == null) return;
        pickup.transform.parent = null;
        pickup.GetComponent<Rigidbody>().isKinematic = false;
        pickup = null;
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "interactable")
        {
            if (controller.GetPressDown(gripButton))
            {
                Drop();
                pickup = collider.gameObject;
                pickup.transform.parent = this.transform;
                pickup.GetComponent<Rigidbody>().isKinematic = true;
            }
        }else if (collider.tag == "winch")
        {
            Debug.DrawLine(collider.transform.position, transform.position, Color.red);

            if (controller.GetPress(gripButton))
            {
                WinchHandle butts = collider.gameObject.GetComponent<WinchHandle>();
                Vector3 temp = transform.position;
                temp.x = butts.winchParent.transform.position.x;
                butts.winchParent.transform.rotation = Quaternion.LookRotation(temp - transform.position);
                //butts.winchParent.transform.LookAt(transform);
                //butts.winchParent.transform.rotation = Quaternion.Euler(butts.winchParent.transform.rotation.eulerAngles.x, 0, 0);
                //Debug.Log(butts.winchParent.transform.rotation.eulerAngles);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //pickup = null;
    }
}
