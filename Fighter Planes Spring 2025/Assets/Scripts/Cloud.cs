using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _randomScale;
    
    void Awake()
    {
        _randomScale = Random.Range(0.25f, 0.75f);
        transform.localScale = transform.localScale * _randomScale;
    }
    
    void Update()
    {
        CloudMovement();
    }

    void CloudMovement()
    {

        if (_randomScale >= 0.6f)
        {
            transform.Translate(new Vector3(0, -0.75f, 0) * Time.deltaTime * 3f);
        }
        else if (_randomScale <= 0.4f)
        {
            transform.Translate(new Vector3(0, -0.25f, 0) * Time.deltaTime * 3f);
        }
        else
        {
            transform.Translate(new Vector3(0, -0.5f, 0) * Time.deltaTime * 3f);
        }
       


        if (transform.position.y < -6.5f)
        {
            transform.position = new Vector3(Random.Range(-10.5f, 10.5f), 6.5f * 1.2f, 0);
        }
    }

}
