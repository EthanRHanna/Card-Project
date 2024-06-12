using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour{

    public List<Enemy> CurrentEnemies = new List<Enemy>();
    public List<bool> DeadEnemies = new List<bool>();

    private void Start(){
        //The Index of these list should correspond since GetAllDead uses GetAllEnemies like CurrentEnemies
        CurrentEnemies = GetAll.GetAllEnemies();
        DeadEnemies = GetAll.GetAllDeadEnemies();
    }
}
