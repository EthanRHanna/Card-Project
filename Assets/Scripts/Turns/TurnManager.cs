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
    private CardManager cardManager;

    public TurnState state;
    public List<Unit> InitiativeList = new List<Unit>();

    //-------------- Action Stuff --------------\\
    private const int MaxActions = 3;
    public int CurrentActionCount;

    //------------- End Turn Stuff -------------\\
    public Button EndTurnButton;



    private void Start(){
        state = TurnState.Start;
        CurrentActionCount = 0;

        
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        EndTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();

        //-----Do Start-Up Stuff-----\\

        //Initiative is: 1D20 + Perception Skill Proficency + Wisdom Modifier + Speed/2
        //Initiative is tied to the player and enemy
        //Make a list of everyone and sort from Greatest to Least
        InitiativeList = GetAll.GetInitiativeOrder();
        //Debug.Log(InitiativeList.Count);

        StartCoroutine(GetttingPlayerHand());
    }

    IEnumerator GetttingPlayerHand(){
        yield return null;
        cardManager.GetPlayerHand();
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


}
