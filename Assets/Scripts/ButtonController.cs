using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject _direButton;
    public GameObject _direRetry;
    public Text TimeText;
    public float _Time = 5;
    public Text goldText;
    public GameObject goldImage;
    public GameObject dire;
    public bool startRetyTime = false;

    [Space]
    [Header("Solider")]
    public GameObject Thierd, wizard, fighter;
    public bool _Thierd, _wizard, _fighter;

    public void ButtonActive()
    {
        StartCoroutine(DelayAcitve());

        if (_Thierd)
        {
            Thierd.SetActive(true);
        }
        else if(_wizard)
        {
            wizard.SetActive(true);
        }
        else if(_fighter)
        {
            fighter.SetActive(true);
        }
    }
    IEnumerator DelayAcitve()
    {
        startRetyTime = true;
        yield return new WaitForSeconds(2);
        goldImage.SetActive(true);
        yield return new WaitForSeconds(1);
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
        Destroy(dire, 2f);
    }

    public void ActiveChangeObject(string activeObjectName)
    {
        if (activeObjectName == "Savaþcý")
        {
            _fighter = true;
        }
        else if(activeObjectName == "Büyücü")
        {
            _wizard = true;
        }
        else if(activeObjectName == "Hýrsýz")
        {
            _Thierd = true;
        }
    }
}
