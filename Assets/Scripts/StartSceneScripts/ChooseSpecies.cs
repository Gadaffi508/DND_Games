using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpecies : MonoBehaviour
{
    public GameObject ActivePanel;
    public GameObject[] PasifPanel;

    public void PanelActiving()
    {
        ActivePanel.SetActive(true);
        foreach (var closePanel in PasifPanel)
        {
            closePanel.SetActive(false);
        }
    }
}
