using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public GameObject ball;
    private GameObject currentBall;

    public Text WinMessage;
    private Text currentWinMessage;

    private Text leftScoreText;
    private Text rightScoreText;

    private int leftScore = 0;
    private int rightScore = 0;

    public static bool singleMode = false;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        //if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        //else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        //    Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
       // DontDestroyOnLoad(gameObject);


    }

    private void Start()
    {
        leftScoreText = GameObject.Find("UI_Canvas/LeftScore").GetComponent<Text>();
        rightScoreText = GameObject.Find("UI_Canvas/RightScore").GetComponent<Text>();

        //Call the InitGame function to initialize the first round 
        InitGame();
    }

    //Initializes the game.
    void InitGame()
    {
        StartNewGame(true);
    }

    public void StartNewGame(bool singlePlayer)
    {
        Destroy(currentWinMessage);

        singleMode = singlePlayer;
        leftScore = 0;
        rightScore = 0;
        this.leftScoreText.text = "0";
        this.rightScoreText.text = "0";
        StartNewRand();
    }

    void StartNewRand()
    {
        Destroy(currentBall);
        currentBall = Instantiate(ball);
    }

    public void AddPoint(bool leftWin)
    {
        if (leftWin)
        {
            Debug.Log("left get point");
            leftScoreText.text = (++leftScore).ToString();
        }
        else
        {
            Debug.Log("right get point");
            rightScoreText.text = (++rightScore).ToString();
        }

        int goalScore = 6;
        // if someone win
        if (leftScore == goalScore || rightScore == goalScore)
        {
            GameFinish(leftScore == goalScore);
        }
        else
        {
            StartNewRand();
        }

    }


    void GameFinish(bool leftWin)
    {
        currentWinMessage = Instantiate(WinMessage);

        currentWinMessage.transform.SetParent(GameObject.Find("UI_Canvas").transform, false);

        currentWinMessage.text = leftWin ? "Player 1 Win" : (singleMode ? "Computer Win" : "Player 2 Win");
        // currentWinMessage.text += "\n Press 'n' or 'm' to restart";

        SceneManager.LoadScene("Maze");
    }

}
