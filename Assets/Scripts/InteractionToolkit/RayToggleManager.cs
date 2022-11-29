using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


/*
 * Toggle ray interactor on "XRI LeftHand Locomotion | Teleport Mode Activate"
 * Make sure the select action in XR Controller on the left hand is set to:  XRI LeftHand Locomotion | Teleport Mode Activate
 * Also disable "Enable Input Tracking"and the "Rotate anchor Action and Translate anchor action" in the XR Controller
 */

public class RayToggleManager : MonoBehaviour
{
    [SerializeField] private InputActionReference activeReference = null;

    private XRRayInteractor rayInteractor = null;
    private bool isEnabled = false;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    private void OnEnable()
    {
        activeReference.action.started += ToggleRay;
        activeReference.action.canceled += ToggleRay;
    }

    private void OnDisable()
    {
        activeReference.action.started -= ToggleRay;
        activeReference.action.canceled -= ToggleRay;
    }

    private void ToggleRay(InputAction.CallbackContext context)
    {
        isEnabled = context.control.IsPressed();
    }

    private void LateUpdate()
    {
        ApplyStatus();
    }

    private void ApplyStatus()
    {
        if (rayInteractor.enabled != isEnabled)
        {
            rayInteractor.enabled = isEnabled;
        }
    }
}
