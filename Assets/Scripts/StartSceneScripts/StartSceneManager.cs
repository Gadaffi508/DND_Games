using System.Collections;
using UnityEngine;
using DG.Tweening;

public class StartSceneManager : MonoBehaviour
{
    public RectTransform[] menuImages;
    [SerializeField] private GameObject[] Circle;
    int currentIndex = 0;
    bool changed = true;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float touchDelta = touch.deltaPosition.x;

                if (touchDelta > 0 && changed)
                {
                    ChangeImageRight();
                    changed = false;
                }
                else if (touchDelta < 0 && changed)
                {
                    ChangeImageLeft();
                    changed = false;
                }
            }
        }
    }

    public void ChangeImageRight()
    {
        if (currentIndex > 0)
        {
            if (menuImages[currentIndex].gameObject == true) menuImages[currentIndex].gameObject.GetComponent<AiryUIAnimatedElement>().HideElement();
            Circle[currentIndex].SetActive(false);
            currentIndex--;
            menuImages[currentIndex].gameObject.SetActive(true); // Yeni görüntünün ekrana gelmesini saðlar
            menuImages[currentIndex].gameObject.GetComponent<AiryUIAnimatedElement>().ShowElement(); // Yeni görüntünün ekrana gelmesini saðlar
            Circle[currentIndex].SetActive(true);
        }
        StartCoroutine(ChangedBool());
    }

    public void ChangeImageLeft()
    {
        if (currentIndex < menuImages.Length - 1)
        {
            if (menuImages[currentIndex].gameObject == true) menuImages[currentIndex].gameObject.GetComponent<AiryUIAnimatedElement>().HideElement();
            Circle[currentIndex].SetActive(false);
            currentIndex++;
            menuImages[currentIndex].gameObject.SetActive(true); // Yeni görüntünün ekrana gelmesini saðlar
            menuImages[currentIndex].gameObject.GetComponent<AiryUIAnimatedElement>().ShowElement(); // Yeni görüntünün ekrana gelmesini saðlar
            Circle[currentIndex].SetActive(true);
        }
        StartCoroutine(ChangedBool());
    }

    IEnumerator ChangedBool()
    {
        yield return new WaitForSeconds(.5f);
        changed = true;
    }
}

