using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit{

    public int LevelModifier;

    public Enemy(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills) : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills)
    {
        this.Level = Level;
        LevelModifier = Level - 1;

        this.MaxHealth = MaxHealth;
        CurrentHealth = MaxHealth;

        this.AC = AC + LevelModifier;

        this.Speed = Speed;
        this.AttackBonus = AttackBonus + LevelModifier;

        this.Attributes = Attributes;
        
        this.Saves = new Saves{
            Fortitude = Saves.Fortitude + LevelModifier,
            Will = Saves.Will + LevelModifier,
            Reflex = Saves.Reflex + LevelModifier,
        };

        this.Skills = Skills;
    }

}
