using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardCommand : ICMCommand{

    private CardManager _CardManager;

    public DrawCardCommand(CardManager cardManager){
        _CardManager = cardManager;
    }


    public void Execute()
    {
        if(_CardManager.Deck.Count >= 1){
            Card RandomCard = _CardManager.Deck[Random.Range(0, _CardManager.Deck.Count)];
            //Debug.Log(RandomCard + " has been Drawn!");

            for (int i = 0; i < _CardManager.AvailableCardSlots.Length; i++){
                if(_CardManager.AvailableCardSlots[i]){
                    RandomCard.gameObject.SetActive(true);
                    RandomCard.transform.position = _CardManager.CardSlots[i].position;

                    RandomCard.HandIndex = i;
                    _CardManager.CardSlots[i].gameObject.SetActive(false);
                    

                    _CardManager.AvailableCardSlots[i] = false;
                    _CardManager.Deck.Remove(RandomCard);
                    return;
                }
            }
        }
    }

}
