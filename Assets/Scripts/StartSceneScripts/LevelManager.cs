using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int level;
    [Space]
    [Header("Gold")]
    [SerializeField]private int gold;
    [SerializeField]private int Setgold;
    [SerializeField] private Text goldText;
    [SerializeField] private int diceUpdateGold;

    [Space]
    [Header("Text")]
    public Text CurrentLevel;
    public Text NextLevelSecond;
    public Text NextLevelThree;

    [Space]
    [Header("Dice")]
    public GameObject[] dices;
    public int DicesNumber;
    public GameObject DiceUpdateButton;

    [Header("Load Options")]
    public GameObject LoadScene;
    public Image LoadingFillImage;

    private void Start()
    {
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i].SetActive(false);
        }
        dices[DicesNumber].SetActive(true);

        GetLevel();
        GetGold();
        GetDice();
    }

    private void FixedUpdate()
    {
        goldText.text = gold.ToString();

        CurrentLevel.text = level.ToString();
        NextLevelSecond.text = (level + 1).ToString();
        NextLevelThree.text = (level + 2).ToString();


        if (DicesNumber == 4)
        {
            DiceUpdateButton.SetActive(false);
        }
    }

    public void PlayGame()
    {
        StartCoroutine(LoadSceneAsync(level));
    }

    public void DiceUpdate()
    {
        if (gold >= diceUpdateGold + (DicesNumber * 100))
        {
            gold -= diceUpdateGold + (DicesNumber * 100);
            DicesNumber++;

            for (int i = 0; i < dices.Length; i++)
            {
                dices[i].SetActive(false);
            }
            dices[DicesNumber].SetActive(true);
            SetDice();
        }
        else
        {
            Debug.Log("No money");
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

    void GetLevel()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }

    void GetGold()
    {
        gold = PlayerPrefs.GetInt("gold", Setgold);
    }

    void SetGold()
    {
        PlayerPrefs.SetInt("gold", gold);
    }

    void SetDice()
    {
        PlayerPrefs.SetInt("DicesNumber", DicesNumber);
    }

    void GetDice()
    {
        DicesNumber = PlayerPrefs.GetInt("DicesNumber", DicesNumber);
    }
}
