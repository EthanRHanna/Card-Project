using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Unit{

    private int LevelModifier;

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

    public void basicAttack(string Damage){
        rollingDamage(Damage);
    }

    public int rollingDamage(string UnrolledDamage){

        //Debug.Log(UnrolledDamage); test

        int Damage  = 0;
        var DamageTuple = ParseDamge(UnrolledDamage.ToUpper());
        int AmountofDice = DamageTuple.Item1;
        int TypeofDice = DamageTuple.Item2;
        int ExtraDamage = DamageTuple.Item3;

        for(int i = 0; i < AmountofDice; i++){
            Damage += UnityEngine.Random.Range(1, TypeofDice+1);
        }

        //Debug.Log("Total Damage: "  + (Damage + LevelModifier + ExtraDamage) + "\nRolled Damage: " + Damage + ", Level Modifier: " + LevelModifier + ", Extra Damage: " +  ExtraDamage );
        return Damage + LevelModifier + ExtraDamage;
    }

    private Tuple<int, int, int> ParseDamge(String UnrolledDamage){
        String Amount = UnrolledDamage.Substring(0, UnrolledDamage.IndexOf("D"));
        //Debug.Log(Amount);
        String Type = UnrolledDamage.Substring(UnrolledDamage.IndexOf("D") + 1, 1);
        //Debug.Log(Type);
        String Extra = UnrolledDamage.Substring(UnrolledDamage.IndexOf("+") + 1);
        //Debug.Log(Extra);

        return Tuple.Create(Convert.ToInt32(Amount), Convert.ToInt32(Type), Convert.ToInt32(Extra));
    }



}
