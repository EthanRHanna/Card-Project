using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private List<Card> Deck = new List<Card>();
    [SerializeField]
    public Transform[] CardSlots;

    public bool[] AvailableCardSlots;
    public List<Card> DiscardPile = new List<Card>();

    private int TotalDeckAmount;

    //Sets total deck size, and draws cards if there are slots open
    private void Start(){
        Deck = getAllCards();
        //Debug.Log(Deck.Count);
        FillHand();
    }

    //Automaic shuffle to readd cards from the Discard pile when there is more than half of the starting deck inside of the discard pile
    private void Update(){
        if(DiscardPile.Count > TotalDeckAmount / 2){
            Shuffle();
        }
    }

    //Draws a card form the deck and moves it on to the hand postions
    private void DrawCard(){
        if(Deck.Count >= 1){
            Card RandomCard = Deck[Random.Range(0, Deck.Count)];
            //Debug.Log(RandomCard + " has been Drawn!");

            for (int i = 0; i < AvailableCardSlots.Length; i++){
                if(AvailableCardSlots[i]){
                    RandomCard.gameObject.SetActive(true);
                    RandomCard.transform.position = CardSlots[i].position;

                    RandomCard.HandIndex = i;
                    CardSlots[i].gameObject.SetActive(false);
                    

                    AvailableCardSlots[i] = false;
                    Deck.Remove(RandomCard);
                    return;
                }
            }
        }
    }

    //Moves cards from the Discard Pile into the Deck to be played again
    private void Shuffle(){
        Debug.Log("Suffle!");
        foreach(Card card in DiscardPile){
            card.Played = false;
            Deck.Add(card);
        }

        DiscardPile.Clear();
    }

    private List<Card> getAllCards(){
        List<Card> AllCards = new List<Card>();
        GameObject DeckOfCards = GameObject.Find("Player Deck");

        for(int i = 0; i < DeckOfCards.transform.childCount; i++ ){
            //Debug.Log(DeckOfCards.transform.GetChild(i).GetComponent<Card>());
            AllCards.Add(DeckOfCards.transform.GetChild(i).GetComponent<Card>());
        }

        return AllCards;
    }

    public void FillHand(){
        TotalDeckAmount = Deck.Count;

        foreach(bool Slot in AvailableCardSlots){
            if(Slot)
                DrawCard();
        }
    }

}
