using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject _spawnButtonFighter;
    public GameObject _spawnButtonWizard;
    public GameObject _spawnButtonThief;
    public GameObject SpawnBG;
    public GameObject _attackButton;
    public GameObject _direButton;
    public GameObject _direRetry;
    public Text TimeText;
    public float _Time = 5;
    public Text goldText;
    public Image goldImage;
    public GameObject dire;
    public bool startRetyTime = false;

    private void Start()
    {
        _attackButton.SetActive(false);
        _direRetry.SetActive(false);
        goldImage.gameObject.SetActive(false);
    }
    public void ButtonActive()
    {
        StartCoroutine(DelayAcitve());
    }
    public void AttackButtonActive()
    {
        StartCoroutine(DelayAcitveAttackButton());
    }
    IEnumerator DelayAcitve()
    {
        _direRetry.SetActive(true);
        yield return new WaitForSeconds(2);
        _spawnButtonFighter.transform.DOMoveY(400, 1);
        _spawnButtonWizard.transform.DOMoveY(400, 1);
        _spawnButtonThief.transform.DOMoveY(400, 1);
        _direButton.transform.DOMoveX(-80, 1);
        _direRetry.transform.DOMoveX(120, 1);
        startRetyTime = true;
        yield return new WaitForSeconds(1);
        goldImage.gameObject.SetActive(true);
        goldImage.transform.DOMoveY(840, 1);
    }
    IEnumerator DelayAcitveAttackButton()
    {
        _attackButton.transform.DOMoveY(760, 1);
        yield return new WaitForSeconds(2);
        _attackButton.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (startRetyTime)
        {
            goldText.text = "Gold : " + GameManager.Instance.gold.ToString();
            _Time -= Time.deltaTime;
            TimeText.text = "Time : " + _Time.ToString("0");
            if (_Time <= 0)
            {
                BackRetry();
            }
        }
    }
    public void BackRetry()
    {
        _direRetry.transform.DOMoveX(-100, 1);
        goldImage.transform.DOMoveY(900, 1);
        Destroy(dire, 2f);
    }

    public void ActiveSolider(GameObject SpawnSolider)
    {
        SpawnSolider.SetActive(true);
    }

    public void DeActiveButton()
    {
        _direButton.transform.DOMoveX(120, 1);
        SpawnBG.SetActive(false);
    }
}
