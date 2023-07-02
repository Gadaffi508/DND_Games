using System.Collections;
using System.Collections.Generic;
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

    private void FixedUpdate()
    {
        CurrentLevel.text = level.ToString();
        NextLevelSecond.text = (level + 1).ToString();
        NextLevelThree.text = (level + 2).ToString();
    }

    public void PlayGame(int levelScene)
    {
        SceneManager.LoadScene(levelScene);
    }
}
