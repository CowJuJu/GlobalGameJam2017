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
    private float strength;

    void Update()
    {
        if (GetComponent<PlayerMovement>().isAlive && !GameObject.Find("LevelManager").GetComponent<Level>().preventMovement)
        {
            if (Input.GetButtonDown("Fire_P" + player) && Time.time > nextFire)
            {
                strength = 1f;
            }

            if (Input.GetButton("Fire_P" + player))
            {
                strength += 0.5f * Time.deltaTime;
                strength = Mathf.Clamp(strength, 1f, 1.75f);
            }

            if (Input.GetButtonUp("Fire_P" + player) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                var wave = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                wave.GetComponent<WaveMovement>().multiplier = strength;
            }

        }
    }
}