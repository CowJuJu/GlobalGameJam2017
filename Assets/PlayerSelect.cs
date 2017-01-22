using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    bool playerOneReady = false;
    bool playerTwoReady = false;
    bool playerThreeReady = false;
    bool playerFourReady = false;

    bool display = true;

    bool fadeOut = false;
    float fade = 0;

    public Texture2D img;

    Texture2D fadeTexture;
    float counter = 0;

    void Start()
    {
        fadeTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
    }

    void Update()
    {

        if (playerOneReady && playerTwoReady && playerThreeReady && playerFourReady)
        {
            counter += Time.deltaTime;
            if (counter > 0.75f)
            {
                display = !display;
                counter = 0;
            }
            if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetButtonDown("Fire_P3") || Input.GetButtonDown("Fire_P4"))
            {
                fadeOut = true;
            }
        }

        if (Input.GetButtonDown("Fire_P1") && !playerOneReady)
        {
            playerOneReady = true;
            var p1 = GameObject.Find("P1");
            p1.transform.position = new Vector3(p1.transform.position.x, p1.transform.position.y, -3);
            var rigid = p1.GetComponent<Rigidbody>();
            rigid.AddTorque(Vector3.up * 20);
        }

        if (Input.GetButtonDown("Fire_P2") && !playerTwoReady)
        {
            playerTwoReady = true;
            var p2 = GameObject.Find("P2");
            p2.transform.position = new Vector3(p2.transform.position.x, p2.transform.position.y, -3);
            var rigid = p2.GetComponent<Rigidbody>();
            rigid.AddTorque(Vector3.up * 20);
        }

        if (Input.GetButtonDown("Fire_P3") && !playerThreeReady)
        {
            playerThreeReady = true;
            var p3 = GameObject.Find("P3");
            p3.transform.position = new Vector3(p3.transform.position.x, p3.transform.position.y, -3);
            var rigid = p3.GetComponent<Rigidbody>();
            rigid.AddTorque(Vector3.up * 20);
        }

        if (Input.GetButtonDown("Fire_P4") && !playerFourReady)
        {
            playerFourReady = true;
            var p4 = GameObject.Find("P4");
            p4.transform.position = new Vector3(p4.transform.position.x, p4.transform.position.y, -3);
            var rigid = p4.GetComponent<Rigidbody>();
            rigid.AddTorque(Vector3.up * 20);
        }

        if (fadeOut)
        {
            fade += Time.deltaTime / 2;
            if (fade > 1)
            {
                SceneManager.LoadScene("LevelOne");
            }
        }
    }

    void OnGUI()
    {
        GUI.depth = -900;
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 160;
        myStyle.normal.textColor = Color.white;
        myStyle.alignment = TextAnchor.MiddleCenter;

        GUI.color = new Color(1, 1, 1);

        Vector3 screenPos = Camera.current.WorldToScreenPoint(GameObject.Find("P1Quad").transform.position);
        if (!playerOneReady) GUI.DrawTexture(new Rect(Screen.width / 4 - 32, Screen.height / 4 - 32, 64, 64), img);
        else
        {
            GUI.Label(new Rect(Screen.width / 4 - 50, Screen.height / 4 - 50, 100, 20), "Ready!", myStyle);
        }
        if (!playerFourReady) GUI.DrawTexture(new Rect(Screen.width * 3 / 4 - 32, Screen.height / 4 - 32, 64, 64), img);
        else
        {
            GUI.Label(new Rect(Screen.width * 3 / 4 - 50, Screen.height / 4 - 50, 100, 20), "Ready!", myStyle);
        }
        if (!playerThreeReady) GUI.DrawTexture(new Rect(Screen.width / 4 - 32, Screen.height * 3 / 4 - 32, 64, 64), img);
        else
        {
            GUI.Label(new Rect(Screen.width / 4 - 50, Screen.height * 3 / 4 - 50, 100, 20), "Ready!", myStyle);
        }
        if (!playerTwoReady) GUI.DrawTexture(new Rect(Screen.width * 3 / 4 - 32, Screen.height * 3 / 4 - 32, 64, 64), img);
        else
        {
            GUI.Label(new Rect(Screen.width * 3 / 4 - 50, Screen.height * 3 / 4 - 50, 100, 20), "Ready!", myStyle);
        }

        if (!fadeOut && playerFourReady && playerThreeReady && playerTwoReady && playerOneReady)
        {
            myStyle.fontSize = 80;
            if(display) GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 20, 100, 20), "Press A to Begin!", myStyle);
        }

        if(fadeOut)
        {
            GUI.color = new Color(0, 0, 0, fade);
            GUI.depth = -1000;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }
}
