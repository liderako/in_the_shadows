using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public string scene;
    // Update is called once per frame
    public void onClick()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
