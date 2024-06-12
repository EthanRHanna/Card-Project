using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GetAll{
   
    //Looks of "Player Deck" and takes all of it's children as cards to fill the Deck list without someone setting it in the inspector
    public static List<Card> GetAllCards(){
        List<Card> AllCards = new List<Card>();
        GameObject DeckOfCards = GameObject.Find("Player Deck");

        for(int i = 0; i < DeckOfCards.transform.childCount; i++ ){
            //Debug.Log(DeckOfCards.transform.GetChild(i).GetComponent<Card>());
            AllCards.Add(DeckOfCards.transform.GetChild(i).GetComponent<Card>());
        }

        return AllCards;
    }

    //Looks of "Enemies" and takes all of it's children as Enemy to fill the CurrentEnemies list without someone setting it in the inspector
    public static List<Enemy> GetAllEnemies(){
        List<Enemy> AllEnemies = new List<Enemy>();
        GameObject EnemyPool = GameObject.Find("Enemies");

        for(int i = 0; i < EnemyPool.transform.childCount; i++ ){
            //Debug.Log(EnemyPool.transform.GetChild(i).GetComponent<Enemy>());
            AllEnemies.Add(EnemyPool.transform.GetChild(i).GetComponent<Enemy>());
        }

        return AllEnemies;
    }


    //Looks of "Enemies" and takes all of it's children as Enemy to fill the CurrentEnemies list without someone setting it in the inspector
    public static List<bool> GetAllDeadEnemies(){
        List<bool> AllDeadEnmeies = new List<bool>();
        List<Enemy> AllEnemies = GetAllEnemies();

        foreach(Enemy enemy in AllEnemies){
            if(enemy.CurrentHealth <= 0){
                AllDeadEnmeies.Add(true);
            }else{
                AllDeadEnmeies.Add(false);
            }
        }

        return AllDeadEnmeies;
    }

}
