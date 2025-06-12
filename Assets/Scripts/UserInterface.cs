using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Button bubbles;
    
    void Start()
    {
        bubbles.onClick.AddListener(PressedButton);
    }

    void PressedButton()
    {
        Debug.Log("Pressed button");

        bubbles.image.DOColor(Color.red, 3f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            bubbles.image.DOColor(Color.white, 1f);
        });

        bubbles.transform.DORotate(Vector3.forward * 180f, 2f);

    }
}
