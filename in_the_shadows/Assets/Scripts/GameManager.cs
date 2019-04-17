using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<GameObject> objects;
    public int count;
    public GameObject textVictory;
    public string typeScene;
    public bool isLeft;
    public bool isRight;
    
    void Awake () {
        if (gm == null)
            gm = this;
    }

    public void ChangeActive(GameObject go)
    {
        Debug.Log("???????????/");
        foreach (var obj in objects)
        {
            if (obj.name == go.name)
            {
                go.GetComponent<RotateController>().isActive = true;
            }
            else
            {
                obj.GetComponent<RotateController>().isActive = false;
            }
        }
    }

    public void Update()
    {
        updateVictory();
    }

    public void updateVictory()
    {
        if (isLeft && isRight)
        {
            textVictory.SetActive(true);
            PlayerPrefs.SetInt(typeScene, 2);
        }
    }
}
