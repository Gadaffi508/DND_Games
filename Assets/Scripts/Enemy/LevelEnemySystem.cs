using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemySystem : MonoBehaviour
{
    [SerializeField] private GameObject[] m_cüce; 
    [SerializeField] private GameObject[] m_ork; 
    [SerializeField] private GameObject[] m_Trol;

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
                break;
            case 2:
                GameObjectFor(m_ork,true);
                break;
            case 3:
                GameObjectFor(m_Trol,true);
                break;
            case 4:
                MixGameObjectFor(0,1,2);
                break;
            case 5:
                MixGameObjectFor(0,2,1);
                break;
            case 6:
                MixGameObjectFor(1,2,0);
                break;
            case 7:
                MixGameObjectFor(1,0,2);
                break;
            case 8:
                MixGameObjectFor(2,0,1);
                break;
            case 9:
                MixGameObjectFor(2,1,0);
                break;
            default:
                GameObjectFor(m_cüce, true);
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
}
