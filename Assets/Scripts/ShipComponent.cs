using UnityEngine;
using System.Collections;

public delegate void ShippActivated();
public delegate void ShipDeactivated();

public class ShipComponent : MonoBehaviour {

    private event ShippActivated onActivated;
    private event ShipDeactivated onDeactivated;

    private bool isActivated = false;

	// Use this for initialization
	void Start () {
	
	}

    public void Activate()
    {
        if(!isActivated)
        {
            isActivated = true;
            if (onActivated != null)
            {
                onActivated.Invoke();
            }
        }

    }

    public void Deactivate()
    {
        if (isActivated)
        {
            isActivated = false;
            if (onDeactivated != null)
            {
                onDeactivated.Invoke();
            }
        }
    }

    public ShippActivated OnActivated
    {
        get { return onActivated; }
        set { onActivated = value; }
    }

    public ShipDeactivated OnDeactivate
    {
        get { return onDeactivated; }
        set { onDeactivated = value; }
    }
}
