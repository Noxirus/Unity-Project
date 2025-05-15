using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReferenceInputController : MonoBehaviour
{
    private GameControls _gameControls;

    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> LookEvent;
    public event Action JumpEvent;
    public event Action JumpCancelledEvent;
    public event Action FireEvent;

    private void Awake()
    {
        _gameControls = new GameControls();
    }

    private void OnEnable()
    {
        _gameControls.Player.Enable(); // Enable the "Player" Action Map

        _gameControls.Player.Move.performed += OnMovePerformed;
        _gameControls.Player.Move.canceled += OnMoveCanceled;
        _gameControls.Player.Jump.performed += OnJumpPerformed;
        _gameControls.Player.Jump.canceled += OnJumpCancelled;
        _gameControls.Player.Look.performed += OnLookPerformed;
        _gameControls.Player.Look.canceled += OnLookCancelled;
        _gameControls.Player.Attack.performed += OnFirePerformed;
    }

    private void OnDisable()
    {
        _gameControls.Player.Enable(); // Enable the "Player" Action Map

        _gameControls.Player.Move.performed -= OnMovePerformed;
        _gameControls.Player.Move.canceled -= OnMoveCanceled;
        _gameControls.Player.Jump.performed -= OnJumpPerformed;
        _gameControls.Player.Jump.canceled -= OnJumpCancelled;
        _gameControls.Player.Look.performed -= OnLookPerformed;
        _gameControls.Player.Look.canceled -= OnLookCancelled;
        _gameControls.Player.Attack.performed -= OnFirePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(Vector2.zero); // Send zero vector when input stops
    }
    
    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        LookEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    private void OnLookCancelled(InputAction.CallbackContext context)
    {
        LookEvent?.Invoke(Vector2.zero);
    }
    
// Similar handlers for OnJumpPerformed, OnLookPerformed, OnFirePerformed, etc.
// For example:
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        JumpEvent?.Invoke();
    }
    
    private void OnJumpCancelled(InputAction.CallbackContext context)
    {
        JumpCancelledEvent?.Invoke();
    }
    
    private void OnFirePerformed(InputAction.CallbackContext context)
    {
        FireEvent?.Invoke();
    }
}
