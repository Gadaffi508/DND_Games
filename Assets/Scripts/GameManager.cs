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
    public Text levelText;
    public GameObject LevelPanel;

    public List<GameObject> enemyL;

    public List<GameObject> SoliderL;

    bool finished = false;
    bool nextlevel = false;

    [Header("Load Options")]
    public GameObject LoadScene;
    public Image LoadingFillImage;

    public int gold;
    public bool onelevel = false;

    [Header("Design")]
    [SerializeField] private Material[] skyboxMaterials;

    [Space]
    [Header("Menu Opt�ons")]
    [SerializeField] private GameObject MenuObject;

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

        RenderSettings.skybox = skyboxMaterials[level];

        gold += level * 20;
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
                levelText.text = "Level : " + level.ToString();
                LevelPanel.SetActive(true);

            }
            yield return new WaitForSeconds(1);
            if (SoliderL.Count > 0)
            {
                for (int i = 0; i < SoliderL.Count; i++)
                {
                    gold += SoliderL[i].GetComponent<Melee>().gold;
                    SoliderL[i].GetComponent<SoliderHealth>().Die();
                    Debug.Log("Humans Win");

                    onelevel = true;
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

    bool isLoading = false;

    public void MenuLoad(int SceneId)
    {
        if (isLoading) return;
        nextlevel = true;
        isLoading = true;

        LevelPanel.SetActive(false);


        LoadScene.SetActive(true);


        SceneManager.LoadScene(SceneId);
    }

    public void SetLevel()
    {
        level++;
        Debug.Log(level);
        onelevel = false;
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

    public void MenuLoadOptions(int sceneId)
    {
        if (isLoading) return;
        MenuObject.SetActive(false);
        isLoading = true;

        LoadScene.SetActive(true);

        SceneManager.LoadScene(sceneId);
    }


    public void QuitGame()
    {
        MenuObject.SetActive(false);
        Application.Quit();
    }

    public void MovementClose(MovementController movController)
    {
        movController.enabled = false;
    }

    public void SoundPlay(AudioSource m_buttonClick)
    {
        if (m_buttonClick != null)
        {
            m_buttonClick.Play();
        }
    }
}
