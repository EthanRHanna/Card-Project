using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHandCommand : ICMCommand{

    private CardManager _CardManager;
    
    public FillHandCommand(CardManager cardManager){
        _CardManager = cardManager;
    }

    public void Execute()
    {
        DrawCardCommand drawCardCommand = new DrawCardCommand(_CardManager);

        foreach(bool Slot in _CardManager.AvailableCardSlots){
            if(Slot)
                drawCardCommand.Execute();
        }
    }
}
