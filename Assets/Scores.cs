using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("P1").GetComponent<Rigidbody>().AddTorque(Vector3.up * 20);
        GameObject.Find("P2").GetComponent<Rigidbody>().AddTorque(Vector3.up * 20);
        GameObject.Find("P3").GetComponent<Rigidbody>().AddTorque(Vector3.up * 20);
        GameObject.Find("P4").GetComponent<Rigidbody>().AddTorque(Vector3.up * 20);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetButtonDown("Fire_P3") || Input.GetButtonDown("Fire_P4"))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }

    void OnGUI()
    {
        GUI.depth = -900;
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 160;
        myStyle.normal.textColor = Color.white;
        myStyle.alignment = TextAnchor.MiddleCenter;

        var scores = GameObject.Find("Database").GetComponent<DBScript>();

        GUI.Label(new Rect(Screen.width / 8 - 50, Screen.height / 4 - 50, 100, 20), "" + scores.playerOneScore, myStyle);
        GUI.Label(new Rect(Screen.width * 3 / 8 - 50, Screen.height / 4 - 50, 100, 20), "" + scores.playerTwoScore, myStyle);
        GUI.Label(new Rect(Screen.width * 5 / 8 - 50, Screen.height / 4 - 50, 100, 20), "" + scores.playerThreeScore, myStyle);
        GUI.Label(new Rect(Screen.width * 7 / 8 - 50, Screen.height / 4 - 50, 100, 20), "" + scores.playerFourScore, myStyle);
    }
}