using System;
using UnityEngine;

public class Card : MonoBehaviour{

    public bool Played = false;
    public int HandIndex;
    public int CardActionCount;

    public CardManager CM;
    private TurnManager TM;
    public TurnManagerUI TMUI;
    public CardInfo CI;
    private CardInoker _CardInvoker;
    

    void Start(){
        CM = FindObjectOfType<CardManager>();
        TM = FindObjectOfType<TurnManager>();
        TMUI = FindObjectOfType<TurnManagerUI>();
        CI = gameObject.GetComponent<CardInfo>();
        CardActionCount = gameObject.GetComponent<CardInfo>().CardActionCount;

        
        _CardInvoker = new CardInoker();
    }

    //When the mouse clicks the card it moves the card up so user can see it has been played and tells the hand what slot is now free
    //then after 2 Seconds it puts the card into the discard pile

    //When the card is clicked it should run the Command PlayCard
    void OnMouseDown(){
        PlayCardCommand _PlayCardCommand = new PlayCardCommand(this);
        PreviewCardCommand _PreviewCardCommand = new PreviewCardCommand(this);

        if (!Played){
            Played = !Played;
            _CardInvoker.AddCommand(_PreviewCardCommand);
            _CardInvoker.AddCommand(_PlayCardCommand);
        }
        else{
            Played = !Played;
            _CardInvoker.RemoveCommand();
            _CardInvoker.RemoveCommand();
        }

    }

   

    //Method for adding the card into the discard pile
    private void DiscardCard(){
        //Debug.Log(this + " has benn Discarded!");

        CM.DiscardPile.Add(this);
        gameObject.SetActive(!Played);
    }


}
/*

//Debug.Log(this + " has been Clicked!");
        if(!Played){

            Played = !Played;
            transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.up * 3.3f), 1);

            TM.CurrentActionCount += CardActionCount;

            //Check to see if there is enough action points left to play the card the user selected
            if(TM.OverMaxActionCount()){
                Played = !Played;
                transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.down * 3.3f), 1);

                Debug.Log("Exceeds Max Action Count");
                TM.CurrentActionCount -= CardActionCount;

                return;
            }

            //Updates the Action text to show how much is left
            TMUI.UpdateActionText();

            CM.AvailableCardSlots[HandIndex] = Played;
            CM.CardSlots[HandIndex].gameObject.SetActive(Played);
            

            Debug.Log(DamageRoll(CI.CardDamage));
            Invoke("DiscardCard", 2f);
        }

        */