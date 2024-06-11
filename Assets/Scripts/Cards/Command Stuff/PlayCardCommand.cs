using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCardCommand : ICardCommand{

    Card card;
    CardManager CM;
    CardInfo CI;
    private bool Played;
    private int HandIndex;

    public PlayCardCommand(Card card){
        this.card = card;
        this.HandIndex = card.HandIndex;
        CM = card.CM;
        CI = card.CI;
        this.Played = card.Played;
    }


    public void Execute(){
        //Card will move Up to chow it has been Played
        card.transform.position = Vector3.Lerp(card.transform.position, card.transform.position + (Vector3.up * 3.3f), 1);


        CM.AvailableCardSlots[HandIndex] = Played;
        CM.CardSlots[HandIndex].gameObject.SetActive(Played);

        Debug.Log("Playing " + card.name);
        //Debug.Log(DamageRolls.DamageRoll(CI.CardDamage, null));
    }

    public void Undo(){
        //Card will move Down to chow it has been UnPlayed
        card.transform.position = Vector3.Lerp(card.transform.position, card.transform.position + (Vector3.down * 3.3f), 1);

        CM.AvailableCardSlots[HandIndex] = Played;
        CM.CardSlots[HandIndex].gameObject.SetActive(Played);

        Debug.Log("Not Playing " + card.name);
    }
}
