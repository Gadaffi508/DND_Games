using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEditor.SearchService;

public class StartSceneManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject text;
    public GameObject UpButton;
    public GameObject OkImage;
    public GameObject[] Buttons;
    bool up;
    public void ChangeScene(int sceneID)
    {
        Camera.transform.DOMoveY(-2, 1);
        text.SetActive(true);
        foreach (var button in Buttons)
        {
            button.SetActive(false);
        }
        OkImage.SetActive(false);
        UpButton.SetActive(true);

        if (up == true)
        {
            SceneManager.LoadScene(sceneID);
        }
        up = true;
    }
    public void UpCamera()
    {
        up = false;
        Camera.transform.DOMoveY(6, 1).OnComplete(() =>
        {
            foreach (var button in Buttons)
            {
                button.SetActive(true);
            }
        });
        OkImage.SetActive(true);
        text.SetActive(false);
        UpButton.SetActive(false);
    }
}

