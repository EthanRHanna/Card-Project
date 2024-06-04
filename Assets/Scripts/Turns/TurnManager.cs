using System;
using UnityEngine;


//-------------- State Stuff --------------\\
public enum TurnState { Start, PlayerTurn, EnemyTurn, Won, Lost}

public class TurnManager : MonoBehaviour{

    public TurnManagerUI TMUI;

    public TurnState state;

    //-------------- Action Stuff --------------\\
    private const int MaxActions = 3;
    public int CurrentActionCount;


    private void Start(){
        state = TurnState.Start;
        CurrentActionCount = 0;

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

}
