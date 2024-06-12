using System.Collections.Generic;

public class CMInvoker{

    CardManager _CardManager;

    public CMInvoker(CardManager cardManager){
        _CardManager = cardManager;
    }
    
    public void DrawCard(){
        DrawCardCommand drawCardCommand = new DrawCardCommand(_CardManager);
        drawCardCommand.Execute();
    }

    public void Shuffle(){
        ShuffleCommand shuffleCommand = new ShuffleCommand(_CardManager);
        shuffleCommand.Execute();
    }

    public void FillHand(){
        FillHandCommand fillHandCommand = new FillHandCommand(_CardManager);
        fillHandCommand.Execute();
    }

}
