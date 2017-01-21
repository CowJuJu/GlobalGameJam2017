using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaves : MonoBehaviour
{
    public string player;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButtonUp("Fire_P" + player) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}