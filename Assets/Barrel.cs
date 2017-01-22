using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {
	void Update ()
    {
		if(Mathf.Abs(transform.position.x) > 15)
        {
            Debug.Log("Should Fall");
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
	}
}
