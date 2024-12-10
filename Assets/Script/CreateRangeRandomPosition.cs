using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CreateRangeRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������GameObject")]
    private GameObject[] createPrefab;
    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    private float time;
    private int number;
    public int createEnemy;
    public int count = 0;
    [SerializeField] int createMAX;

    public bool createEnemyFlag = false;
    // Start is called before the first frame update
    void Start()
    {
       
        //CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        //// �O�t���[������̎��Ԃ����Z���Ă���
        //time = time + Time.deltaTime;

        //if(count<createMAX )
        //{

        //    // ��1�b�u���Ƀ����_���ɐ��������悤�ɂ���B
        //    if (time > 1.0f)
        //    {
        //        count++;
        //        // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
        //        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        //        // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
        //        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        //        // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
        //        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        //        // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
        //        Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

        //        // �o�ߎ��ԃ��Z�b�g
        //        time = 0f;
        //    }
        //}
        if (createEnemyFlag)
        {
           
            CreateEnemy();
            //createEnemyFlag = false;
        }
        
    }
    public void CreateEnemy()
    {
        if(count<createEnemy)
        {
            for (count =0; count < createEnemy; count++)
            {
                number = Random.Range(0, createPrefab.Length);
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeA��rangeB��z���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(createPrefab[number], new Vector3(x, y, z), createPrefab[number].transform.rotation);


            }
        }
       
    }
}
