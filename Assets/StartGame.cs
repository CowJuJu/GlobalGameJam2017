using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire_P2"))
        {
            SceneManager.LoadScene("InGame", LoadSceneMode.Single);
        }
    }
}