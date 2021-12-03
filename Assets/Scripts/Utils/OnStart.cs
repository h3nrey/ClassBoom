using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    [SerializeField] private string[] transitionsName = {"Fade"}; 
    void Start() {
        if(transitionsName.Length >= 1) {
            for (int i = 0; i < transitionsName.Length; i++) {
                UITweensController.instance.Invoke($"{transitionsName[i]}",0f);
            }
            // switch (transitionsName[0]) {
            //     case $"Fade": UITweensController.instance.Fade(); break;
            //     case "Scale": UITweensController.instance.Scale(); break;
            // }
        } 
    }
}
