using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCardCommand : ICardCommand{

    private Card card;
    private CardInfo CI;
    private TurnManagerUI TMUI;


    public PreviewCardCommand(Card card){
        this.card = card;
        CI = card.CI;
        TMUI = card.TMUI;
    }


    public void Execute(){
        Debug.Log("Previewing " + card.name);
        TMUI.ShowOnMoreInfo(card.gameObject, CI.CardName, CI.CardDamage, CI.CardElement, CI.CardActionCount.ToString(), CI.isSpell, CI.SpellTier.ToString() );
    }

    public void Undo(){
        Debug.Log("Not Previewing " + card.name);
        TMUI.ShowOnMoreInfo(null, "", "", "", "", false, "");
    }
}
