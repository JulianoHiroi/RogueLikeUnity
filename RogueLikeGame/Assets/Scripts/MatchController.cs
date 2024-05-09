using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class MatchController : MonoBehaviour
{
    public GameObject enemyPrefab;
    private static Enemy[] enemies = new Enemy[5];

    // Start is called before the first frame update

    void Start()
    {
        SpawnEnemy();
    }
    public static Enemy createEnemy()
    {
        Enemy newEnemy = new Enemy(5, 0, 2);
        enemies.SetValue(newEnemy, 0);
        return newEnemy;
    }
    public static Enemy[] getEnemies()
    {
        return enemies;
    }
    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Instancia o GameObject na posição (0, 0, 0) com a rotação padrão.
            GameObject newObject = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);

            // Você pode fazer mais operações com o novo GameObject, se necessário.
        }
        else
        {
            Debug.LogError("Prefab não atribuído! Por favor, atribua um prefab no Inspector.");
        }
    }


}