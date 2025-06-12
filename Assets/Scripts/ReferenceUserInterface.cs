using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class ReferenceUserInterface : MonoBehaviour
{
    [SerializeField] private Button myButton;

    void Start()
    {
        myButton.onClick.AddListener(ButtonAnimate);
    }

    void ButtonAnimate()
    {
        myButton.image.DOFade(0.0f, 1f).SetLoops(2, LoopType.Yoyo);
        myButton.image.DOColor(Color.red, 1f).OnComplete(() =>
        {
            myButton.image.DOColor(Color.white, 1f);
        });
    }
}
