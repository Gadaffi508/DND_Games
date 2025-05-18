using UnityEngine;

public class GetDiceObjController : MonoBehaviour
{
    [SerializeField] private GameObject[] Dice;
    [SerializeField] private int CurrentDice;

    private void Start()
    {
        getDice();

        foreach (var dice in Dice)
        {
            dice.SetActive(false);
        }
        Dice[CurrentDice].SetActive(true);
    }

    void getDice()
    {
        CurrentDice = PlayerPrefs.GetInt("DicesNumber", CurrentDice);
    }

}
