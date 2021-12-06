using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour {
    [SerializeField] int life = 1;
    private int currentLife;

    [Header("Player")]
    [SerializeField] private bool isPlayer;
    [SerializeField] private TMP_Text lifeUI;
    [SerializeField] private Color[] cores;
    [SerializeField] private int tempoDePiscada;
    [SerializeField] SpriteRenderer spr;
    void Start() {
        currentLife = life;
    }

    public void TakeDamage(int damage) {
        currentLife -= damage;
        if(isPlayer){
            lifeUI.text = currentLife.ToString();
            GetComponent<PlayerCollision>().Respawn();
        }
        StartCoroutine(BlinkEffect(cores, tempoDePiscada));

        if (currentLife == 0) {
            Death();
        }
    }
    
    private void Death() {
        Destroy(this.gameObject);
        if(isPlayer) {
            FindObjectOfType<SceneCaller>().CallCoroutine("GameOver");
        }
    }

    public IEnumerator BlinkEffect(Color[] colors, int blinkTime = 6) {
        for (int i = 0; i < blinkTime; i++) {
            foreach (Color color in colors) {
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
        }

        spr.color = Color.white;
    }
}
