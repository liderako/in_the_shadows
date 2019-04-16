using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject currentCheckPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            currentCheckPoint = currentCheckPoint.GetComponent<checkpoint>().nextCheckpoint;
            transform.position = new Vector3(currentCheckPoint.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            currentCheckPoint = currentCheckPoint.GetComponent<checkpoint>().prevCheckpoint;
            transform.position = new Vector3(currentCheckPoint.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
