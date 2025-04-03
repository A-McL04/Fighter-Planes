using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;

    


    void Start()
    {
        // if player is alive, keep spawning enemies
        InvokeRepeating("CreateEnemyOne", 1, 2);
        InvokeRepeating("CreateEnemyTwo", 2, 3);
        
        
    }


    void CreateEnemyOne()
    {
        
        
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-10.5f, 10.5f), 6.5f, 0), Quaternion.identity);
        
        
    }

    void CreateEnemyTwo()
    {
        
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-10.5f, 10.5f), 6.5f, 0), Quaternion.identity);

        
    }

    

}