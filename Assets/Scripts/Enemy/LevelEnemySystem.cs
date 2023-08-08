using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemySystem : MonoBehaviour
{
    [SerializeField] private GameObject[] m_cüce; 
    [SerializeField] private GameObject[] m_ork; 
    [SerializeField] private GameObject[] m_Trol;

    [Space]
    [Header("EnemyType")]
    [SerializeField] private GameObject[] m_enemyTypeImage;

    private void Start()
    {
        EnemyGameLevelActive();
    }

    public void EnemyGameLevelActive()
    {
        switch (GameManager.Instance.level)
        {
            case 1:
                GameObjectFor(m_cüce,true);
                EnemyImageShow(0,1,2);
                break;
            case 2:
                GameObjectFor(m_ork,true);
                EnemyImageShow(3, 4, 5);
                break;
            case 3:
                GameObjectFor(m_Trol,true);
                EnemyImageShow(6, 7, 8);
                break;
            case 4:
                MixGameObjectFor(0,1,2);
                EnemyImageShow(2, 4, 6);
                break;
            case 5:
                MixGameObjectFor(0,2,1);
                EnemyImageShow(2, 3, 7);
                break;
            case 6:
                MixGameObjectFor(1,2,0);
                EnemyImageShow(3, 1, 8);
                break;
            case 7:
                MixGameObjectFor(1,0,2);
                EnemyImageShow(5, 1, 6);
                break;
            case 8:
                MixGameObjectFor(2,0,1);
                EnemyImageShow(0, 7, 5);
                break;
            case 9:
                MixGameObjectFor(2,1,0);
                EnemyImageShow(0, 4, 8);
                break;
            default:
                //
                break;
        }
    }

    public void GameObjectFor(GameObject[] OBJ,bool active)
    {
        foreach (GameObject solider in OBJ)
        {
            solider.SetActive(active);
        }
    }

    public void MixGameObjectFor(int a,int b, int c)
    {
        m_cüce[a].SetActive(true);
        m_ork[b].SetActive(true);
        m_Trol[c].SetActive(true);
    }

    public void EnemyImageShow(int a, int b, int c)
    {
        foreach (GameObject ýmageAll in m_enemyTypeImage)
        {
            ýmageAll.SetActive(false);
        }

        m_enemyTypeImage[a].SetActive(true);
        m_enemyTypeImage[b].SetActive(true);
        m_enemyTypeImage[c].SetActive(true);
    }
}
