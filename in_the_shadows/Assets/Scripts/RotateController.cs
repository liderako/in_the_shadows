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
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetAxis("Mouse Y") != 0)
                {
                    if (Input.GetKey(KeyCode.Y) && !Input.GetKey(KeyCode.LeftCommand) && isVertical)
                    {
                        transform.Rotate (Input.GetAxis ("Mouse Y") * speedRotation, 0, 0, Space.Self); 
                        //transform.rotation = Quaternion.Euler(transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * speedRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
                        //transform.localRotation.eulerAngles.x += Input.GetAxis("Mouse Y") * speedRotation;
                        //transform.RotateAround(Vector3.zero, Vector3.right,  Input.GetAxis("Mouse Y") * speedRotation);
                        if (transform.localEulerAngles.x > 360)
                        {
                            transform.rotation = Quaternion.Euler(360 - transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
                        }
                        else if (transform.localEulerAngles.x < 0)
                        {
                            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x + 360, transform.localEulerAngles.y, transform.localEulerAngles.z);
                        }
                        Debug.Log("rotation x" +  transform.localEulerAngles); 
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
                        transform.Rotate (0, -Input.GetAxis ("Mouse X") * speedRotation, 0, Space.Self);
                        if (transform.localEulerAngles.y > 360)
                        {
                            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 360 - transform.localEulerAngles.y, transform.localEulerAngles.z);
                        }
                        else if (transform.localEulerAngles.y < 0)
                        {
                            transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + 360, transform.localEulerAngles.z);
                        }
                        Debug.Log(transform.localEulerAngles);
                        Debug.Log(transform.localRotation);
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
}
