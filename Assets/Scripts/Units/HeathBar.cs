using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour{
    private Slider HealthBar;

    public Enemy enemy;

    private void Start(){
        HealthBar = gameObject.GetComponent<Slider>();

        HealthBar.maxValue = enemy.MaxHealth;
        HealthBar.value = enemy.CurrentHealth;
    }

    private void Update(){
        HealthBar.value = enemy.CurrentHealth;
    }

}
