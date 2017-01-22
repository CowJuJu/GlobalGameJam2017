using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string player;
    public float maxSpeed = 0.3f;
    public bool canMove;

    Vector3 velocity;
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

        Rotate(h, v);
        if (canMove)
        {
            Move(h, v);
        }
    }

    void Move(float h, float v)
    {
        var direction = new Vector3(h, 0.0f, v);
        var force = direction.normalized * maxSpeed * Time.deltaTime;

        Vector3 movement = new Vector3(h, 0.0f, v);
        playerRigidbody.AddForce(force);
    }

    void Rotate(float h, float v)
    {
        if (h == 0 && v == 0)
        {
        }
        else
        {
            playerRigidbody.transform.eulerAngles = new Vector3(playerRigidbody.transform.eulerAngles.x, Mathf.Atan2(h, v) * Mathf.Rad2Deg, playerRigidbody.transform.eulerAngles.z);
        }
    }
}
