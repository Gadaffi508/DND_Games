using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    private bool _rolling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _rolling = true;
    }

    public void Dire()
    {
        if (_rolling)
        {
            diceVelocity = rb.velocity;
            _rolling = false;
            transform.rotation = Quaternion.identity;
            DiceNumberText.diceNumber = 0;
            float dirX = Random.Range(-500, 500);
            float dirY = Random.Range(-500, 500);
            float dirZ = Random.Range(-500, 500);

            transform.position = new Vector3(0, 2, 0);

            rb.AddForce(transform.up * 300);
            rb.AddTorque(dirX, dirY, dirZ);

            
        }
    }
    public void DestroyGameObject()
    {
        _rolling = true;
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
