using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int sceneIndex;
    public FadeScreen fadeScreen;
    public AudioSource teleportationSE;

    private void OnTriggerEnter(Collider other)
    {
        teleportationSE.Play();
        GoToScene(sceneIndex);
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
