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

        StartCoroutine(GetttingPlayerHand());
        StopCoroutine(GetttingPlayerHand());
    }

    IEnumerator GetttingPlayerHand(){
        yield return null;
        cardManager.GetPlayerHand();
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
