using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementMenu : MonoBehaviour
{
    public int sceneIndex;
    public FadeScreen fadeScreen;
    public AudioSource teleportationSE;
    [SerializeField] private ListeEpreuve _listeEpreuve;

    private void OnTriggerEnter(Collider other)
    {
        teleportationSE.Play();
        GoToScene(sceneIndex);
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
        foreach (Epreuve epreuves in _listeEpreuve.Epreuves)
        {
            epreuves.epreuveCompleted = false;
        }
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