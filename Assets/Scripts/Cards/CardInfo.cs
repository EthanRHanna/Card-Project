using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardInfo : MonoBehaviour
{
    [SerializeField]
    public string CardName;

    [SerializeField]
    public string CardDamage;

    [SerializeField]
    public string CardElement;

    [SerializeField]
    public bool isSpell;

    [SerializeField]
    public int SpellTier;


    [CustomEditor(typeof(CardInfo))]
    public class CardInfoEditor : Editor{
        override public void OnInspectorGUI(){
            var CardInfo = target as CardInfo;

            CardInfo.CardName = EditorGUILayout.TextField("Name of Card", CardInfo.CardName);
            CardInfo.CardDamage = EditorGUILayout.TextField("Damage of the Card", CardInfo.CardDamage);
            CardInfo.CardElement = EditorGUILayout.TextField("Element of the Card", CardInfo.CardElement);

            CardInfo.isSpell = EditorGUILayout.Toggle("Is Spell", CardInfo.isSpell);

            if(CardInfo.isSpell){
                using(new EditorGUI.DisabledScope(!CardInfo.isSpell)){
                    CardInfo.SpellTier = EditorGUILayout.IntField("Spell Tier", CardInfo.SpellTier);
                }
            }
        }
    }
}
