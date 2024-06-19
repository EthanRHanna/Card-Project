

//Moves cards from the Discard Pile into the Deck to be played again
public class ShuffleCommand : ICMCommand{

    private CardManager _CardManager;

    public ShuffleCommand(CardManager cardManager){
        _CardManager = cardManager;
    }

    public void Execute()
    {
        foreach(Card card in _CardManager.DiscardPile){
            card.Played = false;
            _CardManager.Deck.Add(card);
        }

        _CardManager.DiscardPile.Clear();
    }
}