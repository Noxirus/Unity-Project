using System;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    private InputController _inputController;
    private CharacterController _characterController;
    
    [Header("Movement")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private MovementConfig movementConfig;
    private Vector2 _moveInput;
    private Vector3 _currentVelocity;
    
    [Header("Look Rotation")]
    [SerializeField] private Transform lookTarget;
    private Vector2 _lookRotation;
    
    private Animator _playerAnimator;
    
    [Header("Interaction")]
    [SerializeField] LayerMask interactLayer;
    private readonly float _interactRadius = 3f;

    [Header("Health")] 
    private float _maxHealth = 100f;
    private float _currentHealth;
    public UnityEvent<float> OnPlayerTakeDamage;
    
    
    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponentInChildren<Animator>();
        _currentHealth = 50.0f;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameData gameData = SaveManager.Instance.LoadGame();
        
        
        if (gameData != null)
        {
            transform.position = gameData.PlayerPosition;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damageAmount, 0, _maxHealth);
        OnPlayerTakeDamage.Invoke(GetHealthPercentage());
    }

    private void OnDestroy()
    {
        GameData gameData = new GameData();
        gameData.PlayerPosition = transform.position;
        gameData.PlayerScore = new Random().Next(0, 100);
        gameData.PlayerName = "Fred";
        SaveManager.Instance.SaveGame(gameData);
    }

    private void OnEnable()
    {
        if (_inputController != null)
        {
            _inputController.MoveEvent += HandleMoveInput;
            _inputController.JumpEvent += Jump;
            _inputController.LookEvent += HandleLookRotation;
            _inputController.InteractEvent += AttemptInteract;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _playerAnimator.SetTrigger("DoAFlip");
        }
        
        Vector3 targetDirection = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        Vector3 targetVelocity = targetDirection * movementConfig.targetMoveSpeed;
        
        float accel = IsGrounded() ? movementConfig.accelerationRate : movementConfig.airAccelerationRate;
        _currentVelocity = Vector3.MoveTowards(_currentVelocity, targetVelocity, accel * Time.deltaTime);

        if (!IsGrounded())
        {
            _currentVelocity.y += Physics.gravity.y * movementConfig.gravityMultiplier * Time.deltaTime;
        }
        
        _characterController.Move(_currentVelocity * Time.deltaTime);
        
        transform.Rotate(Vector3.up, _lookRotation.x * movementConfig.lookSpeed);
        lookTarget.Rotate(Vector3.right, -_lookRotation.y * movementConfig.lookSpeed);
        _playerAnimator.SetFloat("MoveSpeed", _currentVelocity.magnitude);
    }

    private void AttemptInteract()
    {
        RaycastHit[] hitInfoResults = Physics.SphereCastAll(
            transform.position,
            _interactRadius,
            Vector3.one,
            50f,
            interactLayer);
        foreach (RaycastHit hitInfo in hitInfoResults)
        {
            IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void HandleMoveInput(Vector2 movement)
    {
        _moveInput = movement;
    }

    private void HandleLookRotation(Vector2 lookRotation)
    {
        _lookRotation = lookRotation;
    }
    
    private void Jump()
    {
        if (IsGrounded())
        {
            _currentVelocity.y = movementConfig.baseJumpForce;
        }
    }

    private bool IsGrounded()
    {
        return Physics.SphereCast(transform.position, .5f, Vector3.down, out RaycastHit hit, .6f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(origin, _interactRadius);
    }

    public float GetHealthPercentage()
    {
        return _currentHealth / _maxHealth;
    }
}
