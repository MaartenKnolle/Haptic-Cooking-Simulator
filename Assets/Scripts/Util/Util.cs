using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TNO.Extensions {
    public static class Util {

        /// <summary>
        /// Use this method to get all loaded objects of some type, including inactive objects. 
        /// This is an alternative to Resources.FindObjectsOfTypeAll (returns project assets, including prefabs), and GameObject.FindObjectsOfTypeAll (deprecated).
        /// </summary>
        public static List<T> FindObjectsOfTypeAll<T>() {
            List<T> results = new List<T>();
            for (int i = 0; i < SceneManager.sceneCount; i++) {
                var s = SceneManager.GetSceneAt(i);
                var allGameObjects = s.GetRootGameObjects();
                for (int j = 0; j < allGameObjects.Length; j++) {
                    var go = allGameObjects[j];
                    results.AddRange(go.GetComponentsInChildren<T>(true));
                }
            }

            return results;
        }

        /// <summary>
        /// Use this method to get an objects of some type, including inactive objects. 
        /// </summary>
        public static T FindObjectOfType<T>() {
            for (int i = 0; i < SceneManager.sceneCount; i++) {
                var s = SceneManager.GetSceneAt(i);
                var allGameObjects = s.GetRootGameObjects();
                for (int j = 0; j < allGameObjects.Length; j++) {
                    var go = allGameObjects[j];
                    T t = go.GetComponentInChildren<T>(true);
                    if (t != null) {
                        return t;
                    }
                }
            }

            // null when T is an object
            return default;
        }

        public static void AssertRequired<T>(MonoBehaviour obj, T val) {
            if (null == val) {
                throw new Exception(string.Format("{0} is missing a required value for {1}", obj.name, typeof(T).Name));
            }
        }

        public static string FullObjectPath(GameObject go)
        {
            string path = string.Join("/", go.GetComponentsInParent<Transform>().Select(t => t.name).Reverse().ToArray())+"/"+go.name;
            return path;
        }
    }

}
