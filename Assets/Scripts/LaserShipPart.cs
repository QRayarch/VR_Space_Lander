using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(ShipComponent))]
public class LaserShipPart : MonoBehaviour {

    public LayerMask laserHitMask;
    public float maxDistance = 10;
    public float radius = 1;
    public float distanceToActivateOn = 8;

    private LineRenderer lineRender;
    private ShipComponent shipComponent;

	// Use this for initialization
	void Start () {
        lineRender = GetComponent<LineRenderer>();
        shipComponent = GetComponent<ShipComponent>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        float dist = maxDistance;
	    if(Physics.SphereCast(transform.position, radius, transform.forward, out hit, maxDistance, laserHitMask.value, QueryTriggerInteraction.Ignore))
        {
            dist = hit.distance + radius;
        }
        lineRender.SetPosition(1, transform.forward * dist);
        if(dist >= distanceToActivateOn)
        {
            shipComponent.Activate();
        } else
        {
            shipComponent.Deactivate();
        }
        lineRender.SetWidth(radius, radius);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + transform.forward * distanceToActivateOn, Vector3.one * radius);
    }
}
