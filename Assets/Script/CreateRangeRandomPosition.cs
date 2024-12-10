using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CreateRangeRandomPosition : MonoBehaviour
{
    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject[] createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
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
        //// 前フレームからの時間を加算していく
        //time = time + Time.deltaTime;

        //if(count<createMAX )
        //{

        //    // 約1秒置きにランダムに生成されるようにする。
        //    if (time > 1.0f)
        //    {
        //        count++;
        //        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        //        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        //        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        //        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        //        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        //        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        //        // GameObjectを上記で決まったランダムな場所に生成
        //        Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);

        //        // 経過時間リセット
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
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(rangeA.position.y, rangeB.position.y);
                // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
                float z = Random.Range(rangeA.position.z, rangeB.position.z);

                // GameObjectを上記で決まったランダムな場所に生成
                Instantiate(createPrefab[number], new Vector3(x, y, z), createPrefab[number].transform.rotation);


            }
        }
       
    }
}
