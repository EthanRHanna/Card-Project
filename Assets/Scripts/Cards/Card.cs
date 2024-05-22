using System;
using UnityEngine;

public class Card : MonoBehaviour{

    public bool Played = false;
    public int HandIndex;
    public int CardActionCount;

    private CardManager CM;
    private TurnManager TM;
    private CardInfo CI;
    

    void Start(){
        CM = FindObjectOfType<CardManager>();
        TM = FindObjectOfType<TurnManager>();
        CI = gameObject.GetComponent<CardInfo>();
        CardActionCount = gameObject.GetComponent<CardInfo>().CardActionCount;
    }

    //When the mouse clicks the card it moves the card up so user can see it has been played and tells the hand what slot is now free
    //then after 2 Seconds it puts the card into the discard pile
    void OnMouseDown(){
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
            TM.UpdateActionText();
            TM.ShowOnMoreInfo(gameObject, CI.CardName, CI.CardDamage, CI.CardElement, CI.CardActionCount.ToString(), CI.isSpell, CI.SpellTier.ToString() );

            CM.AvailableCardSlots[HandIndex] = Played;
            CM.CardSlots[HandIndex].gameObject.SetActive(Played);
            

            Debug.Log(DamageRoll(CI.CardDamage));
            Invoke("DiscardCard", 2f);
        }
    }

    //Method for adding the card into the discard pile
    private void DiscardCard(){
        //Debug.Log(this + " has benn Discarded!");

        CM.DiscardPile.Add(this);
        gameObject.SetActive(!Played);
    }

    //"Rolls" the damage for the card that is played
    private int DamageRoll(String UnrolledDamage){
        int Damage  = 0;
        var DamageTuple = ParseDamge(UnrolledDamage.ToUpper());
        int AmountofDice = DamageTuple.Item1;
        int TypeofDice = DamageTuple.Item2;

        for(int i = 0; i < AmountofDice; i++){
            Damage += UnityEngine.Random.Range(1, TypeofDice+1);
        }

        return Damage;
    }

    //Uses Tuple to get mutiple returns from the function
    //Get the Amount of Dice and the Type of dice from CardDamage in CardInfo
    private Tuple<int, int> ParseDamge(String UnrolledDamage){
        String Amount = UnrolledDamage.Substring(0, UnrolledDamage.IndexOf("D"));
        //Debug.Log(Amount);
        String Type = UnrolledDamage.Substring(UnrolledDamage.IndexOf("D") + 1);
        //Debug.Log(Type);

        return Tuple.Create(Convert.ToInt32(Amount), Convert.ToInt32(Type));
    }

    private void MoreInfo(){
        GameObject.Find("Card Viewer");
    }
}
