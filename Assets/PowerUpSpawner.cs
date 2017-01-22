using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public Object powerUp;
    public bool powerUpExists = false;

    public float delay = 0;

    void FixedUpdate()
    {
        delay += Time.deltaTime;

        if(!powerUpExists && delay > 20)
        {
            powerUpExists = true;

            var x = Random.Range(-10, 10);
            var z = Random.Range(-10, 10);

            while (Physics.CheckBox(new Vector3(x, 0.5f, z), new Vector3(0.5f, 0.48f, 0.5f), Quaternion.identity))
            {
                x = Random.Range(-10, 10);
                z = Random.Range(-10, 10);
            }

            Instantiate(powerUp, new Vector3(x, 0.15f, z), Quaternion.identity);
        }
    }
}
