using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public string scene;
    public bool isOpen;
    public bool isDone;
    public string typeScene;
    public LoadSceneScript load;
    public List<Material> statusLevel;

    public MeshRenderer meshrender;

    private void Start()
    {
        if (PlayerPrefs.GetInt(typeScene) == 0)
        {
            PlayerPrefs.SetInt(typeScene, 0);
        }
        else if (PlayerPrefs.GetInt(typeScene) == 1)
        {
            isOpen = true;
        }
        else if (PlayerPrefs.GetInt(typeScene) == 2)
        {
            isDone = true;
            if (PlayerPrefs.GetInt(load.typeScene) == 0)
            {
                PlayerPrefs.SetInt(load.typeScene, 1);
            }

            load.isOpen = true;
        }

        if (isOpen && PlayerPrefs.GetInt(typeScene) == 0)
        {
            PlayerPrefs.SetInt(typeScene, 1);
        }
    }

    private void OnMouseDown()
    {
        if (isOpen)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    public void Update()
    {
        Debug.Log(isDone);
        Debug.Log(isOpen);
        if (isDone)
        {
            ChangeColor(2);
        }
        else if (isOpen)
        {
            ChangeColor(1);
        }
        else
        {
            ChangeColor(0);
        }
    }

    private void ChangeColor(int i)
    {
        Material[] materials = meshrender.materials;
        materials[0] = statusLevel[i];
        meshrender.materials = materials;
    }
}
