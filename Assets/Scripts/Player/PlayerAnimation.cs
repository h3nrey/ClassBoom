using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Animator transitionAnim;
    [SerializeField] PlayerBehaviour _playerBehaviour;

    void Start() {
        anim = GetComponentInChildren<Animator>();
    }
    void Update() {
        anim.SetFloat("xVelocity", Mathf.Abs(_playerBehaviour.direction.x));
        anim.SetFloat("yVelocity", _playerBehaviour.direction.y);
        anim.SetFloat("speed", _playerBehaviour.direction.SqrMagnitude());
    }

    public void WinThePhase() {
        anim.SetTrigger("winning");
        GameObject.FindGameObjectWithTag("WinDoor").GetComponent<Animator>().SetTrigger("winning");
        transitionAnim.SetTrigger("rewinding");
    }
}
