using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandUIManager : MonoBehaviour
{
    public GameObject handUI;
    public bool activeHandUI = false;
    [SerializeField] private InputActionReference activateUIReference = null;
    private XRBaseController acController = null;

    private void Awake()
    {
        acController = GetComponent<XRBaseController>();
    }


    private void OnEnable()
    {
        activateUIReference.action.started += ToggleUI;
        activateUIReference.action.canceled += ToggleUI;
    }

    private void OnDisable()
    {
        activateUIReference.action.started -= ToggleUI;
        activateUIReference.action.canceled -= ToggleUI;
    }

    // Start is called before the first frame update
    void Start()
    {

        DisplayHandUI(activeHandUI);
    }

    private void ToggleUI(InputAction.CallbackContext context)
    {
        activeHandUI = context.control.IsPressed();
        DisplayHandUI(activeHandUI);
    }

    public void HandUISetActive (InputAction.CallbackContext context)
    {
        // context.performed = true when button pressed, false when released
        DisplayHandUI(context.performed);
    }

    public void DisplayHandUI(bool state)
    {
        activeHandUI = state;
        handUI.SetActive(state);
        if (acController)
            acController.hideControllerModel = state;
    }

    public void ButtonPressed(string name)
    {
        Debug.LogFormat("UI {0} Button Pressed", name);
    }
}
