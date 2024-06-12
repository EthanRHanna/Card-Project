using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit{

    public Class Class;
    public string Archetype;
    public Background Background;
    public Ancestry Ancestry;

    public Player(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills) : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills)
    {
    }

}
