using UnityEngine;

public class AnimationReference : MonoBehaviour
{
    private Animator _zombieAnimator;
    
    void Start()
    {
        _zombieAnimator = GetComponent<Animator>();
    }

    public void TestFunction()
    {
        Debug.Log("TestFunction");
    }
    
    void Update()
    {
        return;
        if (Input.GetKeyDown(KeyCode.G))
        {
            _zombieAnimator.SetTrigger("DoAFlip");
            Debug.Log("Doing a flip");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _zombieAnimator.SetFloat("MoveSpeed", 0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _zombieAnimator.SetFloat("MoveSpeed", 5);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            _zombieAnimator.SetFloat("MoveSpeed", 60);
        }
    }
}
