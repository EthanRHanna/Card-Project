using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    public List<Card> Deck = new List<Card>();
    [SerializeField]
    public Transform[] CardSlots;


    public bool[] AvailableCardSlots;

    void Start(){
        DrawCard();
    }

    public void DrawCard(){
        if(Deck.Count >= 1){
            Card RandomCard = Deck[Random.Range(0, Deck.Count)];

            for (int i = 0; i < AvailableCardSlots.Length; i++){
                if(AvailableCardSlots[i]){
                    RandomCard.gameObject.SetActive(true);
                    RandomCard.transform.position = CardSlots[i].position;

                    RandomCard.HandIndex = i;
                    CardSlots[i].gameObject.SetActive(false);
                    

                    AvailableCardSlots[i] = false;
                    //Deck.Remove(RandomCard);
                    return;
                }
            }
        }
    }
}
