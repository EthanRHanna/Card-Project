using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour{

    private const int MaxActions = 3;

    public int CurrentActionCount;

    //-------------- UI Stuff --------------\\
    [SerializeField]
    public GameObject ShownActionCount;

    [SerializeField]
    public GameObject CardViewer;

    [SerializeField]
    public GameObject Name;

    [SerializeField]
    public GameObject Damage;

    [SerializeField]
    public GameObject Element;

    [SerializeField]
    public GameObject ActionCost;

    [SerializeField]
    public GameObject IsSpell;

    [SerializeField]
    public GameObject SpellTier;
    // -------------------------------------\\

    private void Start(){
        CurrentActionCount = 0;
    }

    public void UpdateActionText(){
        ShownActionCount.GetComponent<TextMeshProUGUI>().text = CurrentActionCount.ToString();
    }

    public void ShowOnMoreInfo(GameObject Card, String CardName, String CardDamage, String CardElement, String CardActionCost, bool CardSpell, String CardSpellTier){
        CardViewer.GetComponent<Image>().sprite = Card.GetComponent<SpriteRenderer>().sprite;

        Name.GetComponent<TextMeshProUGUI>().text = "Card Name: " + CardName;
        Damage.GetComponent<TextMeshProUGUI>().text = "Card Damage: " + CardDamage;
        Element.GetComponent<TextMeshProUGUI>().text = "Card Element: " + CardElement;
        ActionCost.GetComponent<TextMeshProUGUI>().text = "Card Action Cost: " + CardActionCost;

        if (CardSpell)
            IsSpell.GetComponent<TextMeshProUGUI>().text = "It is a Spell";
        else
            IsSpell.GetComponent<TextMeshProUGUI>().text = "It is not a Spell";
        
        SpellTier.GetComponent<TextMeshProUGUI>().text = "Card Spell Tier: " + CardSpellTier;

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
