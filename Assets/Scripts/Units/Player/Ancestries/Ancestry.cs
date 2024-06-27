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

    public Attributes AttributeBoosts;
    public string currentFreeAtribute = "";

    public string GetFreeAttribute(string freeAttribute) {
            switch (freeAttribute){
                case "Strength": AttributeBoosts.Strength++; return "Strength";
                case "Dexterity": AttributeBoosts.Dexterity++; return "Dexterity";
                case "Constitution": AttributeBoosts.Constitution++; return "Constitution";
                case "Intelligence": AttributeBoosts.Intelligence++; return "Intelligence";
                case "Wisdom": AttributeBoosts.Wisdom++; return "Wisdom";
                case "Charisma": AttributeBoosts.Charisma++; return "Charisma";
                
            }
        return null;
    }

    public string RemoveFreeAttribute(string freeAttribute) {
            switch (freeAttribute){
                case "Strength": AttributeBoosts.Strength--; return "";
                case "Dexterity": AttributeBoosts.Dexterity--; return "";
                case "Constitution": AttributeBoosts.Constitution--; return "";
                case "Intelligence": AttributeBoosts.Intelligence--; return "";
                case "Wisdom": AttributeBoosts.Wisdom--; return "";
                case "Charisma": AttributeBoosts.Charisma--; return "";
                
            }
        return null;
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

            Ancestry.AttributeBoosts = (Attributes)EditorGUILayout.ObjectField(Ancestry.AttributeBoosts, typeof(Attributes), true);

            Ancestry.hasFreeAttribute = EditorGUILayout.Toggle("Has a Free Attribute", Ancestry.hasFreeAttribute);
            if (Ancestry.hasFreeAttribute){
                var freeAttribute = "";
                using (new EditorGUI.DisabledScope(!Ancestry.hasFreeAttribute && Ancestry.currentFreeAtribute == "")){
                    freeAttribute = EditorGUILayout.TextField("Free Attribute", freeAttribute);
                    Ancestry.currentFreeAtribute = Ancestry.GetFreeAttribute(freeAttribute);
                    
                }
            }
        }
    }


}
