using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberText : MonoBehaviour
{
    Text text;
    public static int diceNumber;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = diceNumber.ToString();
    }
    public void RetryDice()
    {
        GameManager.Instance.gold -= 100;
    }
}
