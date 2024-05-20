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

    void OnMouseDown(){
        Debug.Log("Been Clicked");
        if(!Played){
            transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.up * 3.3f), 1);

            Played = !Played;
            CM.AvailableCardSlots[HandIndex] = Played;
            CM.CardSlots[HandIndex].gameObject.SetActive(Played);

        }
    }
}
