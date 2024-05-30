using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ghoul : Enemy
{
    public Ghoul(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills) : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills)
    {
    }

    private void OnEnable(){
        Ghoul AGhoul = new Ghoul(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills);

        AGhoul.basicAttack();
    }
    
}
   
