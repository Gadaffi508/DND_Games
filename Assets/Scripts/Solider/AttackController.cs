using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Melee[] melee;
    Magic[] magic;
    GameObject[] MeleeFight;
    GameObject[] MagicFight;

    CellController cellController;

    private void Awake()
    {
        cellController = GetComponent<CellController>();
    }

    public void Attack()
    {
        MeleeFight = GameObject.FindGameObjectsWithTag("Player");
        MagicFight = GameObject.FindGameObjectsWithTag("PlayerM");

        melee = new Melee[MeleeFight.Length];
        magic = new Magic[MagicFight.Length];

        for (int j = 0; j < cellController.frontCells.Count; j++)
        {
            for (int i = 0; i < MeleeFight.Length; i++)
            {
                melee[i] = MeleeFight[i].GetComponent<Melee>();

                if (cellController.frontCells[i].CurrentSoldier != null)
                {
                    melee[i].Attack();
                }
            }
        }
        for (int i = 0; i < MagicFight.Length; i++)
        {
            magic[i] = MagicFight[i].GetComponent<Magic>();
            magic[i].Attack();
        }
    }
}
