using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ancestry : MonoBehaviour {
    public string AncestryName;
    public int Heath;
    public string Size;
    public int Speed;
    public string VisionSenses;
    public string SpecialPassive;
    public string Description;
    protected bool hasFreeAttribute;
    protected string freeAttribute;


    public Attributes AttributeBoosts;


    public Attributes getAttributes() {
        return AttributeBoosts;
    }

    public void GetFreeAttribute(string freeAttribute) {
        switch (freeAttribute) {
            case "Strength": AttributeBoosts.Strength++; break;
            case "Dexterity": AttributeBoosts.Dexterity++; break;
            case "Constitution": AttributeBoosts.Constitution++; break;
            case "Intelligence": AttributeBoosts.Intelligence++; break;
            case "Wisdom": AttributeBoosts.Wisdom++; break;
            case "Charisma": AttributeBoosts.Charisma++; break;
        }
    }

    //CustomEditor for FreeAtrributes
    [CustomEditor(typeof(Ancestry), true)]
    protected class AncestryEditor : Editor{
        public override void OnInspectorGUI(){
            var Ancestry = target as Ancestry;

            Ancestry.AncestryName = EditorGUILayout.TextField("Ancestry Name", Ancestry.AncestryName);
            Ancestry.Size = EditorGUILayout.TextField("Ancestry Size", Ancestry.Size);

            Ancestry.Heath = EditorGUILayout.IntField("Ancestry Health", Ancestry.Heath);
            Ancestry.Speed = EditorGUILayout.IntField("Ancestry Speed", Ancestry.Speed);

            Ancestry.VisionSenses = EditorGUILayout.TextField("Ancestry Vision", Ancestry.VisionSenses);
            Ancestry.SpecialPassive = EditorGUILayout.TextField("Ancestry Passive ", Ancestry.SpecialPassive);
            Ancestry.Description = EditorGUILayout.TextField("Ancestry Description", Ancestry.Description);

            Ancestry.hasFreeAttribute = EditorGUILayout.Toggle("Has a Free Attribute", Ancestry.hasFreeAttribute);
            if(Ancestry.hasFreeAttribute){
                using(new EditorGUI.DisabledScope(!Ancestry.hasFreeAttribute)){
                    Ancestry.freeAttribute = EditorGUILayout.TextField("Free Attribute", Ancestry.freeAttribute);
                    Ancestry.GetFreeAttribute(Ancestry.freeAttribute);
                }
            }


        }
    }


}
