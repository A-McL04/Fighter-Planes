using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float EnemyTwoX;

    private Player _player;
    
    void Awake()
    {
        // Each time Enemy 2 spawns, the horizontal velocity will be different
        EnemyTwoX = Random.Range(-0.5f, 0.5f);
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
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -6.5f)
        {
           Destroy(this.gameObject);
        }
    }

    void EnemyTwoMovement()
    {
        // Enemy 2 will move vertically just like enemy one, but will also move horizontally based on the value of EnemyTwoX
        transform.Translate(new Vector3(EnemyTwoX, -1, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
            
    }

    private void OnTriggerEnter(Collider other)
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
