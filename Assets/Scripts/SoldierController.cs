using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoldierController : MonoBehaviour
{
    CellController cellController;

    public GameObject soldierPrefabs;
    public GameObject MagicPrefabs;
    public GameObject soldierPrefabsTwo;
    public GameObject SlimePrefab;
    public GameObject AttackCOntroller;

    public Text NoMoney;


    private void Start()
    {
        cellController = GetComponent<CellController>();
    }

    public void SpawnSoldier()
    {

        GameObject soldier = Instantiate(soldierPrefabs);

        if (cellController.AddSoldier(soldier) && GameManager.Instance.gold >= 100)
        {
            GameManager.Instance.gold -= 100;
        }
        else if (GameManager.Instance.gold < 100)
        {
            TextAnim();
            NoMoney.text = "No Money";
            Destroy(soldier);
        }
        else
        {
            TextAnim();
            NoMoney.text = "Cell is full";
            Destroy(soldier);
        }
    }

    public void SpawnSoldierTwo()
    {

        GameObject soldier = Instantiate(soldierPrefabsTwo);

        if (cellController.AddSoldier(soldier) && GameManager.Instance.gold >= 90)
        {
            GameManager.Instance.gold -= 90;
        }
        else if (GameManager.Instance.gold < 90)
        {
            TextAnim();
            NoMoney.text = "No Money";
            Destroy(soldier);
        }
        else
        {
            TextAnim();
            NoMoney.text = "Cell is full";
            Destroy(soldier);
        }
    }

    public void SliderSpawn()
    {

        GameObject soldier = Instantiate(SlimePrefab);

        if (cellController.AddSoldier(soldier) && GameManager.Instance.gold >= 150)
        {
            GameManager.Instance.gold -= 150;
        }
        else if (GameManager.Instance.gold < 150)
        {
            TextAnim();
            NoMoney.text = "No Money";
            Destroy(soldier);
        }
        else
        {
            TextAnim();
            NoMoney.text = "Cell is full";
            Destroy(soldier);
        }
    }

    public void SpawnMagic()
    {

        GameObject Magic = Instantiate(MagicPrefabs);

        if (cellController.AddSoldier(Magic) && GameManager.Instance.gold >= 200)
        {
            GameManager.Instance.gold -= 200;
        }
        else if (GameManager.Instance.gold < 200)
        {
            TextAnim();
            NoMoney.text = "No Money";
            Destroy(Magic);
        }
        else
        {
            TextAnim();
            NoMoney.text = "Cell is full";
            Destroy(Magic);
        }
    }
    public void SetActiveAttackController()
    {
        AttackCOntroller.SetActive(true);
    }
    public void TextAnim()
    {
        NoMoney.transform.DOMoveY(50, 1).OnComplete(() =>
        {
            NoMoney.transform.DOMoveY(-25, 1);
        });
    }

}
