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
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }
}