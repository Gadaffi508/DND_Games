using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamceControllerF : MonoBehaviour
{
    public GameObject LoadScene;
    public Image LoadingFillImage;

    public GameObject[] buttons;

    bool NextTutorail;
    SoldierController soldierController;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("NextTutorail")) GetTutorial();

        if(NextTutorail) StartCoroutine(LoadSceneAsync(1));

        Debug.Log(NextTutorail);
    }

    private void Start()
    {
        soldierController = GetComponent<SoldierController>();

        NextTutorail = true;
    }

    public void MenuLoad(int SceneÝd)
    {
        SaveTutorial();
        StartCoroutine(LoadSceneAsync(SceneÝd));
    }

    private void Update()
    {
        if (soldierController.soilderC > 2)
        {
            foreach (var button in buttons)
            {
                button.SetActive(false);
            }
        }
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

    public void SaveTutorial()
    {
        PlayerPrefs.SetInt("NextTutorail", (NextTutorail ? 1 : 0));
    }

    public void GetTutorial()
    {
        NextTutorail = PlayerPrefs.GetInt("NextTutorail") == 1 ? true : false;
    }
}
