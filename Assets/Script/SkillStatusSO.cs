using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillStatusSO : ScriptableObject 
{
    public List<SkillStatus> skillStatusList = new List<SkillStatus>();

    [System.Serializable ]
    public class SkillStatus
    {
        [SerializeField] string skillName;
        [SerializeField] int attack;
        [SerializeField] enemyType type;

        public enum enemyType
        {
            type1,
            type2
        }

        public int ATTACk { get => attack ; }


    }

   
}
