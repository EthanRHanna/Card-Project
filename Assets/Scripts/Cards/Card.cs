using UnityEngine;

//Redid this Class by implementing the Command Pattern
//This Class is was the Test Class for the Command Pattern, I don't think I needed it but it allowed for more features to be added to this class thanks to it
public class Card : MonoBehaviour{

    public bool Played = false;
    public int HandIndex;

    public CardManager CM;
    public TurnManagerUI TMUI;
    public CardInfo CI;
    private CardInoker _CardInvoker;
    private TurnManager TM;
    

    void Start(){
        CM = FindObjectOfType<CardManager>();
        TM = FindObjectOfType<TurnManager>();
        TMUI = FindObjectOfType<TurnManagerUI>();
        CI = gameObject.GetComponent<CardInfo>();

        
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

        Invoke("DiscardCard", 60f);

    }

    //Method for adding the card into the discard pile
    private void DiscardCard(){
        if (Played){
        Debug.Log(this + " has benn Discarded!");

        CM.DiscardPile.Add(this);
        gameObject.SetActive(!Played);
        }
    }


}