using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour{

    [SerializeField]
    public List<Enemy> CurrentEnemies = new List<Enemy>();

    public List<bool> DeadEnemies = new List<bool>();
}
