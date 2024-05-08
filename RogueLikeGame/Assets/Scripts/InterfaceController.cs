using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InterfaceController : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public GameObject gameOver;

    // Update is called once per frame
    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void endGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void exitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
    public void showMessageGameOver()
    {
        gameOver.SetActive(true);
    }

    public void spawnEnemy()
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