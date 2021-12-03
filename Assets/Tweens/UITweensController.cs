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
    [SerializeField] float fadeDuration = 0.5f;
    [SerializeField] CanvasGroup imageForFade;   
    [SerializeField] float fadeEndPoint;

    [Header("Move")]
    [SerializeField] GameObject objectToBeMoved;
    [SerializeField] Vector3 ObjectPos;
    [SerializeField] float moveDuration = 0.5f;
    [SerializeField] LeanTweenType moveEaseType;

    [Header("Rotate")]
    [SerializeField] Vector3 ObjectRotation;
    private void Awake() {
        instance = this;
    }
    
    public void Scale() {
        imageForScale.LeanScale(size, duration).setEase(easeType);
    }

    public void Rotate() {
        imageForScale.LeanRotate(ObjectRotation, duration);
    }

    public void Move() {
        objectToBeMoved.LeanMove(ObjectPos, moveDuration).setEase(moveEaseType);
    }
    public void Fade(){
        imageForFade.LeanAlpha(fadeEndPoint, fadeDuration).setEase(easeType);
    }
}
