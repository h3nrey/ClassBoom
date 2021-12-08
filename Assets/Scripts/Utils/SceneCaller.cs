using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCaller : MonoBehaviour {
    public float SceneTimer = 0;
    [SerializeField] string nameOfTheScene;
    private void Update() {
        if(Input.GetButtonDown("Lauch")) 
            CallScene(nameOfTheScene);
    }
    private IEnumerator CallScene(string sceneName) {
        yield return new WaitForSeconds(SceneTimer);
        SceneManager.LoadScene(sceneName);
    }

    public void CallCoroutine(string sceneName) {
        StartCoroutine(CallScene(sceneName));
    }
    public void setSceneTimer(float cooldown) {
        SceneTimer = cooldown;
        print(SceneTimer);
    }
}
