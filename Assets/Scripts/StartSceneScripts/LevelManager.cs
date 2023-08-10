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
    [Space]
    [Header("Fighter")]
    [SerializeField] private int m_fighterLevel;
    [SerializeField] private int m_fighterLevelGold;
    [SerializeField] private int m_fighterDamage;
    [SerializeField] private int m_fighterHealth;
    [SerializeField] private Text[] m_fighterHealthText;
    [SerializeField] private Text[] m_fighterStrengText;
    [Space]
    [Header("Wizard")]
    [SerializeField] private int m_WizardLevel;
    [SerializeField] private int m_WizardLevelGold;
    [SerializeField] private int m_WizardDamage;
    [SerializeField] private int m_WizardHealth;
    [SerializeField] private Text[] m_WizardHealthText;
    [SerializeField] private Text[] m_WizardStrengText;
    [Space]
    [Header("Thief")]
    [SerializeField] private int m_ThiefLevel;
    [SerializeField] private int m_ThiefLevelGold;
    [SerializeField] private int m_ThiefDamage;
    [SerializeField] private int m_ThiefHealth;
    [SerializeField] private Text[] m_ThiefHealthText;
    [SerializeField] private Text[] m_ThiefStrengText;

    private void Start()
    {
        GetDice();
        
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i].SetActive(false);
        }
        dices[DicesNumber].SetActive(true);

        GetLevel();
        GetGold();

        //charecter set level
        FighterSetLevel();
        WizardSetLevel();
        ThiefSetLevel();

        //charecters property text
        GetCharecterText();
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
        StartCoroutine(LoadSceneAsync(1));
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
            PlayerPrefs.SetInt("DicesNumber", DicesNumber);
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
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
    }

    void GetGold()
    {
        if (PlayerPrefs.HasKey("gold"))
        {
            gold = PlayerPrefs.GetInt("gold", Setgold);
        }
    }

    void SetGold()
    {
        PlayerPrefs.SetInt("gold", gold);
    }

    void GetDice()
    {
        if (PlayerPrefs.HasKey("DicesNumber"))
        {
            DicesNumber = PlayerPrefs.GetInt("DicesNumber");
        }
    }

    public void FighterLevelUp()
    {
        if (gold >= (m_fighterLevelGold + (m_fighterLevel * 100)))
        {
            m_fighterLevel++;

            PlayerPrefs.SetInt("m_fighterLevel", m_fighterLevel);

            gold -= m_fighterLevelGold + (m_fighterLevel * 100);
            GetCharecterText();
        }
        else
        {
            Debug.Log("No money");
        }
    }

    void FighterSetLevel()
    {
        if (PlayerPrefs.HasKey("m_fighterLevel"))
        {
            m_fighterLevel = PlayerPrefs.GetInt("m_fighterLevel");
        }
    }

    public void WizardLevelUp()
    {
        if (gold >= (m_WizardLevelGold + (m_WizardLevel * 100)))
        {
            m_WizardLevel++;
            PlayerPrefs.SetInt("m_WizardLevel", m_WizardLevel);

            gold -= m_WizardLevelGold + (m_WizardLevel * 100);
            GetCharecterText();
        }
        else
        {
            Debug.Log("No money");
        }
    }

    void WizardSetLevel()
    {
        if (PlayerPrefs.HasKey("m_WizardLevel"))
        {
            m_WizardLevel = PlayerPrefs.GetInt("m_WizardLevel");
        }
    }

    public void ThiefLevelUp()
    {
        if (gold >= (m_ThiefLevelGold + (m_ThiefLevel * 100)))
        {
            m_ThiefLevel++;
            PlayerPrefs.SetInt("m_ThiefLevel", m_ThiefLevel);

            gold -= m_ThiefLevelGold + (m_ThiefLevel * 100);
            GetCharecterText();
        }
        else
        {
            Debug.Log("No money");
        }
    }

    void ThiefSetLevel()
    {
        if (PlayerPrefs.HasKey("m_ThiefLevel"))
        {
            m_ThiefLevel = PlayerPrefs.GetInt("m_ThiefLevel");
        }
    }

    public void CharactersTextWrite(Text[] charecter_T, int property, string propert_name)
    {
        foreach (Text fighter_t in charecter_T)
        {
            fighter_t.text = $"{propert_name} : {property}";
        }
    }

    public void GetCharecterText()
    {
        //-------------------------------------figter--------------------------\\
        CharactersTextWrite(m_fighterHealthText, m_fighterHealth + (m_fighterLevel * 10), "Health");
        CharactersTextWrite(m_fighterStrengText, m_fighterDamage + (m_fighterLevel * 10), "Attack Damage");

        //-------------------------------------Wizard--------------------------\\
        CharactersTextWrite(m_WizardHealthText, m_WizardHealth + (m_WizardLevel * 10), "Health");
        CharactersTextWrite(m_WizardStrengText, m_WizardDamage + (m_WizardLevel * 10), "Attack Damage");

        //-------------------------------------Thief--------------------------\\
        CharactersTextWrite(m_ThiefHealthText, m_ThiefHealth + (m_ThiefLevel * 10), "Health");
        CharactersTextWrite(m_ThiefStrengText, m_ThiefDamage + (m_ThiefLevel * 10), "Attack Damage");
    }
}