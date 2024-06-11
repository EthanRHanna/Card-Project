using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//-------------- State Stuff --------------\\
public enum TurnState { Start, PlayerTurn, EnemyTurn, Won, Lost}

public class TurnManager : MonoBehaviour{

    public TurnManagerUI TMUI;
    private EnemyManager enemyManager;
    private CardManager cardManager;

    public TurnState state;
    private Player player;
    public List<Unit> InitiativeList = new List<Unit>();

    //-------------- Action Stuff --------------\\
    private const int MaxActions = 3;
    public int CurrentActionCount;

    //------------- End Turn Stuff -------------\\
    public Button EndTurnButton;



    private void Start(){
        state = TurnState.Start;
        CurrentActionCount = 0;

        player = GameObject.Find("Player").GetComponent<Player>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        EndTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();

        //-----Do Start-Up Stuff-----\\

        //Initiative is: 1D20 + Perception Skill Proficency + Wisdom Modifier + Speed/2
        //Initiative is tied to the player and enemy
        //Make a list of everyone and sort from Greatest to Least
        InitiativeList = AllRollInitiative();
        //Debug.Log(InitiativeList.Count);

        StartCoroutine(goingThroughTurnOrder());

    }

    IEnumerator goingThroughTurnOrder(){
        for(int i = 0; i < InitiativeList.Count; i++){
            //Debug.Log(InitiativeList[i] + "'s Turn" + "\nIndex: " + i);

            //Check to see if the current unit is a Player or Enemy
            if(InitiativeList[i] is Enemy){
                //The AI needs to make a move for the forloop to move on.
                Debug.Log("Waiting for Enemy");
                yield return new WaitForSeconds(30);
                Debug.Log("Enemy's Turn is Done");
            }else if(InitiativeList[i] is Player){
                //The forloop needs to wait for the player to hit the End Turn button before it is allowed to continue
                Debug.Log("Waiting for Player");
                yield return new WaitForSeconds(10);
                Debug.Log("Player's Turn is Done");

            }
        }
    }


    public void EndTurn(){
        Debug.Log("Ended Turn!");

        CurrentActionCount = 0;
        TMUI.UpdateActionText();
    }


    //-------- Extra Functions ---------\\
    public bool OverMaxActionCount(){
        return (CurrentActionCount > MaxActions) ? true : false; 
    }

    private List<Unit> AllRollInitiative(){
        List<Unit> InitiativeList = new List<Unit>();

        //All Enemies and Player roll initiative
        foreach(Enemy enemy in enemyManager.getAllEnemies()){
            //enemy.Initiative = 1;
            enemy.rollInitiative();
            //Debug.Log(enemy.Initiative + " " + enemy.name);
            InitiativeList.Add(enemy);
        }

        player.rollInitiative();
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
