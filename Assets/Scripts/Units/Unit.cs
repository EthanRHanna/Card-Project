using UnityEngine;

public class Unit : MonoBehaviour{

    public int Level;
    public int MaxHealth;
    public int CurrentHealth;
    public int AC;
    public int Speed;
    public int AttackBonus;
    public Attributes Attributes;
    public Saves Saves;
    public Skills Skills;

    public int Initiative;

    public Unit(int Level, int MaxHealth, int AC, int Speed, int AttackBonus ,Attributes Attributes, Saves Saves, Skills Skills){
        this.Level = Level;

        this.MaxHealth = MaxHealth;
        CurrentHealth = MaxHealth;

        this.AC = AC;

        this.Speed = Speed;
        this.AttackBonus = AttackBonus;

        this.Attributes = Attributes;

        this.Saves = Saves;

        this.Skills = Skills;
    }

    public void RollInitiative(){
        //Initiative rolls: 1D20 + Perception Skill Proficency + Wisdom Modifier + Speed/(Some Numnber)
        int SpeedImpact = 5; //Increase to lessen the impact speed has on Intiative
        int Initiative = Random.Range(1, 21) + Skills.proficencytoInt(Skills.Perception) + Level + (Attributes.Wisdom - 10) + (Speed / SpeedImpact);

        /*
        Debug.Log("Total Initiative Roll: " + Initiative + "\n" +
            " D20 Roll: " + Random.Range(1,21) + 
            " Perception Proficency Bonus: " + Skills.proficencytoInt(Skills.Perception) + 
            " Level: " + Level + 
            " Wisdom modifyier: " + (Attributes.Wisdom - 10) + 
            " Speed Modifier: " + (int)(Speed/SpeedImpact));
        */

         this.Initiative = Initiative;
    }

    //Enemy Exclusive Method
    //Each EnemyType will have diffent implentaions of this method, so in their class they will override this method
    public virtual void AITurn(){}
    
}
