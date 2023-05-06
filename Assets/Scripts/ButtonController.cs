using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public GameObject _spawnButton;
    public GameObject _attackButton;
    public GameObject _direButton;

    private void Start()
    {
        _direButton.transform.DOMoveX(120,1);
        _spawnButton.SetActive(false);
        _attackButton.SetActive(false);
    }
    public void ButtonActive()
    {
        StartCoroutine(DelayAcitve());   
    }
    IEnumerator DelayAcitve()
    {
        yield return new WaitForSeconds(2);
        _spawnButton.SetActive(true);
        _spawnButton.transform.DOMoveY(400, 1);
        _attackButton.SetActive(true);
        _attackButton.transform.DOMoveX(680, 1);
        _direButton.transform.DOMoveX(-80, 1);
        yield return new WaitForSeconds(1);
        _direButton.SetActive(false);
    }
}
