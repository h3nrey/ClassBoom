using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;
    internal Rigidbody2D rb;
    public bool storyMode = true;

    public Vector2 direction;

    // [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer graphic;

    //Childreens
    [SerializeField] internal BombController _bombController;
    [SerializeField] internal PlayerInput _playerInput;
    [SerializeField] internal PlayerAnimation _playerAnimation;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        graphic = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {
        if (_playerInput.movingInputs.x > 0) {
            graphic.flipX = false;
        } else if(_playerInput.movingInputs.x < 0) {
            graphic.flipX = true;
        }

        SetInput();
    }

    void SetInput() {
        direction = _playerInput.movingInputs;
    }
}
