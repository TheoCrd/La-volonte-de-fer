using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public Animator animator;

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Cube2")
        { 
            StartCoroutine(wait());
        }
    }

    public void FadeToLevel(int sceneIndex)
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator wait()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        FadeToLevel(1);
        yield return new WaitForSeconds(5);
        OnFadeComplete();
        //Debug.Log("Wait is over");
    }
}
