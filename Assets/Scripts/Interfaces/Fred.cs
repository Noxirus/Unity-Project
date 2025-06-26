using UnityEngine;

public class Fred : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hello, good morning, go get coffee.");
    }
}
