using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    public int lives { get; private set; }
    public float time { get; private set; }
    public int coins { get; set; }

    public static string MAIN_SCENE = "Main";
    public static string GAMEOVER_SCENE = "GameOver";
    public static string WIN_SCENE = "Win";

    public GameObject[] savePoints = new GameObject[3];
    public GameObject[] magicBlocks;
    public int activeSavePointIndex = -1;
    public Vector3 restartPos = new Vector3(-58.7f, -11.14f, 0f);

    public GameObject player;

    public bool isColumnSkillOn = false;
    public bool isBombSkillOn = false;
    public bool isCameraY = false;

    public int initialLives = 1;

    public float cameraMinX = -48.5f;
    public float cameraMaxX = 1000f;
    public float cameraMinY = -49.96f;
    public float cameraMaxY = -6f;

    public bool isJumpMachine = false;

    public bool columnSkillEnhanced = false;
    public bool isBossDown = false;
    private void Awake()
    {
        lives = initialLives;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        AudioManager.instance.PlaySE("start");
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    public void SetSavePoint(Vector3 playerPos, int savePointId)
    {
        restartPos = playerPos;
        if (activeSavePointIndex >= 0)
        {
            savePoints[activeSavePointIndex].GetComponent<Animator>().SetBool("isSave", false);
        }
        activeSavePointIndex = savePointId;
        savePoints[activeSavePointIndex].GetComponent<Animator>().SetBool("isSave", true);
    }

    public void ReactivateSavePoint(int savePointId)
    {
        savePoints[activeSavePointIndex].GetComponent<Animator>().SetBool("isSave", true);
    }


    public void NewGame()
    {
        isBossDown = false;
        columnSkillEnhanced = false;
        isColumnSkillOn = false;
        isBombSkillOn = false;
        isJumpMachine = false;
        isCameraY = false;
        lives = initialLives;
        coins = 0;
        time = 0f;
        restartPos = new Vector3(-58.7f, -11.14f, 0f);
        cameraMinX = -46.7f;
        cameraMaxX = 1000f;
        cameraMinY = -49.96f;
        cameraMaxY = -6f;
        activeSavePointIndex = -1;
        SceneManager.LoadScene(MAIN_SCENE);
    }

    public void ResetGame(float delay)
    {
        Invoke(nameof(ResetGame), delay);
    }

    private void ResetGame()
    {
        lives--;
        coins = coins >= 10 ? coins - 10 : 0;
        if (lives >= 0)
        {
            SceneManager.LoadScene(MAIN_SCENE);
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(GAMEOVER_SCENE);
    }

    public void Win()
    {
        SceneManager.LoadScene(WIN_SCENE);
    }

    public void AddCoin()
    {
        coins++;
        GameObject.Find("Yuanshi_text").GetComponent<CoinUi>().UpdateCoinText();
    }

    public void AddCoins(int num)
    {
        coins += num;
        GameObject.Find("Yuanshi_text").GetComponent<CoinUi>().UpdateCoinText();
    }

    public void AddLife()
    {
        lives++;
        GameObject.Find("Life_text").GetComponent<LifeUi>().UpdateLifeText();
    }
    
}
