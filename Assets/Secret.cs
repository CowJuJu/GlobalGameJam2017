using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour
{
    public AudioSource krakenSummon;
    public AudioSource krakenScream;
    bool activate = false;
    float time = 0;

    float whirlpoolscale = 3;
    float tentacleHeight = -11;

    void FixedUpdate()
    {
        if (!activate)
        {
            time += Time.deltaTime;
            if (time > 16)
            {
                krakenSummon.Play();
                krakenScream.Play();
                activate = true;
            }
        }
        else
        {
            var whirlpool = GameObject.Find("Whirlpool");
            var tentacle = GameObject.Find("Tentacle");

            whirlpoolscale += Time.deltaTime * 1.2f;
            whirlpoolscale = Mathf.Min(whirlpoolscale, 12);
            whirlpool.transform.localScale = new Vector3(whirlpoolscale, 1, whirlpoolscale);

            tentacleHeight += Time.deltaTime * 1.7f;
            tentacleHeight = Mathf.Min(tentacleHeight, 0);
            tentacle.transform.position = new Vector3(0, tentacleHeight, 0);
        }
    }
}