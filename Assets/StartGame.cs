using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    bool display = false;
    float counter = 0;
    public AudioSource BGMusic;
    public AudioSource confirm;

    public Texture2D img;

    void Start()
    {
        BGMusic.Play();
    }
    void Update()
    {
        if (Input.GetButton("Fire_P1") || Input.GetButton("Fire_P2") || Input.GetButton("Fire_P3") || Input.GetButton("Fire_P4"))
        {
            confirm.Play();
            SceneManager.LoadScene("PlayerSelect", LoadSceneMode.Single);
        }

        counter += Time.deltaTime;
        if(counter > 0.75f)
        {
            display = !display;
            counter = 0;
        }
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        myStyle.normal.textColor = Color.white;
        myStyle.alignment = TextAnchor.MiddleCenter;

        if(display) GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height * 9 / 10 - 10, 100, 20), "Press A to Begin!", myStyle);
        GUI.DrawTexture(new Rect(Screen.width/2 - 992/2, 20, 992, 300), img);
    }
}