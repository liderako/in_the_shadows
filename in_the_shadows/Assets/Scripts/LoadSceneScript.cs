using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    public string scene;
    public bool isOpen;
    public bool isDone;
    public List<Material> statusLevel;

    public MeshRenderer meshrender;
    
    private void OnMouseDown()
    {
        if (isOpen)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    public void Update()
    {
        if (isDone)
        {
            ChangeColor(1);
        }
        else if (isOpen)
        {
            ChangeColor(2);
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
