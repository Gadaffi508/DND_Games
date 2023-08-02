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
            menuImages[currentIndex].DOAnchorPosX(800, 1);
            Circle[currentIndex].SetActive(false);
            currentIndex--;
            menuImages[currentIndex].DOAnchorPosX(0, 1); // Yeni görüntünün ekrana gelmesini saðlar
            Circle[currentIndex].SetActive(true);
        }
        StartCoroutine(ChangedBool());
    }

    public void ChangeImageLeft()
    {
        if (currentIndex < menuImages.Length - 1)
        {
            menuImages[currentIndex].DOAnchorPosX(-800, 1);
            Circle[currentIndex].SetActive(false);
            currentIndex++;
            menuImages[currentIndex].DOAnchorPosX(0, 1); // Yeni görüntünün ekrana gelmesini saðlar
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

