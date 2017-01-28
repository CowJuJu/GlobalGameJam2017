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

    bool p1Ready = false;
    bool p2Ready = false;
    bool p3Ready = false;
    bool p4Ready = false;

    bool display = true;

    bool fadeOut = false;
    float fade = 0;

    public Texture2D img;
    public AudioSource audioClip;

    Texture2D fadeTexture;
    float counter = 0;

    DBScript playerData; 

    void Start()
    {
        fadeTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        playerData = GameObject.Find("Database").GetComponent<DBScript>();
        playerData.ResetScores();
        playerData.players = new List<int>();
    }

    void Update()
    {

        if (playerOneReady && playerTwoReady)
        {
            counter += Time.deltaTime;
            if (counter > 0.75f)
            {
                display = !display;
                counter = 0;
            }
            if (Input.GetButtonDown("Start"))
            {
                fadeOut = true;
            }
        }

        if (Input.GetButtonDown("Fire_P1") && !p1Ready)
        {
            PlayerJoin(1);
            p1Ready = true;
        }

        if (Input.GetButtonDown("Fire_P2") && !p2Ready)
        {
            PlayerJoin(2);
            p2Ready = true;
        }

        if (Input.GetButtonDown("Fire_P3") && !p3Ready)
        {
            PlayerJoin(3);
            p3Ready = true;
        }

        if (Input.GetButtonDown("Fire_P4") && !p4Ready)
        {
            PlayerJoin(4);
            p4Ready = true;
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

    void PlayerJoin(int joystick)
    {
        playerData.players.Add(joystick);
        audioClip.Play();
        var playerNumber = playerData.players.Count;
        switch(playerNumber)
        {
            case 1:
                playerOneReady = true;
                break;
            case 2:
                playerTwoReady = true;
                break;
            case 3:
                playerThreeReady = true;
                break;
            case 4:
                playerFourReady = true;
                break;
        }
        var player = GameObject.Find("P" + playerNumber);
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -3);
        var rigid = player.GetComponent<Rigidbody>();
        rigid.AddTorque(Vector3.up * 20);
    }

    void OnGUI()
    {
        GUI.depth = -900;
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 160;
        myStyle.normal.textColor = Color.white;
        myStyle.alignment = TextAnchor.MiddleCenter;

        GUI.color = new Color(1, 1, 1);

        //Vector3 screenPos = Camera.current.WorldToScreenPoint(GameObject.Find("P1Quad").transform.position);
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

        if (!fadeOut &&playerTwoReady && playerOneReady)
        {
            myStyle.fontSize = 80;
            if(display) GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 20, 100, 20), "Press Start to Begin!", myStyle);
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
