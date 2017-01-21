using UnityEngine;

public class WaveMovement : MonoBehaviour {
    public float speed;

    float strength;
    bool increasing;

    void Start()
    {
        strength = 1.0f;
        increasing = true;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void FixedUpdate()
    {
        if(increasing)
        {
            strength += 26 * Time.deltaTime;
            if(strength > 9)
            {
                strength = 9f;
                increasing = false;
            }
        }
        else
        {
            strength -= 26 * Time.deltaTime;
            if (strength < 0)
            {
                Destroy(gameObject);
            }
        }

        var color = new Color(1, 1 - (float)(strength * 0.11), 1 - (float)(strength * 0.11));
        Debug.Log(color);
        GetComponent<Renderer>().material.color = color;
    }

    public float GetStrength() { return strength; }
}