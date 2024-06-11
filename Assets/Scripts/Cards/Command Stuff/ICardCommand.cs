using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardCommand{

    void Execute();
    void Undo();

}
