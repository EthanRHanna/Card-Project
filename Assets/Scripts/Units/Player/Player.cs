using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit{

    public string Class;
    public string Archetype;
    public string Background;
    public string Ancestry;

    public Player(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills) : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills)
    {
    }

}
