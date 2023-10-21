using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoldierController : MonoBehaviour
{
    CellController cellController;
    public Text NoMoney;

    public int soilderC;

    private void Start()
    {
        cellController = GetComponent<CellController>();
    }

    public void SpawnSoilders(GameObject Soldier) // all soilder spawn
    {
        GameObject soliderPos = Instantiate(Soldier);

        soilderC++;

        if (cellController.AddSoldier(soliderPos) && GameManager.Instance.gold >= soliderPos.GetComponent<Melee>().gold)
        {
            GameManager.Instance.gold -= soliderPos.GetComponent<Melee>().gold;
        }
        else if (GameManager.Instance.gold < soliderPos.GetComponent<Melee>().gold)
        {
            TextAnim();
            NoMoney.text = "Para Yok";
            Destroy(soliderPos);
        }
        else
        {
            TextAnim();
            NoMoney.text = "Hücreler Dolu";
            Destroy(soliderPos);
        }
    }

    public void TextAnim()
    {
        NoMoney.transform.DOMoveY(60, 1).OnComplete(() =>
        {
            NoMoney.transform.DOMoveY(-70, 1);
        });
    }

}
