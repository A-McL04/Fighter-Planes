using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    

    private float playerSpeed;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 11.0f;

    [SerializeField] private int _lives = 3;

    public GameObject bulletPrefab;
    public GameObject shieldVisualizer;

    private bool isShieldsActive = false;

    public AudioClip shieldOn;
    public AudioClip shieldOff;
    AudioSource audio;

    [SerializeField] private int _score;
    private UIManager _uiManager;

    void Start()
    {
        playerSpeed = 6f;
        transform.position = new Vector3(0, -1, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
        audio = GetComponent<AudioSource>();
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
            transform.position = new Vector3(-10.7f, transform.position.y, 0);
        }
        else if (transform.position.x <= horizontalScreenLimit * -1)
        {
            transform.position = new Vector3(10.7f, transform.position.y, 0);
        }


    }

    // If player gets hit by enemy, lose a life. When lives reach 0, destroy player
    public void Damage()
    {
        if (isShieldsActive == true)
        {
            isShieldsActive = false;
            shieldVisualizer.SetActive(false);
            audio.clip = shieldOff;
            audio.Play();
            return;
        }

        else
        {
            _lives--;

            if (_lives < 1)
            {

                Destroy(this.gameObject);

            }
        }

    }

    public void ActivateShields()
    {
        isShieldsActive = true;
        shieldVisualizer.SetActive(true);
        audio.clip = shieldOn;
        audio.Play();
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

}
