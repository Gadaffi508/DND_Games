using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    private GameObject currentObject;
    public GameObject CurrentSoldier { get {  return currentObject; } 
        set
        {
            currentObject = value;
            if (value != null)
            {
                currentObject.transform.position = CellPosition();
            }
        } 
    }

    public Vector3 CellPosition()
    {
        return new Vector3(transform.position.x, 1.18f, transform.position.z);
    }
}
