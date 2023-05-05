using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    Vector3 diceVelocity;
    public int myNumber;

    private void FixedUpdate()
    {
        //diceVelocity = DiceController.diceVelocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            switch (myNumber)
            {
                case 1:
                    DiceNumberText.diceNumber = 6;
                    break;
                case 2:
                    DiceNumberText.diceNumber = 5;
                    break;
                case 3:
                    DiceNumberText.diceNumber = 4;
                    break;
                case 4:
                    DiceNumberText.diceNumber = 3;
                    break;
                case 5:
                    DiceNumberText.diceNumber = 2;
                    break;
                case 6:
                    DiceNumberText.diceNumber = 1;
                    break;
            }
        }
    }
}
