using System.Collections;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    private DiceController DiceObj;
    [SerializeField] private int Get_DiceNumber;
    private void Start()
    {
        DiceObj = GameObject.FindGameObjectWithTag("Dice").gameObject.GetComponent<DiceController>();
    }

    public void DiceNumber()
    {
        DiceObj.gameObject.SetActive(true);
        DiceObj._rolling = true;
        StartCoroutine(DiceCheck());
    }

    IEnumerator DiceCheck()
    {
        yield return new WaitForSeconds(2);
        DiceObj.gameObject.SetActive(false);
        Get_DiceNumber = Random.Range(1, DiceObj.DiceCount);
        DiceNumberText.diceNumber = Get_DiceNumber;
    }


}
