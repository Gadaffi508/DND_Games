using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMousePosition : MonoBehaviour
{
    public Solider player;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layersToHit;

    public Collider trackingArea; // takip edilecek bölgenin Collider bileþeni

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Solider>();
    }

    private void Update()
    {
        screenPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider == trackingArea)
        { // Collider'a týklama kontrolü
            worldPosition = hit.point;
        }

        if (player.selected == true)
        {
            player.transform.position = new Vector3(
                Mathf.Round(worldPosition.x),
                1,
                Mathf.Round(worldPosition.z)
                );
        }

    }
}