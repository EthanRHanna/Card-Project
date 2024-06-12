using System.Collections.Generic;

public class CardInoker{

    Stack<ICardCommand> _CommandList;
    ICardCommand _OnCommand;

    public CardInoker(){
        _CommandList = new Stack<ICardCommand>();
    }

    public void AddCommand(ICardCommand newCommand){
        newCommand.Execute();
        _CommandList.Push(newCommand);
    }

    public void RemoveCommand(){
        ICardCommand lastCommand = _CommandList.Pop();
        lastCommand.Undo();
    }
}
