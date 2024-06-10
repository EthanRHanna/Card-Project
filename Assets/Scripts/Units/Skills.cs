using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public string Acrobatics;
    public string Arcana;
    public string Athletics;
    public string Crafting;
    public string Deception;
    public string Diplomacy;
    public string Intimdation;
    public string Lore;
    public string Medicaine;
    public string Nature;
    public string Occultism;
    public string Perception;
    public string Preformance;
    public string Religion;
    public string Society;
    public string Stealth;
    public string Survival;
    public string Thievery;


    public int proficencytoInt(string Proficency){
        switch(Proficency.ToLower()){
            case "trained":
                return 2;
            case "expert":
                return 4;
            case "master":
                return 6;
            case "legendary":
                return 8;
            default:
                return 0;
        }
    }

    
}
