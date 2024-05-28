using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : Enemy{

    public Ghoul(int Level, int MaxHealth, int AC, int Speed) : base(Level, MaxHealth, AC, Speed){
        Attributes = gameObject.GetComponent<Attributes>();
        Saves = gameObject.GetComponent<Saves>();
        Skills = gameObject.GetComponent<Skills>();
    }
}
   
