using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool started = false;
    public Text TimeText;

    public GameObject LevelPanel;

    private void Awake()
    {
        Instance = this;
    }

    public float GameTime = 15;


    public int gold;

    public int maxFrontSoldierCount = 3;

    private void LateUpdate()
    {
        if (started == true)
        {
            GameTime -= Time.deltaTime;
        }
        TimeText.text = "Time : " + GameTime.ToString("00.0");

        if (GameTime <= 0)
        {
            GameTime = 0;
            LevelPanel.transform.DOMoveY(500, 1).OnComplete(() => Time.timeScale = 0);
        }
    }
    public void Started()
    {
        started = true;
    }
}
