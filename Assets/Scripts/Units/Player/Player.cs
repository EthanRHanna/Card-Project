using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit{

    public Class Class;
    public Archetype Archetype;
    public Background Background;
    public Ancestry Ancestry;

    public int CurrentHealth;

    public Player(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills)
         : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills)
    {
        this.Level = Level;

        this.MaxHealth = MaxHealth;
        CurrentHealth = MaxHealth;

        this.AC = AC;

        this.Speed = Speed;
        this.AttackBonus = AttackBonus;

        this.Attributes = Attributes;
        
        this.Saves = new Saves{
            Fortitude = Saves.Fortitude,
            Will = Saves.Will,
            Reflex = Saves.Reflex,
        };

        this.Skills = Skills;

    }

}
