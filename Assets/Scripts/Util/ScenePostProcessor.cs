using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePostProcessor : Singleton<ScenePostProcessor>
{
    public void DoPostProcess (Scene scene)
    {
        Debug.Log($@"Post-processing scene {scene.name}...");

        // get root objects in scene
        List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            if (gameObject != null) 
            {
                // do stuff....
                PreOrderTraversal(gameObject);
            }
        }
        Debug.Log($@"Post-processing scene {scene.name} done.");
    }


    public void CleanupPostProcessing(Scene scene)
    {
        Debug.Log($@"Cleaning up post-processor data for scene {scene.name}...");

        Debug.Log($@"Cleanup post-processor data done.");
    }


    void PreOrderTraversal(GameObject parentGameObject)
    {
        // ... Do something with the parent before the children ...

        Debug.Log(parentGameObject.name);

        foreach (Transform childTransform in parentGameObject.transform)
        {
            var childGameObject = childTransform.gameObject;
            PreOrderTraversal(childGameObject); // Recursion!
        }
    }
}
