using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float EnemyTwoRotate;

    private Player _player;
    
    void Awake()
    {
        // Each time Enemy 2 spawns, the rotation will be different
        EnemyTwoRotate = Random.Range(160.0f, 200.0f);

        if (gameObject.tag == "EnemyOne")
        {
            transform.Rotate(0.0f, 0.0f, 180f, Space.World);
        }
        else if (gameObject.tag == "EnemyTwo")
        {
            transform.Rotate(0.0f, 0.0f, EnemyTwoRotate, Space.World);
        }
        
    }

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (gameObject.tag == "EnemyOne")
        {
            EnemyOneMovement();
        }
        else if (gameObject.tag == "EnemyTwo")
        {
            EnemyTwoMovement();
        }
       
    }

    void EnemyOneMovement()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 3f);

        if (transform.position.y < -6.5f)
        {
           Destroy(this.gameObject);
        }
    }

    void EnemyTwoMovement()
    {
        // Enemy 2 will move faster than enemy one and will have a random rotation each time it spawns in
        transform.Translate(new Vector3(0, 2f, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);

        }

        if (other.tag == "Bullet")
        {
            if (_player != null)
            {
                _player.AddScore(10);
            }

            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }

    }

}
