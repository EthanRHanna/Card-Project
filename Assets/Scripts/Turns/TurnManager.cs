using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.ProjectWindowCallback;
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
    private bool EndedTurn = false;



    private void Start(){
        state = TurnState.Start;
        CurrentActionCount = 0;

        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();

        //-----Do Start-Up Stuff-----\\

        //Initiative is: 1D20 + Perception Skill Proficency + Wisdom Modifier + Speed/2
        //Initiative is tied to the player and enemy
        //Make a list of everyone and sort from Greatest to Least
        InitiativeList = GetAll.GetInitiativeOrder();

        StartCoroutine(WhosTurn());
    }

    IEnumerator GetttingPlayerHand(){
        yield return null; 
        cardManager.GetPlayerHand();
        yield return new WaitUntil(() => EndedTurn);
    }

    IEnumerator WhosTurn(){
        for(int i = 0; i < InitiativeList.Count; i++){
            var unit = InitiativeList[i];
            if(unit is Player){
                state = TurnState.PlayerTurn;
                Debug.Log(state);

                yield return StartCoroutine(GetttingPlayerHand());

                EndedTurn = false;
            }else if(unit is Enemy){
                state = TurnState.EnemyTurn;
                Debug.Log(state);
                
                unit.AITurn();
            }
        }
    }


    public void EndTurn(){
        Debug.Log("Ended Turn!");
        StopCoroutine(GetttingPlayerHand());

        CurrentActionCount = 0;
        TMUI.UpdateActionText();

        EndedTurn = true;
    }


    //-------- Extra Functions ---------\\
    public bool OverMaxActionCount(){
        return (CurrentActionCount > MaxActions) ? true : false; 
    }


}
