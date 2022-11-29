using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class NullCheck
    {
        //https://stackoverflow.com/questions/60189192/check-if-a-gameobject-has-been-assigned-in-the-inspector-in-unity3d-2019-3-05f
        public static bool IsNull<T>(this T myObject, string message = "") where T : class
        {
            switch (myObject)
            {
                case UnityEngine.Object obj when !obj:
                    Debug.LogError("The object is null! " + message);
                    return true;
                case null:
                    Debug.LogError("The object is null! " + message);
                    return true;
                default:
                    return false;
            }
        }
    }
}
