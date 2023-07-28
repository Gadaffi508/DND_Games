using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int level;
    [Space]
    [Header("Gold")]
    [SerializeField] private int gold;
    [SerializeField] private int Setgold;
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

    [Space]
    [Header("Charecter Level")]
    [SerializeField] private int fighterLevel;
    [SerializeField] private int fighterLevelGold;
    [SerializeField] private int WizardLevel;
    [SerializeField] private int WizardLevelGold;
    [SerializeField] private int ThiefLevel;
    [SerializeField] private int ThiefLevelGold;

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

        //charecter set level
        FighterSetLevel();
        WizardSetLevel();
        ThiefSetLevel();
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

    public void FighterLevelUp()
    {
        if (gold >= fighterLevelGold + (fighterLevel * 100))
        {
            fighterLevel++;
            fighterLevel = PlayerPrefs.GetInt("fighterLevel", 1);

            gold -= fighterLevelGold + (fighterLevel * 100);

            Debug.Log(fighterLevel);
        }
        else
        {
            Debug.Log("No money");
        }
    }

    void FighterSetLevel()
    {
        PlayerPrefs.SetInt("fighterLevel", fighterLevel);
    }

    public void WizardLevelUp()
    {
        if (gold >= WizardLevelGold + (WizardLevel * 100))
        {
            WizardLevel++;
            WizardLevel = PlayerPrefs.GetInt("WizardLevel", 1);

            gold -= WizardLevelGold + (WizardLevel * 100);  
        }
        else
        {
            Debug.Log("No money");
        }
    }

    void WizardSetLevel()
    {
        PlayerPrefs.SetInt("WizardLevel", WizardLevel);
    }

    public void ThiefLevelUp()
    {
        if (gold >= ThiefLevelGold + (ThiefLevel * 100))
        {
            ThiefLevel++;
            ThiefLevel = PlayerPrefs.GetInt("ThiefLevel", 1);

            gold -= ThiefLevelGold + (ThiefLevel * 100);
        }
        else
        {
            Debug.Log("No money");
        }
    }

    void ThiefSetLevel()
    {
        PlayerPrefs.SetInt("ThiefLevel", ThiefLevel);
    }
}
