using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour{

    public List<Enemy> CurrentEnemies = new List<Enemy>();
    public List<bool> DeadEnemies = new List<bool>();

    private void Start(){
        CurrentEnemies = getAllEnemies();
    }

    public bool areAllEnemiesDead(){
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

    //Looks of "Enemies" and takes all of it's children as Enemy to fill the CurrentEnemies list without someone setting it in the inspector
    private List<Enemy> getAllEnemies(){
        List<Enemy> AllEnemies = new List<Enemy>();
        GameObject EnemyPool = GameObject.Find("Enemies");

        for(int i = 0; i < EnemyPool.transform.childCount; i++ ){
            //Debug.Log(EnemyPool.transform.GetChild(i).GetComponent<Enemy>());
            AllEnemies.Add(EnemyPool.transform.GetChild(i).GetComponent<Enemy>());
        }

        return AllEnemies;
    }

}
