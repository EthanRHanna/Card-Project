using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour{

    private CMInvoker _CMInvoker;
    
    [SerializeField]
    public Transform[] CardSlots;
    public List<Card> Deck = new List<Card>();
    public bool[] AvailableCardSlots;
    public List<Card> DiscardPile = new List<Card>();

    void Start(){
        _CMInvoker = new CMInvoker(this);
    }

    //Sets total deck size, and draws cards if there are slots open
    public void GetPlayerHand(){
        _CMInvoker = new CMInvoker(this);
        FillHandCommand fillHandCommand = new FillHandCommand(this);
        Deck = GetAll.GetAllCards();

        _CMInvoker.FillHand();
    }

    //Automaic shuffle to readd cards from the Discard pile when there is more than half of the starting deck inside of the discard pile
    private void Update(){
        ShuffleCommand shuffleCommand = new ShuffleCommand(this);
        if(DiscardPile.Count > Deck.Count / 2){
            _CMInvoker.Shuffle();
        }
    }

}
