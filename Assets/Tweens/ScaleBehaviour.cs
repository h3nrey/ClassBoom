using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScaleBehaviour : MonoBehaviour {
    [SerializeField] RectTransform imageForTransition;
    [SerializeField] Vector2 size;
    [SerializeField] float TransitionTime = 0.5f;

    public void Scale() {
        imageForTransition.LeanScale(size, TransitionTime);
    }
    
}
