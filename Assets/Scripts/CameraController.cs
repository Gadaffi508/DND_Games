using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool zoomCurrent = false;

    // Update is called once per frame
    void Update()
    {
        if (zoomCurrent)
        {
            transform.position = new Vector3(transform.position.x,
            transform.position.y - Time.deltaTime,
            transform.position.z - Time.deltaTime
            );
        }
        if (transform.position.y <= 4)
        {
            transform.position = new Vector3(transform.position.x,
            4,
            transform.position.z
            );
        }
        if (transform.position.z <= 5.8)
        {
            transform.position = new Vector3(transform.position.x,
            transform.position.y,
            5.8f
            );
        }
    }

    public void CameraZoom()
    {
        zoomCurrent = true;
    }
}
