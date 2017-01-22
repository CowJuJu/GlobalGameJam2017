using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCollision : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "CurrentLeft")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0, 0));
        }

        if (other.tag == "CurrentRight")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 0));
        }
    }
}
