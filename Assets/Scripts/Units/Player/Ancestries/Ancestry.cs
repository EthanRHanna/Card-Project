using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancestry : MonoBehaviour{
    public string AncestryName;
    public int Heath;
    public string Size;
    public int Speed;
    public string VisionSenses;
    public string SpecialPassive;
    public string Description;

    protected Attributes AttributeBoosts;
    
    public Attributes getAttributes(){
        return AttributeBoosts;
    }
}
