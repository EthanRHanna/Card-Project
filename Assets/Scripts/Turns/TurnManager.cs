using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour{

    private const int MaxActions = 3;

    public int CurrentActionCount;

    [SerializeField]
    public GameObject ShownActionCount;

    [SerializeField]
    public GameObject MoreInfoPanel;

    private void Start(){
        CurrentActionCount = 0;
    }

    public void UpdateActionText(){
        ShownActionCount.GetComponent<TextMeshProUGUI>().text = CurrentActionCount.ToString();
    }

    public bool OverMaxActionCount(){
        return (CurrentActionCount > MaxActions) ? true : false; 
    }

    public void EndTurn(){
        Debug.Log("Ended Turn!");
        CurrentActionCount = 0;
        UpdateActionText();
    }

}
