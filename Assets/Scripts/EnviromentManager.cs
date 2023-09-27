using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_terrain;
    [SerializeField] private int m_index = 0;

    private IEnumerator Start()
    {
        GetTerrain();

        foreach (GameObject terrain in m_terrain)
        {
            terrain.SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);

        m_terrain[m_index].SetActive(true);
    }

    void SetTerrain()
    {
        PlayerPrefs.SetInt("m_index",m_index);
    }

    void GetTerrain()
    {
        if (PlayerPrefs.HasKey("m_index"))
        {
            m_index = PlayerPrefs.GetInt("m_index");
        }
    }

    public void NextTerrain()
    {
        if (GameManager.Instance.onelevel == true) m_index++;
        if (m_index == 9) m_index = 2;

        SetTerrain();
    }
}
