using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITweensController : MonoBehaviour
{
    public static UITweensController instance;
    [SerializeField] float duration = 0.5f;
    [SerializeField] LeanTweenType easeType;

    [Header("Scale")]
    [SerializeField] Vector2 size;
    [SerializeField] RectTransform imageForScale;

    [Header("Fade")]
    [SerializeField] CanvasGroup imageForFade;
    
    [SerializeField] float fadeEndPoint;
    private void Awake() {
        instance = this;
    }
    
    public void Scale() {
        imageForScale.LeanScale(size, duration).setEase(easeType);
    }

    public void Fade(){
        imageForFade.LeanAlpha(fadeEndPoint, duration).setEase(easeType);
    }
}
