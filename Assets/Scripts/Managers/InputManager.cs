using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //single references to the input manager
    public static InputManager instance;
    public static PlayerInput playerInput;

    public Vector2 moveInput { get; private set; }
    public bool jumpInput { get; private set; }

    private InputAction moveAction;
    private InputAction jumpAction;

    private void Awake()
    {
        // Set singleton ref.
        if (instance == null)
        {
            instance = this;
        }

        // Player input ref.
        playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    void Update()
    {
        UpdateInputActions();
    }

    private void SetupInputActions()
    {
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    private void UpdateInputActions()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        jumpInput = jumpAction.triggered;
    }
}
