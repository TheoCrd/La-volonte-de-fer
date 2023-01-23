using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerChangeScene : MonoBehaviour
{
    SceneTransitionManager scene;
    public int sceneIndex;

    void OnTriggerEnter(Collider col)
    {
        //Ensure that the correct collider is selected
        if (col.name == "rotating part")
        {
            scene = GameObject.FindGameObjectWithTag("SceneChangerTag").GetComponent<SceneTransitionManager>();
            scene.GoToScene(sceneIndex);
        }
        
    }
}
