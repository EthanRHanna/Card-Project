using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour{

    public bool Played = false;
    public int HandIndex;

    private CardManager CM;
    

    void Start(){
        CM = FindObjectOfType<CardManager>();
    }

    //When the mouse clicks the card it moves the card up so user can see it has been played and tells the hand what slot is now free
    //then after 2 Seconds it puts the card into the discard pile
    void OnMouseDown(){
        //Debug.Log(this + " has been Clicked!");
        if(!Played){
            transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.up * 3.3f), 1);

            Played = !Played;
            CM.AvailableCardSlots[HandIndex] = Played;
            CM.CardSlots[HandIndex].gameObject.SetActive(Played);

            Invoke("DiscardCard", 2f);
        }
    }

    //Method for adding the card into the discard pile
    private void DiscardCard(){
        //Debug.Log(this + " has benn Discarded!");

        CM.DiscardPile.Add(this);
        gameObject.SetActive(!Played);
    }
}
