using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Melee[] melee;
    Magic[] magic;
    GameObject[] MeleeFight;
    GameObject[] MagicFight;
    public void Attack()
    {
        MeleeFight = GameObject.FindGameObjectsWithTag("Player");
        MagicFight = GameObject.FindGameObjectsWithTag("PlayerM");

        melee = new Melee[MeleeFight.Length];
        magic = new Magic[MagicFight.Length];

        for (int i = 0; i < MeleeFight.Length; i++)
        {
            melee[i] = MeleeFight[i].GetComponent<Melee>();
            melee[i].Attack();
        }
        for (int i = 0; i < MagicFight.Length; i++)
        {
            magic[i] = MagicFight[i].GetComponent<Magic>();
            magic[i].Attack();
        }
    }
}
