using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class PhysicsBodyTransform : MonoBehaviour {

    public Transform target;

    private Rigidbody rBody;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 toVector = (target.position - transform.position) * 1000 * Time.fixedDeltaTime;
        rBody.velocity =  Vector3.MoveTowards(rBody.velocity, toVector, 10);

        rBody.MoveRotation(Quaternion.RotateTowards(rBody.rotation, target.rotation, 10000 * Time.fixedDeltaTime));
	}
}
