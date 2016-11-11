using UnityEngine;
using System.Collections;

public class Snap : MonoBehaviour {
    
    private GameObject lController;
    private GameObject rController;

    // Use this for initialization
    void Start () {
    }


    private void OnTriggerEnter(Collider collider)
    {
        /*lController = GameObject.Find("Controller (left)");
        rController = GameObject.Find("Controller (right)");

        if (collider.gameObject.transform.parent == lController)
        {
            GameObject lpickup = lController.GetComponent<Controller>().pickup;
            if (lpickup.name.Equals("Battery"))
            {
                lController.GetComponent<Controller>().Drop();
                SnapObject(lpickup);
            }
        }
        if (collider.gameObject.transform.parent == rController)
        {
            GameObject rpickup = rController.GetComponent<Controller>().pickup;
            if (rpickup.gameObject.name.Equals("Battery"))
            {
                rController.GetComponent<Controller>().Drop();
                SnapObject(rpickup);
            }
        }*/
        if (collider.gameObject.name.Equals("Battery"))
        {
            Controller[] controllers = FindObjectsOfType<Controller>();
            for(int c = 0; c < controllers.Length; ++c)
            {
                if(controllers[c].pickup == collider.gameObject)
                {
                    controllers[c].Drop();
                }
            }
            SnapObject(collider.gameObject);
        }
    }

    private void SnapObject(GameObject pickup)
    {
        pickup.transform.SetParent(transform);
        pickup.transform.localPosition = Vector3.zero;
        pickup.transform.localRotation = Quaternion.identity;
        Rigidbody rBody = pickup.GetComponent<Rigidbody>();
        if(rBody != null)
        {
            rBody.isKinematic = true;
        }
    }
}
