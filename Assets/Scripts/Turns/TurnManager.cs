using System;
using System.Collections.Generic;
using UnityEngine;


//-------------- State Stuff --------------\\
public enum TurnState { Start, PlayerTurn, EnemyTurn, Won, Lost}

public class TurnManager : MonoBehaviour{

    public TurnManagerUI TMUI;
    public TurnState state;
    private Player player;
    private EnemyManager enemyManager;
    public List<Unit> InitiativeList = new List<Unit>();

    //-------------- Action Stuff --------------\\
    private const int MaxActions = 3;
    public int CurrentActionCount;


    private void Start(){
        state = TurnState.Start;
        CurrentActionCount = 0;

        player = GameObject.Find("Player").GetComponent<Player>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        InitiativeList = allRollInitiative();
        //Debug.Log(InitiativeList.Count);
        //Do Start-Up Stuff

        //Initiative is: 1D20 + Perception Skill Proficency + Wisdom Modifier + Speed/2
        //Make a list of everyone and sort from Greatest to Least
        //Follow this list from left to right

        //Initiative is tied to the player and enemy
    }

    public void EndTurn(){
        Debug.Log("Ended Turn!");

        CurrentActionCount = 0;
        TMUI.UpdateActionText();
        /*
        if(EnemyManager.areAllEnemiesDead()){
            state = TurnState.Won;
        }else{
            state = TurnState.EnemyTurn;
        }
        */
    } 


    //-------- Extra Functions ---------\\
    public bool OverMaxActionCount(){
        return (CurrentActionCount > MaxActions) ? true : false; 
    }

    private List<Unit> allRollInitiative(){
        List<Unit> InitiativeList = new List<Unit>();

        //All Enemies and Player roll initiative
        player.rollInitiative();
        Debug.Log(player.Initiative + "" + player.name);
        InitiativeList.Add(player);

        foreach(Enemy enemy in enemyManager.getAllEnemies()){
            enemy.rollInitiative();
            Debug.Log(enemy.Initiative + " " + enemy.name);
            InitiativeList.Add(enemy);
        }

        //Sort Initiative List by Highest Initiative to Lowest
        //InitiativeList.Sort(x -> x.Initiative);
        InitiativeList.Reverse();

        return InitiativeList;
    }

}
