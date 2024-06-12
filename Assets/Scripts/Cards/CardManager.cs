using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour{

    private CMInvoker _CMInvoker;

    [SerializeField]
    public Transform[] CardSlots;
    public List<Card> Deck = new List<Card>();
    public bool[] AvailableCardSlots;
    public List<Card> DiscardPile = new List<Card>();


    private void Start(){
        _CMInvoker = new CMInvoker(this);
    }

    //Sets total deck size, and draws cards if there are slots open
    public void GetPlayerHand(){
        Deck = GetAll.GetAllCards();
        _CMInvoker.FillHand();
    }

    //Automaic shuffle to readd cards from the Discard pile when there is more than half of the starting deck inside of the discard pile
    private void Update(){
        if(DiscardPile.Count > Deck.Count / 2){
            Shuffle();
        }
    }

    //Moves cards from the Discard Pile into the Deck to be played again
    private void Shuffle(){
        _CMInvoker.Shuffle();
    }

    

}
