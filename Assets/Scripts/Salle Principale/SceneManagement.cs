using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int sceneIndex;
    
    private void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        GoToScene(sceneIndex);
    }
}
