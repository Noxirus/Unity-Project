using Unity.Cinemachine;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    [SerializeField] CinemachineCamera characterCamera;
    [SerializeField] CinemachineCamera topDownCamera;
    [SerializeField] CinemachineBrain cinemachineBrain;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            characterCamera.Priority = 100;
            topDownCamera.Priority = 50;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            characterCamera.Priority = 50;
            topDownCamera.Priority = 100;
        }
    }
}
