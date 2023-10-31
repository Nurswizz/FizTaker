using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trans : MonoBehaviour
{
    public static bool fact1 = false;

    public Animator transition;

    public float transitionTime = 2f;

    void Update()
    {
        if (fact1)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    } 

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetBool("Start_End", true);
        fact1 = false;
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
 