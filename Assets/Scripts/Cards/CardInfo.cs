using System;
using System.Collections;
using System.Collections.Generic;
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
}
