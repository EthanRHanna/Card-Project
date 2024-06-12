using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//A Class that Should house any GetAll method that might be used accrossed this project
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

    //Gets the Player and All Enemies in the Scene and rolls Initiative for them and orders the list to match an Initiative List (Highest to Lowest)
    public static List<Unit> GetInitiativeOrder(){
        List<Unit> InitiativeList = new List<Unit>();
        
        var player = GameObject.Find("Player").GetComponent<Player>();
        var enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        //All Enemies and Player roll initiative
        foreach(Enemy enemy in GetAllEnemies()){
            //enemy.Initiative = 1;
            enemy.RollInitiative();
            //Debug.Log(enemy.Initiative + " " + enemy.name);
            InitiativeList.Add(enemy);
        }

        player.RollInitiative();
        //Debug.Log(player.Initiative + "" + player.name);
        InitiativeList.Add(player);

        //Sort Initiative List by Highest Initiative to Lowest
        InitiativeList = InitiativeList.OrderBy(x => x.Initiative).ToList();
        InitiativeList.Reverse();

        
        //Uses this to check the order of Initiative (High to Low)
        for(int i = 0; i < InitiativeList.Count; i++){
            Debug.Log(InitiativeList[i].name + " " + InitiativeList[i].Initiative +  "\nOrder in List: " + i);
        }
        
        return InitiativeList;
    }

}
