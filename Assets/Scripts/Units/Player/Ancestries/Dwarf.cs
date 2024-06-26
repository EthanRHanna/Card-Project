using System;
using System.Collections;
using UnityEngine;

public class Dwarf : Ancestry{
    public Dwarf(){
        AncestryName = "Dwarf";
        Heath = 10;
        Size = "Medium";
        Speed = 20;
        VisionSenses = "DarkVision";
        SpecialPassive = "Clan Dagger";

        AttributeBoosts = new Attributes(){
            Strength = 0,
            Dexterity = 0,
            Constitution = 1,
            Intelligence = 0,
            Wisdom = 1,
            Charisma = -1,
        };


    }


}
