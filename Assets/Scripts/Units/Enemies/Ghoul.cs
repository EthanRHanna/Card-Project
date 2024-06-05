using UnityEngine;
using UnityEngine.UI;

public class Ghoul : Enemy
{

    [SerializeField]
    public string BasicAttackDamage;

    public Ghoul(int Level, int MaxHealth, int AC, int Speed, int AttackBonus, Attributes Attributes, Saves Saves, Skills Skills) : base(Level, MaxHealth, AC, Speed, AttackBonus, Attributes, Saves, Skills)
    {
    }

}
   
