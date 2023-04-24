using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    //Make sure the scene is part of the build settings
    //File -> Build Settings -> Drag and Drop required scenes into the Scene box
    public string SceneToLoad = "Scene Name Here";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
