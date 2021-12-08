using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour {
    [SerializeField] float time = 5f;
    [SerializeField] TMP_Text timerText;

    private SceneCaller _sceneCaller;
    [SerializeField] private Animator timeAnimation;

    void Start() {
        _sceneCaller = FindObjectOfType<SceneCaller>();
        timerText.text = time.ToString();
    }

    // Update is called once per frame
    void Update() {
        if(time > 0) {
            time -= Time.deltaTime;
            int roundedTime = (int)time;
            timerText.text = roundedTime.ToString();

            if(time <= 0) {
                timeAnimation.SetTrigger("timesup");
                _sceneCaller.setSceneTimer(1.5f);
                _sceneCaller.CallCoroutine("GameOver");
            }
        } 
    }
}
