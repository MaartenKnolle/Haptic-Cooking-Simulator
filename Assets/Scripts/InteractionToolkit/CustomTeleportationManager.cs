using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


/*
 * Alternative to the RayToggleManager.
 * 
 * This script toggles the ray interactor on the left hand
 */

public class CustomTeleportationManager : MonoBehaviour
{
    [SerializeField]
    private TeleportationProvider teleportationProvider;
    [SerializeField]
    private InputActionAsset actionAsset;
    [SerializeField]
    private XRRayInteractor rayInteractor;

    private bool isActive = false;
    private bool doTeleport = false;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction ("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;
        activate.canceled += DoTeleport;

        var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCanceled;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            return;
        }

        if (doTeleport == false)
        {
            return;
        }

        doTeleport = false;

        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) == false)
        {
            rayInteractor.enabled = false;
            isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,
            //destinationRotation = ,
        };
        teleportationProvider.QueueTeleportRequest(request);

        rayInteractor.enabled = false;
        isActive = false;

    }

    private void DoTeleport(InputAction.CallbackContext context)
    {
        if (isActive)
            doTeleport = true;
    }


    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        isActive = true;
        doTeleport = false;
    }

    private void OnTeleportCanceled(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        isActive = false;
        doTeleport = false;
    }
}
