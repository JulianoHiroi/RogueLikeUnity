using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameController : MonoBehaviour
{

    public int totalScore  ;
    public Text scoreText;
    public static GameController instance;
    
    public GameObject panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText(){
        scoreText.text = totalScore.ToString();
    }

    public void GameOver(){
        panelGameOver.SetActive(true); 
    }

    public void RestartGame(string levelName){
        Debug.Log("Cliquei");
        SceneManager.LoadScene(levelName);
    }
}
