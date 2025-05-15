using UnityEngine;

public class ReferencePlayerMovement : MonoBehaviour
{
    [SerializeField] private ReferenceMovementConfig movementConfig;
    
    private ReferenceInputController _inputController;
    private Vector2 _moveInput;
    private Vector2 _lookInput;

    private CharacterController _characterController;
    private Vector3 _currentVelocity;
    [SerializeField] private LayerMask _groundLayer;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        // Get the InputController component from the same GameObject
        _inputController = GetComponent<ReferenceInputController>();
        if (_inputController == null)
        {
            Debug.LogError("InputController component not found on this GameObject. Ensure it is attached.");
        }
    }

    private void OnEnable()
    {
        if (_inputController != null)
        {
            _inputController.MoveEvent += HandleMoveInput;
            _inputController.FireEvent += Fire;
            _inputController.JumpEvent += Jump;
            // Subscribe to other events like _inputController.JumpEvent if needed
        }
    }
    void OnDisable()
    {
        if (_inputController != null)
        {
            _inputController.MoveEvent -= HandleMoveInput;
            // Unsubscribe from other events
        }
    }

    void Fire()
    {
        Debug.Log("Fire");
    }

    void Jump()
    {
        SphereCastGroundCheck();
        if (IsGrounded())
        {
            _currentVelocity.y = movementConfig.baseJumpForce; // Or apply an impulse force if using Rigidbody
        }
    }

    private void HandleMoveInput(Vector2 movement)
    {
        _moveInput = movement;
    }

    void Update()
    {
        // Use the _moveInput to control character movement
        // Example of applying movement will be covered conceptually in Topic 3.
        // For now, we are focusing on receiving the input.
        Vector3 targetDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
        Vector3 targetVelocity = targetDirection * movementConfig.targetMoveSpeed;
        
        float accel = IsGrounded() ? movementConfig.accelerationRate : movementConfig.airAccelerationRate;
        _currentVelocity = Vector3.MoveTowards(_currentVelocity, targetVelocity, accel * Time.deltaTime);
        if (!IsGrounded())
        {
            _currentVelocity.y += Physics.gravity.y * movementConfig.gravityMultiplier * Time.deltaTime;
        }

        _characterController.Move(_currentVelocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        return _characterController.isGrounded;
    }

    private bool SphereCastGroundCheck()
    {
        RaycastHit hitResult;
        if (Physics.SphereCast(transform.position, .5f, Vector3.down, out hitResult, .6f, _groundLayer))
        {
            Debug.Log("Hit Something! Currently Grounded");
            return true;
        }
        Debug.Log("Hit Nothing");
        return false;
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 end = origin + Vector3.down * .6f;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, .5f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(end, .5f); 
    }
}
