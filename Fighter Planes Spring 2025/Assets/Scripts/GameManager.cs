using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject coinPrefab;
    public GameObject cloudPrefab;
    public GameObject powerUpPrefab;

    


    void Start()
    {
        // if player is alive, keep spawning enemies
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 3);
        InvokeRepeating("CreateCoin", 10, 10);
        InvokeRepeating("CreatePowerUp", 15, 25);

        CreateSky();
        
        
    }


    void CreateEnemyOne()
    {
        
        
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-10.5f, 10.5f), 6.5f, 0), Quaternion.identity);
        
        
    }

    void CreateEnemyTwo()
    {
        
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-10.5f, 10.5f), 6.5f, 0), Quaternion.identity);

        
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-10.5f, 10.5f), Random.Range(-3.5f, 0.2f), 0), Quaternion.identity);
    }

    void CreatePowerUp()
    {
        Instantiate(powerUpPrefab, new Vector3(Random.Range(-10.5f, 10.5f), Random.Range(-3.5f, 0.2f), 0), Quaternion.identity);
    }   

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-10.5f, 10.5f), Random.Range(-2.5f, 6.5f), 0), Quaternion.identity);
        }

    }

}