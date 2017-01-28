using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DBScript : MonoBehaviour
{
    public static bool created = false;
    public float playerOneScore = 0;
    public float playerTwoScore = 0;
    public float playerThreeScore = 0;
    public float playerFourScore = 0;

    public List<int> players;

    void Awake()
    {
        players = new List<int>();

        ResetScores();
        if(created)
        {
            Destroy(gameObject);
        }
        else
        {
            created = true;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResetScores()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        playerThreeScore = 0;
        playerFourScore = 0;
    }
}
