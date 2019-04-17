using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public bool isVertical;
    public bool isHorizontal;
    public bool isMove;
    public bool isActive;
    public float speedMove;
    public float speedRotation;
    public List<Vector3> endRotation;
    public GameObject textVictory;
    public bool isDoneP;

    public bool isDoneR;
    public string typeScene;
    public GameObject gm;
    public GameObject neighbor;
    public bool isLeft;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isMove)
        {
            if ((!isDoneP || !isDoneR) && isActive)
            {
                _isTerminateMove();
                controller();
            }
        }
        else
        {
            if (!isDoneR && isActive)
            {
                controller();
            }
        }
        _isTerminateRotate();
        isVictory();
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
                    }
                    else if (Input.GetKey(KeyCode.LeftCommand) && !Input.GetKey(KeyCode.Y) && isMove)
                    {
                        transform.position = new Vector3(
                            transform.position.x,
                            transform.position.y + Input.GetAxis("Mouse Y") * speedMove,
                            transform.position.z
                            );
                    }
                }
                else if (Input.GetAxis("Mouse X") != 0)
                {
                    if (Input.GetKey(KeyCode.X) && isHorizontal && !Input.GetKey(KeyCode.LeftControl))
                    {
                        transform.Rotate (0, -Input.GetAxis ("Mouse X") * speedRotation, 0, Space.World);
                    }
                    else if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.X) && isMove)
                    {
                        transform.position = new Vector3(transform.position.x + (Input.GetAxis("Mouse X") * speedMove),
                            transform.position.y,
                            transform.position.z
                            );
                    }
                }
            }
        }
    }

    private void isVictory()
    {
        if (isDoneR)
        {
            if (isMove)
            {
                if (isDoneP)
                {
                    if (isLeft)
                    {
                        GameManager.gm.isLeft = true;
                    }
                    else
                    {
                        GameManager.gm.isRight = true;
                    }
                }
            }
            else
            {
                textVictory.SetActive(true);
                PlayerPrefs.SetInt(typeScene, 2);
            }
        }
    }

    private void _isTerminateRotate()
    {
        foreach (var rot in endRotation)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.Euler(rot.x, rot.y, rot.z));
            if (angle < 10)
            {
                isDoneR = true;
            }
        }
    }

    private void _isTerminateMove()
    {
        if (isLeft)
        {
            if (transform.position.x + 11 < neighbor.transform.position.x)
            {
                isDoneP = true;
            }
        }
        else
        {
            if (transform.position.x - 11 > neighbor.transform.position.x)
            {
                isDoneP = true;
            }
        }
    }
    
    private void OnMouseDown()
    {
        gm.SendMessage("ChangeActive", gameObject);
    }
}
