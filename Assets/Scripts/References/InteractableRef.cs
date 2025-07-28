using UnityEngine;

public class InteractableRef : MonoBehaviour, iInteractableRef
{
    public void BeginInteraction()
    {
        Debug.Log("Beginning Interaction");
    }
}
