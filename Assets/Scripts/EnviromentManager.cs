using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_terrain;

    private void Start()
    {
        foreach (GameObject terrain in m_terrain)
        {
            terrain.SetActive(false);
        }
        m_terrain[GameManager.Instance.level-1].SetActive(true);
    }
}
