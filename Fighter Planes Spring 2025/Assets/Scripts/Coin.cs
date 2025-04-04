using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Player _player;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    
    void Update()
    {
        StartCoroutine(BehaviorCoroutine());
    }

    IEnumerator BehaviorCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.AddScore(1);
                Destroy(this.gameObject);
            }

        }
    }

}
