using UnityEngine;
using UnityEngine.UI;

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
            NoMoney.text = "Yer Dolu";
            Destroy(soliderPos);
        }
    }

    public void TextAnim()
    {
        
    }

}
