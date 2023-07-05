using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoldierController : MonoBehaviour
{
    CellController cellController;
    public GameObject AttackCOntroller;

    public Text NoMoney;


    private void Start()
    {
        cellController = GetComponent<CellController>();
    }

    public void SpawnSoilders(GameObject solider) // all soilder spawn
    {
        GameObject soliderPos = Instantiate(solider);

        if (cellController.AddSoldier(soliderPos) && GameManager.Instance.gold >= soliderPos.GetComponent<Melee>().gold)
        {
            GameManager.Instance.gold -= soliderPos.GetComponent<Melee>().gold;
        }
        else if (GameManager.Instance.gold < soliderPos.GetComponent<Melee>().gold)
        {
            TextAnim();
            NoMoney.text = "No Money";
            Destroy(soliderPos);
        }
        else
        {
            TextAnim();
            NoMoney.text = "Cell is full";
            Destroy(soliderPos);
        }
    }

    public void TextAnim()
    {
        NoMoney.transform.DOMoveY(50, 1).OnComplete(() =>
        {
            NoMoney.transform.DOMoveY(-25, 1);
        });
    }

}
