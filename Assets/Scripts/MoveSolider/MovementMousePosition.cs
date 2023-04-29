using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMousePosition : MonoBehaviour
{
    public Solider player;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layersToHit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Solider>();
    }

    private void Update()
    {
        screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hitdata,100,layersToHit))
        {
            worldPosition = hitdata.point;
        }

        if (player.selected==true)
        {
            player.transform.position = new Vector3(worldPosition.x, 1, worldPosition.z);
        }

    }
}
