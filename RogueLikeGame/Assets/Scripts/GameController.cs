using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static Hero hero = new Hero(5, 0, 0);

    private static Enemy enemy = new Enemy(10,10,5);
    public static GameController instance;
    // Start is called before the first frame update
    public static Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();
    public GameObject prefabToInstantiate;
    public GameObject gameOver;
    void Start()
    {
        instance = this;
        InvokeRepeating("SpawnEnemy", 2, 3);

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
    public static Enemy GetEnemy()
    {
        return enemy;
    }
    public static void CreateEnemy(string id)
    {
        enemies.Add(id, new Enemy(10, 10, 3));
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void SpawnEnemy()
    {
        if (prefabToInstantiate != null)
        {
            // Instancia o GameObject na posição (0, 0, 0) com a rotação padrão.
            GameObject newObject = Instantiate(prefabToInstantiate, Vector3.zero, Quaternion.identity);

            // Você pode fazer mais operações com o novo GameObject, se necessário.
        }
        else
        {
            Debug.LogError("Prefab não atribuído! Por favor, atribua um prefab no Inspector.");
        }
    }
}
