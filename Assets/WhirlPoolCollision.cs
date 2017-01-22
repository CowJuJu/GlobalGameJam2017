using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlPoolCollision : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Whirlpool")
        {
            var rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rigid.drag = 0;
            rigid.angularDrag = 0;
            rigid.AddTorque(transform.up * 50);
            rigid.AddForce(new Vector3(0, -20, 0));
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<PlayerMovement>().isAlive = false;
        }
    }
}
