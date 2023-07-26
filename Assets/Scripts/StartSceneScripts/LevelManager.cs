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
    }

    private void FixedUpdate()
    {
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
        DicesNumber++;

        for (int i = 0; i < dices.Length; i++)
        {
            dices[i].SetActive(false);
        }
        dices[DicesNumber].SetActive(true);
    }

    IEnumerator LoadSceneAsync(int SceneId)
    {
        LoadScene.SetActive(true);

        yield return new WaitForEndOfFrame();

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);

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
}
