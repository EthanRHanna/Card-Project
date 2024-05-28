using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Enemy : MonoBehaviour{

    public int Level;
    public int MaxHealth;
    public int AC;
    public int Speed;
    public Attributes Attributes;
    public Saves Saves;
    public Skills Skills;

    public Enemy(int Level, int MaxHealth, int AC, int Speed){
        this.Level = Level;
        this.MaxHealth = MaxHealth;
        this.AC = AC;
        this.Speed = Speed;
    }

}
