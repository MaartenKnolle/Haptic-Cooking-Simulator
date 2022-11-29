using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class RotateToCamera : MonoBehaviour
{
    public XROrigin xrOrigin;
    // Start is called before the first frame update
    public Vector3 scale = new Vector3(1, 1, 1);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(xrOrigin.Camera.transform.position, xrOrigin.Camera.transform.up);
        gameObject.transform.localScale = scale;
    }
}
