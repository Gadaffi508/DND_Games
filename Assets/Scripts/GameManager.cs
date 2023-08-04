using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level;
    public Text earnedGold;
    public int _earnedGold;

    public GameObject LevelPanel;

    public List<GameObject> enemyL;

    public List<GameObject> SoliderL;

    bool finished = false;
    bool nextlevel = false;

    [Header("Load Options")]
    public GameObject LoadScene;
    public Image LoadingFillImage;

    public int gold;
    bool onelevel = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        enemyL = new List<GameObject>();
        _earnedGold = 0;
        GetGold();
        GetLevel();

        Debug.Log(level);
    }


    private void FixedUpdate()
    {
        if (finished == true && nextlevel == false)
        {
            StartCoroutine(FinishedGame());
        }
    }
    IEnumerator FinishedGame()
    {
        yield return new WaitForSeconds(1);
        earnedGold.text = _earnedGold.ToString();
        if (enemyL.Count <= 0 || SoliderL.Count <= 0)
        {
            yield return new WaitForSeconds(1.2f);
            if (nextlevel == false)
            {
                LevelPanel.SetActive(true);

            }
            yield return new WaitForSeconds(1);
            if (SoliderL.Count > 0)
            {
                for (int i = 0; i < SoliderL.Count; i++)
                {
                    gold += SoliderL[i].GetComponent<Melee>().gold;
                    SoliderL[i].GetComponent<SoliderHealth>().Die();
                    onelevel = true;
                    Debug.Log("Humans Win");
                    SetLevel();
                }
            }
            if (enemyL.Count > 0)
            {
                for (int i = 0; i < enemyL.Count; i++)
                {
                    enemyL[i].GetComponent<EnemyHealth>().Die();

                    Debug.Log("Monster Win");
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

    public void MenuLoad(int Scene›d)
    {
        nextlevel = true;
        LevelPanel.SetActive(false);
        StartCoroutine(LoadSceneAsync(Scene›d));
    }

    public void SetLevel()
    {
        if (onelevel)
        {
            level++;
            Debug.Log(level);
            onelevel = false;
        }
        PlayerPrefs.SetInt("level", level);
    }

    void GetLevel()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
    }

    void SetGold()
    {
        PlayerPrefs.SetInt("gold", gold);
    }

    void GetGold()
    {
        if (PlayerPrefs.HasKey("gold"))
        {
            gold = PlayerPrefs.GetInt("gold");
        }
    }

    IEnumerator LoadSceneAsync(int SceneId)
    {
        LoadScene.SetActive(true);

        yield return new WaitForEndOfFrame();

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);

        SetGold();

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingFillImage.fillAmount = progressValue;

            yield return null;
        }
    }
}
