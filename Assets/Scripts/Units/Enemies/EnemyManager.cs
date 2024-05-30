using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour{

    public List<Enemy> CurrentEnemies = new List<Enemy>();
    public List<bool> DeadEnemies = new List<bool>();


    public bool allEnemiesDead(){
        bool AllDead = false;

        foreach (bool Status in DeadEnemies){
            if(Status){
                AllDead = true;
            }else{
                return false;
            }
        }

        return AllDead;
    }

    
}
