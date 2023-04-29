using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : MonoBehaviour
{
    public bool selected;
    public int id;

    private void OnMouseDown()
    {
        selected = true;
        Debug.Log("Ben");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selected = false;
        }
    }
}
