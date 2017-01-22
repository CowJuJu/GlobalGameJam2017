﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public bool preventMovement = true;

    bool fadeIn = true;
    bool fadeOut = false;
    bool winPhase = false;

    float fade = .9f;

    float timer = 4;

    Texture2D texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);

    void Start()
    {
        texture.SetPixel(0, 0, new Color(0, 0, 0));
    }
    

    void Update ()
    {
        if (!fadeIn && !fadeOut && !winPhase)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer < 1)
                {
                    preventMovement = false;
                }
            }

            var ships = GameObject.FindGameObjectsWithTag("Ship");
            var alive = 0;
            foreach (var ship in ships)
            {
                if (ship.GetComponent<PlayerMovement>().isAlive)
                {
                    alive++;
                }
            }
            if (alive == 1)
            {
                preventMovement = true;
                foreach (var ship in ships)
                {
                    if (ship.GetComponent<PlayerMovement>().isAlive)
                    {
                        switch (ship.GetComponent<PlayerMovement>().player)
                        {
                            case "1":
                                GameObject.Find("Database").GetComponent<DBScript>().playerOneScore++;
                                break;
                            case "2":
                                GameObject.Find("Database").GetComponent<DBScript>().playerTwoScore++;
                                break;
                            case "3":
                                GameObject.Find("Database").GetComponent<DBScript>().playerThreeScore++;
                                break;
                            case "4":
                                GameObject.Find("Database").GetComponent<DBScript>().playerFourScore++;
                                break;
                        }
                    }
                }
                winPhase = true;
            }
        }
        else
        {
            if(fadeIn)
            {
                fade -= Time.deltaTime / 2;
                if(fade < 0)
                {
                    fade = 0;
                    fadeIn = false;
                }
            }
            else if(winPhase)
            {
                timer += Time.deltaTime;
                if(timer > 2)
                {
                    winPhase = false;
                    fadeOut = true;
                }
            }
            else
            {
                fade += Time.deltaTime / 2;
                if (fade > 1)
                {
                    fade = 1;

                    switch(SceneManager.GetActiveScene().name)
                    {
                        case "LevelOne":
                            SceneManager.LoadScene("LevelTwo");
                            break;
                        case "LevelTwo":
                            SceneManager.LoadScene("LevelThree");
                            break;
                        case "LevelThree":
                            SceneManager.LoadScene("LevelFour");
                            break;
                        case "LevelFour":
                            SceneManager.LoadScene("LevelFive");
                            break;
                        case "LevelFive":
                            SceneManager.LoadScene("Menu");
                            break;
                    }
                }
            }
        }
	}

    void OnGUI()
    {

        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 160;
        myStyle.normal.textColor = Color.white;

        myStyle.alignment = TextAnchor.MiddleCenter;

        if (!fadeIn && !fadeOut && !winPhase)
        {
            switch ((int)Mathf.Floor(timer))
            {
                case 3:
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 20), "3", myStyle);
                    break;
                case 2:
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 20), "2", myStyle);
                    break;
                case 1:
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 20), "1", myStyle);
                    break;
                case 0:
                    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 20), "GO!", myStyle);
                    break;
            }
        }
        else
        {
            GUI.color = new Color(0, 0, 0, fade);
            GUI.depth = -1000;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }
    }
}