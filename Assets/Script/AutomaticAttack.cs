using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticAttack : MonoBehaviour
{
    //public PalyerScript d;
    public GameObject obj;            //�e�̃I�u�W�F�N�g��ݒu
    public float interval = 3.0f;     //�e�𔭎˂���Ԋu
    public float power = 1000f;       //�e�𔭎˂����
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 0.1f, interval);�@�@//���Ԋu��SpawnObj������
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    //�����Ă�������ɒe�𔭎�
    void SpawnObj()
    {
        GameObject bullet = Instantiate(obj, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward  * power);
    }
}
