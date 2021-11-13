using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    [SerializeField] private string transitionName = "Fade"; 
    void Start() {
        switch (transitionName) {
            case "Fade": UITweensController.instance.Fade(); break;
            case "Scale": UITweensController.instance.Scale(); break;
        }
    }
}
