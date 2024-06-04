using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnManagerUI : MonoBehaviour{

    public TurnManager TM;

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


    public void UpdateActionText(){
        ShownActionCount.GetComponent<TextMeshProUGUI>().text = TM.CurrentActionCount.ToString();
    }

    public void ShowOnMoreInfo(GameObject Card, String CardName, String CardDamage, String CardElement, String CardActionCost, bool CardSpell, String CardSpellTier){
        if (Card){
            CardViewer.GetComponent<Image>().sprite = Card.GetComponent<SpriteRenderer>().sprite;

            Name.GetComponent<TextMeshProUGUI>().text = "Card Name: " + CardName;
            Damage.GetComponent<TextMeshProUGUI>().text = "Card Damage: " + CardDamage;
            Element.GetComponent<TextMeshProUGUI>().text = "Card Element: " + CardElement;
            ActionCost.GetComponent<TextMeshProUGUI>().text = "Card Action Cost: " + CardActionCost;

            if (CardSpell){
                IsSpell.GetComponent<TextMeshProUGUI>().text = "It is a Spell";
                SpellTier.GetComponent<TextMeshProUGUI>().text = "Card Spell Tier: " + CardSpellTier;
            }else{
                IsSpell.GetComponent<TextMeshProUGUI>().text = "It is not a Spell";
                SpellTier.GetComponent<TextMeshProUGUI>().text = null;
            }
            
        }else{
            CardViewer.GetComponent<Image>().sprite = null;
            Name.GetComponent<TextMeshProUGUI>().text = null;
            Damage.GetComponent<TextMeshProUGUI>().text = null;
            Element.GetComponent<TextMeshProUGUI>().text = null;
            ActionCost.GetComponent<TextMeshProUGUI>().text = null;
            IsSpell.GetComponent<TextMeshProUGUI>().text = null;
            SpellTier.GetComponent<TextMeshProUGUI>().text = null;
        }

    }
}
