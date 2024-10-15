using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusSO : ScriptableObject 
{
    public List<EnemyStatus> enemyStatusList = new List<EnemyStatus>();

    [System.Serializable ]
    public class EnemyStatus
    {
        [SerializeField] string enemyName;
        [SerializeField] int hp;
        [SerializeField] int attack;
        [SerializeField] float speed;
        [SerializeField] enemyType type;

        public enum enemyType
        {
            type1,
            type2
        }

        public int HP { get => hp;  }
        public int ATTACk { get => attack ; }
        public float SPEED { get => speed; }

    }

   
}
