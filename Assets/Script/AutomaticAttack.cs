using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticAttack : MonoBehaviour
{
    //public PalyerScript d;
    public GameObject obj;            //弾のオブジェクトを設置
    public float interval = 3.0f;     //弾を発射する間隔
    public float power = 1000f;       //弾を発射する力
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 0.1f, interval);　　//一定間隔でSpawnObjが発動
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    //向いている方向に弾を発射
    void SpawnObj()
    {
        GameObject bullet = Instantiate(obj, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward  * power);
    }
}
