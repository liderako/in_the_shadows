using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public bool isVertical;
    public bool isHorizontal;
    public bool isMove;
    public float speedMove;
    public float speedRotation;
    public List<Vector3> endRotation;
    public List<Vector3> endPosition;
    public GameObject textVictory;
    public bool isDoneP;

    public bool isDoneR;
    public string typeScene;
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isDoneR)
        {
            controller();
        }
        isTerminate();
    }

    private void controller()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetAxis("Mouse Y") != 0)
                {
                    if (Input.GetKey(KeyCode.Y) && !Input.GetKey(KeyCode.LeftCommand) && isVertical)
                    {
                        transform.Rotate (Input.GetAxis ("Mouse Y") * speedRotation, 0, 0, Space.World); 
                        if (transform.localEulerAngles.x > 360)
                        {
                            transform.rotation = Quaternion.Euler(360 - transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
                        }
                        else if (transform.localEulerAngles.x < 0)
                        {
                            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x + 360, transform.localEulerAngles.y, transform.localEulerAngles.z);
                        }
                    }
                    else if (Input.GetKey(KeyCode.LeftCommand) && !Input.GetKey(KeyCode.Y) && isMove)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + Input.GetAxis("Mouse Y") * speedMove,
                            transform.position.z);
                    }
                }
                else if (Input.GetAxis("Mouse X") != 0)
                {
                    if (Input.GetKey(KeyCode.X) && isHorizontal && !Input.GetKey(KeyCode.LeftControl))
                    {
                        transform.Rotate (0, -Input.GetAxis ("Mouse X") * speedRotation, 0, Space.World);
                        if (transform.localEulerAngles.y > 360)
                        {
                            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 360 - transform.localEulerAngles.y, transform.localEulerAngles.z);
                        }
                        else if (transform.localEulerAngles.y < 0)
                        {
                            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + 360, transform.localEulerAngles.z);
                        }
                    }
                    else if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.X) && isMove)
                    {
                        transform.position = new Vector3(transform.position.x + (Input.GetAxis("Mouse X") * speedMove),
                            transform.position.y,
                            transform.position.z);
                    }
                }
            }
        }
    }

    public void isTerminate()
    {
//        Debug.Log("_START_");
//        Debug.Log("X " + transform.eulerAngles.x);
//        Debug.Log("Y " + transform.eulerAngles.y);
//        Debug.Log("__");
        int i = 0;
        while (i < endRotation.Count)
        {
//            Debug.Log(i);
//            Debug.Log(transform.eulerAngles.x >= endRotation[i].x);
//            Debug.Log(transform.eulerAngles.y >= endRotation[i].y);
//            Debug.Log(transform.eulerAngles.x <= endRotation[i + 1].x);
//            Debug.Log(transform.eulerAngles.y <= endRotation[i + 1].y);
//            Debug.Log("_________");
//            Debug.Log(endRotation[i+1].x);
            if (transform.eulerAngles.x >= endRotation[i].x && transform.eulerAngles.y >= endRotation[i].y &&
                transform.eulerAngles.x <= endRotation[i + 1].x && transform.eulerAngles.y <= endRotation[i + 1].y)
            {
                isDoneR = true;
                textVictory.SetActive(true);
                PlayerPrefs.SetInt(typeScene, 2);
            }
//            Debug.Log("??????????????????????");
            i += 2;
        }
    }
}
