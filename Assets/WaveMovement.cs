using UnityEngine;

public class WaveMovement : MonoBehaviour {
    public float speed;
    public float multiplier;

    float strength;
    bool increasing;

    void Start()
    {
        strength = 1f;
        increasing = true;
        GetComponent<Rigidbody>().velocity = transform.forward * speed * multiplier;
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

        var color = new Color(0.2f + (float)(strength * 0.11), 0.2f + (float)(strength * 0.11), 1);
        GetComponent<Renderer>().material.color = color;
        var model = transform.Find("Model");
        model.GetComponent<Renderer>().material.color = color;
        model.transform.localScale = new Vector3(model.transform.localScale.x, 0.3f + strength * 0.05f, 0.5f + strength * 0.25f);


    }

    public float GetStrength() { return strength; }
}