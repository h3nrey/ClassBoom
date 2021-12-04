using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    [Header("Flame")]
    [SerializeField] GameObject sparkle;
    [SerializeField] GameObject sparkleHolder;
    [SerializeField] float sparkleDelay;  
    [SerializeField] int totalOfFlames;
    void Start() {

        InvokeRepeating("InstantiateSparkles", 0.1f, sparkleDelay);
    }

    void Update() {
        DestroySparkles();
    }

    private void InstantiateSparkles() {
        GameObject flameChild = Instantiate(sparkle, transform.position, Quaternion.identity) as GameObject;
        flameChild.transform.SetParent(sparkleHolder.transform, true);
    }

    private void DestroySparkles(){
        if(sparkleHolder.transform.childCount > totalOfFlames)
            Destroy(sparkleHolder.transform.GetChild(1).gameObject);
    }
}
