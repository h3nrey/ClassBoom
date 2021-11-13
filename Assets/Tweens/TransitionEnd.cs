using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEnd : MonoBehaviour {
    [SerializeField] RectTransform imageForTransition;
    [SerializeField] Vector2 size;
    [SerializeField] float TransitionTime = 0.5f;
    void Start() {
        ShortDown();
    }

    public void ShortDown() {
        imageForTransition.LeanScale(Vector2.zero, TransitionTime);
    }
}
