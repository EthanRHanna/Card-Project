using UnityEngine;


//-------------- State Stuff --------------\\
public enum TurnState { Start, PlayerTurn, EnemyTurn, Won, Lost}

public class TurnManager : MonoBehaviour{

    private TurnManagerUI TMUI;

    public TurnState state;

    //-------------- Action Stuff --------------\\
    private const int MaxActions = 3;
    public int CurrentActionCount;


    private void Start(){
        state = TurnState.Start;
        CurrentActionCount = 0;
    }

    public bool OverMaxActionCount(){
        return (CurrentActionCount > MaxActions) ? true : false; 
    }

    public void EndTurn(){
        Debug.Log("Ended Turn!");
        CurrentActionCount = 0;
        TMUI.UpdateActionText();
    }

}
