using UnityEngine;
using UnityEngine.UI;

public class Ghoul : Enemy{

    public Ghoul(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills)
        : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills){}

    public override void AITurn(){
        if(Random.Range(1,3) == 1){
            Debug.Log("Claws!\nDamage: " + ClawMelee());
            //ClawMelee();
        }else{
            Debug.Log("Jaws!\nDamage: " + JawsMelee());
            //JawsMelee();
        }
    }

    //The Attacks the ghoul can make
    public int ClawMelee(){
        return DamageRolls.DamageRoll("1D4+1", LevelModifier);
    }
    public int JawsMelee(){
        return DamageRolls.DamageRoll("1D6+1", LevelModifier);
    }

}
   
