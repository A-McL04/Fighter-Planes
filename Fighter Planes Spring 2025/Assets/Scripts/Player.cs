using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    private float playerSpeed;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;

    [SerializeField] private int _lives = 3;

    public GameObject bulletPrefab;

    private GameManager _gameManager;

    void Start()
    {
        playerSpeed = 6f;
        transform.position = new Vector3(0, -1, 0);
        

    }

    void Update()
    {
        
        CalculateMovement();
        Shooting();

    }

    void Shooting()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * playerSpeed * Time.deltaTime);
        


        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.6f, 0.5f), 0);

        if (transform.position.x >= horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit * -1, transform.position.y, 0);
        }
        else if (transform.position.x <= horizontalScreenLimit * -1)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }


    }

    // If player gets hit by enemy, lose a life. When lives reach 0, destroy player and stop enemies form spawning
    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        { 
       
            Destroy(this.gameObject);

        }

    }

}
