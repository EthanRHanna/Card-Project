using System;

//A class that houses the Parser and the roller for Damage Rolls in this project
public static class DamageRolls{
    
    //Takes in a Damage String like: 2D6+1, 2D6, 2d6. And Parses and rolls the damage using math.random range.
    public static int DamageRoll(String UnrolledDamage, int? LevelModifier){
        //Enemies may have a LevelModifier that gives them a flat damage buff, but players will not
        int Damage  = 0;

        //If there is a Attack damage bonus then it uses this method to get the correct damage.
        if(UnrolledDamage.Contains("+")){
            var DamageTuple = ParseDamgePlusBonus(UnrolledDamage.ToUpper());

            int AmountofDice = DamageTuple.Item1;
            int TypeofDice = DamageTuple.Item2;
            int ExtraDamage = DamageTuple.Item3;

            for(int i = 0; i < AmountofDice; i++){
                Damage += UnityEngine.Random.Range(1, TypeofDice+1);
            }

            if (LevelModifier == null)
                LevelModifier = 0;

            return (int)(Damage + LevelModifier + ExtraDamage);
        }else{
            var DamageTuple = ParseDamge(UnrolledDamage.ToUpper());

            int AmountofDice = DamageTuple.Item1;
            int TypeofDice = DamageTuple.Item2;

            for(int i = 0; i < AmountofDice; i++){
                Damage += UnityEngine.Random.Range(1, TypeofDice+1);
            }

            return Damage;
        }
    }

    //Uses Tuple to get mutiple returns from the functions
    private static Tuple<int, int> ParseDamge(String UnrolledDamage){
        String Amount = UnrolledDamage.Substring(0, UnrolledDamage.IndexOf("D"));
        //Debug.Log(Amount);
        String Type = UnrolledDamage.Substring(UnrolledDamage.IndexOf("D") + 1);
        //Debug.Log(Type);

        return Tuple.Create(Convert.ToInt32(Amount), Convert.ToInt32(Type));
    }
    private static Tuple<int, int, int> ParseDamgePlusBonus(String UnrolledDamage){
        String Amount = UnrolledDamage.Substring(0, UnrolledDamage.IndexOf("D"));
        //Debug.Log(Amount);
        String Type = UnrolledDamage.Substring(UnrolledDamage.IndexOf("D") + 1, 1);
        //Debug.Log(Type);
        String Extra = UnrolledDamage.Substring(UnrolledDamage.IndexOf("+") + 1);
        //Debug.Log(Extra);

        return Tuple.Create(Convert.ToInt32(Amount), Convert.ToInt32(Type), Convert.ToInt32(Extra));
    }

}
