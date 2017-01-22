using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PowerUp")
        {
            GameObject.Find("Spawner").GetComponent<PowerUpSpawner>().delay = 0;
            Destroy(other.gameObject);
            GetComponent<Rigidbody>().mass = 3;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            transform.position = new Vector3(transform.position.x, 0.6f * 1.5f, transform.position.z);
            GetComponent<PlayerMovement>().poweredUp = true;
        }
    }
}
