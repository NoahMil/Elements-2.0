using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public int sceneIndex;
    
    private void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        GoToScene(sceneIndex);
    }
}
