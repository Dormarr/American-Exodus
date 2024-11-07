using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private GameObject focus;
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private int moveSpeed => PlayerGlobals.MoveSpeed;

    public Vector2 DesiredDirection { get; private set; }
    public int FacingDirection { get; private set; } = 1;

    public void Awake()
    {
        input = new CustomInput();
    }

    public void Initialize(GameObject _focus, Rigidbody2D _rb)
    {
        focus = _focus;
        rb = _rb;
    }

    void FixedUpdate()
    {
        UpdateMovement();
    }

    private void OnEnable()
    {
        if (input == null)
        {
            Debug.LogError("Input is not initialized.");
            return;
        }

        input.Enable();
        input.Player.Movement.performed += OnMovement;
        input.Player.Movement.canceled += OnMovementCanceled;
        input.Player.LightAttack.performed += OnLightAttack;
    }

    private void OnDisable()
    {
        input.Player.Movement.performed -= OnMovement;
        input.Player.Movement.canceled -= OnMovementCanceled;
        input.Player.LightAttack.performed -= OnLightAttack;
        input.Disable();
    }

    private void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 rawInput = value.ReadValue<Vector2>();
        moveInput = new Vector2(rawInput.x, rawInput.y * 0.7f);
        // Debug.Log($"Raw Movement: {rawInput} --- Adjusted Movement: {moveInput}");

        PlayerGlobals.DesiredDirection = rawInput;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveInput = Vector2.zero;

        if(PlayerGlobals.State == State.Movement){
            PlayerGlobals.State = State.Idle;
        }
    }

    private void OnLightAttack(InputAction.CallbackContext value){
        PlayerGlobals.State = State.Attack;
    }

    private void UpdateMovement()
    {
        if (moveInput != Vector2.zero)
        {
            // Set the velocity directly to match the input and speed
            PlayerGlobals.State = State.Movement;
            rb.velocity = moveInput * moveSpeed;
        }
        else
        {
            // Stop the player when input is zero
            if(Mathf.Abs(rb.velocity.x) <= 0.0001f){
                rb.velocity = moveInput;
            }
            rb.velocity = rb.velocity * 0.75f;
        }

        PlayerGlobals.PlayerPosition = transform.position;
    }
}
