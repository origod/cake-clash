using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusSO : ScriptableObject 
{
    [SerializeField] int hp;
    [SerializeField] int attack;
    [SerializeField] float speed;

    public int HP { get => hp;}
    public int ATTACK { get => attack ; }
    public float SPEED { get => speed; }
}
