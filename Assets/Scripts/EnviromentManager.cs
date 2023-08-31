using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_terrain;

    private IEnumerator Start()
    {
        foreach (GameObject terrain in m_terrain)
        {
            terrain.SetActive(false);
        }

        yield return new WaitForSeconds(0.2f);

        m_terrain[GameManager.Instance.level-1].SetActive(true);
    }
}
