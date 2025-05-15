using UnityEngine;

[CreateAssetMenu(fileName = "NewMovementConfig", menuName = "Game Configs/Movement Config")]
public class ReferenceMovementConfig : ScriptableObject
{
    public float targetMoveSpeed = 5f;
    public float accelerationRate = 10f;
    public float decelerationRate = 15f;
    public float baseJumpForce = 8f;
    public float gravityMultiplier = 5f;
    public float airAccelerationRate = 5f;
}
