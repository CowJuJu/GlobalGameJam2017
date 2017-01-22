using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool poweredUp = false;
    public float powerTime = 10;
    public string player;
    public float maxSpeed = 0.3f;
    public bool isAlive = true;
    public AudioSource death;

    Vector3 velocity;
    Rigidbody playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isAlive && !GameObject.Find("LevelManager").GetComponent<Level>().preventMovement)
        {
            var horizontal = "Horizontal_P" + player;
            var vertical = "Vertical_P" + player;
            float h = Input.GetAxisRaw(horizontal);
            float v = Input.GetAxisRaw(vertical);

            Rotate(h, v);
            if (!Input.GetButton("Fire_P" + player))
            {
                Move(h, v);
            }
        }
    }

    void Move(float h, float v)
    {
        if(poweredUp)
        {
            powerTime -= Time.deltaTime;
            if(powerTime < 0)
            {
                playerRigidbody.mass = 1;
                transform.localScale = new Vector3(1f, 1f, 1f);
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                poweredUp = false;
            }
        }
        var direction = new Vector3(h, 0.0f, v);
        var force = direction.normalized * maxSpeed * Time.deltaTime;
        playerRigidbody.AddForce(force);

        RaycastHit hit;
        Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, -1, 0), out hit);
        if(hit.collider == null)
        {
            playerRigidbody.useGravity = true;
            playerRigidbody.constraints = RigidbodyConstraints.None;
            isAlive = false;
            death.Play();
        }
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
