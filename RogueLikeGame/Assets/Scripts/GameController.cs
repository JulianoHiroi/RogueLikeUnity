using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private static Hero hero = new Hero(5, 0, 0);
    public static GameController instance;
    public GameObject gameOver;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void startGame()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene("World_1");
    }
    public void endGame()
    {
        Debug.Log("Game Ended");
        SceneManager.LoadScene("MainMenu");
    }
    public void exitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
    public static Hero getHero()
    {
        return hero;
    }


    public void GameOver()
    {
        gameOver.SetActive(true);

    }
}
