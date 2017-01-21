using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string player;

    float speed = 6f;
    Vector3 movement;
    Rigidbody playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        var horizontal = "Horizontal_P" + player;
        var vertical = "Vertical_P" + player;
        float h = Input.GetAxisRaw(horizontal);
        float v = Input.GetAxisRaw(vertical);

        if(Input.GetAxisRaw(horizontal) > 0)
        {
            //Debug.Log(Input.GetAxisRaw(horizontal));
        }

        if (Input.GetButton("Button 1"))
        {
            Debug.Log(player);
        }

        Move(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }
}
