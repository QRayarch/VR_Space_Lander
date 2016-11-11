using UnityEngine;
using System.Collections;

public class CapsuleRotate : MonoBehaviour {

    Quaternion spin;

	// Use this for initialization
	void Start () {
	    //transform.Rotate(new Vector3(20,20,20));
        InvokeRepeating("setSpin",0,5.0f);
	}
	
    void setSpin() {
        spin = new Quaternion(Random.value,Random.value,Random.value,Random.value); 
    }

	// Update is called once per frame
	void Update () {
	    Quaternion alt = transform.rotation * spin;
        transform.rotation = Quaternion.Slerp(transform.rotation,alt,0.5f * Time.deltaTime);
	}
}
