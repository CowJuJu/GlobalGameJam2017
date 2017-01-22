using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public Object ship;

    void Start()
    {
        var players = Input.GetJoystickNames();

        for (var i = 0; i < Mathf.Min(players.Length, 4); i++)
        {
            Vector3 position = new Vector3(-12, 0.3f, 12);
            Color color = Color.white;
            Quaternion rotation = new Quaternion(0, 135, 0, 0);
            switch (i)
            {
                case 0:
                    color = Color.blue; // TO-DO - Change color
                    position = new Vector3(-12, 0.3f, 12);
                    rotation.eulerAngles = new Vector3(0, 135, 0);
                    break;
                case 1:
                    color = Color.red;
                    position = new Vector3(12, 0.3f, -12);
                    rotation.eulerAngles = new Vector3(0, 315, 0);
                    break;
                case 2:
                    color = Color.yellow;
                    position = new Vector3(-12, 0.3f, -12);
                    rotation.eulerAngles = new Vector3(0, 45, 0);
                    break;
                case 3:
                    color = Color.green;
                    position = new Vector3(12, 0.3f, 12);
                    rotation.eulerAngles = new Vector3(0, 225, 0);
                    break;
            }

            var player = (GameObject)Instantiate(ship, position, rotation);
            player.GetComponent<PlayerMovement>().player = "" + (i + 1);
            player.GetComponent<PlayerWaves>().player = "" + (i + 1);



            player.transform.Find("Two Mast/Plane_001").GetComponent<Renderer>().material.color = Color.white;
            player.transform.Find("Two Mast/Plane_002").GetComponent<Renderer>().material.color = Color.white;
            player.transform.Find("Two Mast/Cylinder").GetComponent<Renderer>().material.color = color;
            player.transform.Find("Two Mast/Cylinder_001").GetComponent<Renderer>().material.color = color;
            player.transform.Find("Two Mast/Cylinder_002").GetComponent<Renderer>().material.color = color;
            player.transform.Find("Two Mast/Cylinder_003").GetComponent<Renderer>().material.color = color;
            player.transform.Find("Two Mast/Cube").GetComponent<Renderer>().material.color = color;
            player.transform.Find("Two Mast/Cone").GetComponent<Renderer>().material.color = color;
        }
    }
}
