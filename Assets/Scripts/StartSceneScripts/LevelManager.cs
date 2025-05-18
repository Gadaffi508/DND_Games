using System;
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
    [SerializeField] private Text[] CharecterUpdatePriceText;
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
    [Space]
    [Header("Wizard")]
    [SerializeField] private int m_WizardLevel;
    [SerializeField] private int m_WizardLevelGold;
    [SerializeField] private int m_WizardDamage;
    [SerializeField] private int m_WizardHealth;
    [Space]
    [Header("Thief")]
    [SerializeField] private int m_ThiefLevel;
    [SerializeField] private int m_ThiefLevelGold;
    [SerializeField] private int m_ThiefDamage;
    [SerializeField] private int m_ThiefHealth;

    //Propertys
    bool open = true;
    [SerializeField] private AudioSource[] allSound;
    [SerializeField] private GameObject m_closeImage;

    private void Start()
    {
        TextWriteChrecter(m_fighterLevelGold,m_fighterLevel);
        
        if (PlayerPrefs.HasKey("open"))
        {
            open = Convert.ToBoolean(PlayerPrefs.GetInt("open"));
            MusicLoad();
        }

        GetDice();

        for (int i = 0; i < dices.Length; i++)
        {
            
        }

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
            
        }
    }

    bool isLoading = false;

    public void PlayGame()
    {
        if (isLoading) return;

        isLoading = true;
        LoadScene.SetActive(true);

        SceneManager.LoadScene(1);
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
        if (gold >= (m_fighterLevelGold + (m_fighterLevel * 500)))
        {
            gold -= m_fighterLevelGold + (m_fighterLevel * 500);

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
        if (gold >= (m_WizardLevelGold + (m_WizardLevel * 500)))
        {
            gold -= m_WizardLevelGold + (m_WizardLevel * 500);
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
        if (gold >= (m_ThiefLevelGold + (m_ThiefLevel * 500)))
        {
            gold -= m_ThiefLevelGold + (m_ThiefLevel * 500);

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
    }

    public void SoundPlay(AudioSource m_buttonClick)
    {
        m_buttonClick?.Play();
    }

    public void MusicClose()
    {
        open = !open;
        m_closeImage.SetActive(!open);
        PlayerPrefs.SetInt("open",Convert.ToInt32(open));
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

    void MusicLoad()
    {
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WritePriceChrecter(int SelectCharecter)
    {
        switch (SelectCharecter)
        {
            case 1:
                TextWriteChrecter(m_ThiefLevelGold,m_ThiefLevel);
                break;
            case 2:
                TextWriteChrecter(m_WizardLevelGold,m_WizardLevel);
                break;
            case 3:
                TextWriteChrecter(m_fighterLevelGold,m_fighterLevel);
                break;
        }
    }

    private void TextWriteChrecter(float Gold,float Level)
    {
        foreach (Text charecterUpdate in CharecterUpdatePriceText)
        {
            
        }
    }
}