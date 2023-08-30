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
    [SerializeField] private Image[] m_fighterHealthImage;
    [SerializeField] private Image[] m_fighterStrengImage;
    [Space]
    [Header("Wizard")]
    [SerializeField] private int m_WizardLevel;
    [SerializeField] private int m_WizardLevelGold;
    [SerializeField] private int m_WizardDamage;
    [SerializeField] private int m_WizardHealth;
    [SerializeField] private Image[] m_WizardHealthImage;
    [SerializeField] private Image[] m_WizardStrengImage;
    [Space]
    [Header("Thief")]
    [SerializeField] private int m_ThiefLevel;
    [SerializeField] private int m_ThiefLevelGold;
    [SerializeField] private int m_ThiefDamage;
    [SerializeField] private int m_ThiefHealth;
    [SerializeField] private Image[] m_ThiefHealthImage;
    [SerializeField] private Image[] m_ThiefStrengImage;

    //Propertys
    bool open = true;
    [SerializeField] private AudioSource[] allSound;
    [SerializeField] private GameObject m_closeImage;

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
            gold -= m_fighterLevelGold + (m_fighterLevel * 100);

            m_fighterLevel++;

            PlayerPrefs.SetInt("m_fighterLevel", m_fighterLevel);
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
            gold -= m_WizardLevelGold + (m_WizardLevel * 100);
            m_WizardLevel++;

            PlayerPrefs.SetInt("m_WizardLevel", m_WizardLevel);
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
            gold -= m_ThiefLevelGold + (m_ThiefLevel * 100);

            m_ThiefLevel++;
            PlayerPrefs.SetInt("m_ThiefLevel", m_ThiefLevel);
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

    public void CharactersTextWrite(Image[] charecter_T, float property, float maxProperty)
    {
        foreach (Image fighter_t in charecter_T)
        {
            fighter_t.fillAmount = property / maxProperty;
        }
    }

    public void GetCharecterText()
    {
        //-------------------------------------figter--------------------------\\
        CharactersTextWrite(m_fighterHealthImage, m_fighterHealth + (m_fighterLevel * 10), 300);
        CharactersTextWrite(m_fighterStrengImage, m_fighterDamage + (m_fighterLevel * 10), 100);

        //-------------------------------------Wizard--------------------------\\
        CharactersTextWrite(m_WizardHealthImage, m_WizardHealth + (m_WizardLevel * 10), 300);
        CharactersTextWrite(m_WizardStrengImage, m_WizardDamage + (m_WizardLevel * 10), 100);

        //-------------------------------------Thief--------------------------\\
        CharactersTextWrite(m_ThiefHealthImage, m_ThiefHealth + (m_ThiefLevel * 10), 300);
        CharactersTextWrite(m_ThiefStrengImage, m_ThiefDamage + (m_ThiefLevel * 10), 100);
    }

    public void SoundPlay(AudioSource m_buttonClick)
    {
        if (m_buttonClick != null)
        {
            m_buttonClick.Play();
        }
    }

    public void MusýcClose()
    {
        open = !open;
        m_closeImage.SetActive(!open);
        if (open)
        {
            foreach (AudioSource sound in allSound)
            {
                sound.volume = 1;
            }
        }
        else
        {
            foreach (AudioSource sound in allSound)
            {
                sound.volume = 0;
            }
        }
    }

    public void GoldAdvert()
    {
        //advert for area

        gold += 100;
    }
}