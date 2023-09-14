using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broom : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
            transform.position.y,
            transform.position.z
            );

        if (transform.position.x < 450) speed = -2;
        else if (transform.position.x > 460) speed = 2;
        
    }
}
