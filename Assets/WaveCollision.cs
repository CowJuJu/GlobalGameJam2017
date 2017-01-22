using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollision : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Ship")
        {
            if (other.tag == "Wave")
            {
                var strength = other.gameObject.GetComponent<WaveMovement>().GetStrength();
                GetComponent<Rigidbody>().AddForce(other.GetComponent<Rigidbody>().velocity.normalized * 200 * strength);
                Destroy(other.gameObject);
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}