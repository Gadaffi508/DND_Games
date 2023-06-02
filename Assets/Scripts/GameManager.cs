using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    }

    public int gold;

    public int maxFrontSoldierCount = 3;

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

        if (enemyL.Count <= 0 || SoliderL.Count <= 0)
        {
            LevelPanel.transform.DOMoveY(500, 1);
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
}
