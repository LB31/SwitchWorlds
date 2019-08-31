using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public Slider HealthBar;

    public float MentalHealth = 50;
    public float PhysicalHealth = 50;

    // true = mental; false physical
    public bool KindOfDamage = true;

    private float t;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if(t > 2) {
            t = 0;
            DamagePlayer(KindOfDamage, 5);
        }
        
    }

    // kind true = mental; kind false = physical
    public void DamagePlayer(bool kind, float damage) {
        if (kind) {
            MentalHealth -= damage;
            HealthBar.value -= damage / 100;
        } else {
            PhysicalHealth -= damage;
            HealthBar.value += damage / 100;
        }

        if(HealthBar.value == 1 || HealthBar.value == 0) {
            // TODO player dead
        }
    }
}
