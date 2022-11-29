using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    InputActionAsset playerControls;
    InputAction movement;

    CharacterController character;
    Vector3 moveVec;
    [SerializeField] 
    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        var gameplyaActionMap = playerControls.FindActionMap("Default");
        movement = gameplyaActionMap.FindAction("Move");
        movement.performed += OnMovementChanged;
        movement.canceled += OnMovementChanged;
        movement.Enable();

        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        character.Move(moveVec * speed * Time.fixedDeltaTime);
    }

    private void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVec = new Vector3(direction.x, 0f, direction.y);
    }
}
