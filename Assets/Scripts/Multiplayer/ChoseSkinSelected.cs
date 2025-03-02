using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChoseSkinSelected : MonoBehaviour
{
    [SerializeField] GameObject p1, p2;
    [SerializeField] GameObject storer;
    bool allDone = false;
    [SerializeField] SceneCaller _sceneCaller;

    void Update() {
        if(p1.GetComponent<ChooseSkinController>().selected && p2.GetComponent<ChooseSkinController>().selected) 
            allDone = true;
        else 
            allDone = false;
    }

    public void GoToGame(string sceneName) {
        if(allDone) {
            StorerBehaviour.instance.player1SkinIndex = p1.GetComponent<ChooseSkinController>().skinIndex;
            StorerBehaviour.instance.player2SkinIndex = p2.GetComponent<ChooseSkinController>().skinIndex;
            _sceneCaller.CallCoroutine(sceneName);
        }
    }
}
