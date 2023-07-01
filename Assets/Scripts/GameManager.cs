using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text earnedGold;
    public int _earnedGold;

    public GameObject LevelPanel;

    public List<GameObject> enemyL;

    public List<GameObject> SoliderL;

    bool finished = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        enemyL = new List<GameObject>();
        _earnedGold = 0;

    }

    public int gold;

    private void FixedUpdate()
    {
        if (finished == true)
        {
            StartCoroutine(FinishedGame());
        }
    }
    IEnumerator FinishedGame()
    {
        yield return new WaitForSeconds(1);
        earnedGold.text = "Earned Gold : " + _earnedGold;

        if (enemyL.Count <= 0 || SoliderL.Count <= 0)
        {
            LevelPanel.transform.DOMoveY(500, 1);
            yield return new WaitForSeconds(1);
            if (SoliderL.Count > 0)
            {
                for (int i = 0; i < SoliderL.Count; i++)
                {
                    gold += SoliderL[i].GetComponent<Melee>().gold;
                    SoliderL[i].GetComponent<SoliderHealth>().Die();
                }
            }
            if (enemyL.Count > 0)
            {
                for (int i = 0; i < enemyL.Count; i++)
                {
                    enemyL[i].GetComponent<EnemyHealth>().Die();
                }
            }


            
        }
    }

    public void AddEnemyToList(GameObject enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemyL.Add(enemy);
        }
    }
    public void AddSoliderToList(GameObject solider)
    {
        if (solider.CompareTag("Player"))
        {
            SoliderL.Add(solider);
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if (enemyL.Contains(enemy))
        {
            enemyL.Remove(enemy);
        }
    }

    public void RemoveSoliderFromList(GameObject solider)
    {
        if (SoliderL.Contains(solider))
        {
            SoliderL.Remove(solider);
        }
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        RemoveEnemyFromList(enemy);
        Destroy(enemy);
    }

    public void SoliderDestroyed(GameObject solider)
    {
        RemoveSoliderFromList(solider);
        Destroy(solider);
    }

    public void GameFinishedControlStardet()
    {
        finished = true;
    }
    public void EnemyAttack()
    {
        foreach (var enemy in enemyL)
        {
            enemy.GetComponent<EnemyController>()._attack = true;
        }
    }
}
