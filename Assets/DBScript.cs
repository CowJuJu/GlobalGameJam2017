using UnityEngine;
using UnityEngine.SceneManagement;

public class DBScript : MonoBehaviour
{
    public static bool created = false;
    public float playerOneScore = 0;
    public float playerTwoScore = 0;
    public float playerThreeScore = 0;
    public float playerFourScore = 0;

    void Awake()
    {
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
