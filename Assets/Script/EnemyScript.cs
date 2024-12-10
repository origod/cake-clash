using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    //[SerializeField] Transform player;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] SkillStatusSO skillStatusSO;
    [SerializeField] int enemyNumber;
    [SerializeField] float detectDistance = 20;//探知距離
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public  float currentSpeed ;
    private float changeSpeed = 15.0f;
    private float distance;
    bool IsDetected = false;
    private int currentHP;
    //[SerializeField] Material chaseMaterial;  //巡回中
    //[SerializeField] Material patrolMaterial; //追跡中
    //[SerializeField]
    //[Tooltip("範囲A")]
    //private Transform rangeA;
    //[SerializeField]
    //[Tooltip("範囲B")]
    //private Transform rangeB;
    float secound;
    float time = 0;
    public float change = 3.0f;

    Vector3 movePosition;
    bool isChase = false;
    CreateRangeRandomPosition create;

    //private Rigidbody rigi;
    private int count;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        movePosition = transform.position;
        //rigi = GetComponent<Rigidbody>();

        //目的地に近づいても速度を落とさない
        agent.autoBraking = false;
        agent.speed = currentSpeed;
        //if (enemyNumber ==1)
        //{
        //    agent.speed = changeSpeed;
        //}
        //else
        //{
        //    agent.speed = currentSpeed;
        //}
        currentHP = enemyStatusSO.enemyStatusList[enemyNumber].HP;
        currentSpeed = enemyStatusSO.enemyStatusList[enemyNumber].SPEED;

        GotoNextPoint();
        //movePosition = moveRandomPosition();
    }

    void GotoNextPoint()
    {
        
        //地点が何もなくても設定されていないときに返す
        if (points.Length == 0) return;

        //エージェントが現在設定された目的地点に行くようにする
        agent.destination = points[destPoint].position;

        //配列内の次の位置を目的地点に設定
        //必要ならば出発地点に戻る
        destPoint = (destPoint + 1) % points.Length;
    }
    // Update is called once per frame
    void Update()
    {
        secound += Time.deltaTime;
       if(!isChase)
        {
            //int rand = 0;
            //if (secound >= change)
            //{
            //    secound = 0;
            //    rand = Random.Range(0, 360);
            //    //var direction = new Vector3(0f, Random.Range(0, 360) * Time.deltaTime, 0f);        //回転
            //    //transform.localRotation = Quaternion.LookRotation(direction);
            //    //transform.position = new Vector3(movePosition.x, Random.Range(0, 360) + movePosition.y, movePosition.z);
            //    //Quaternion.Euler(0, Random.Range(0, 360), 0);
            //}
            transform.position = new Vector3(Mathf.Sin(Time.time) * 5.0f + movePosition.x,movePosition .y, movePosition.z);
        }
       else
        {
            if (enemyNumber == 1)
            {
                agent.speed = changeSpeed;
                time = time + Time.deltaTime;
                if (time >= 1.0f)
                {

                   
                    if (time >= 3.0f)
                    {
                        agent.speed = currentSpeed;
                        time = 0;
                    }
                }
            }
        }
        //count++;
        //if (count < 1000)
        //{
        //    rigi.AddForce(transform.right * speed, ForceMode.Acceleration);
        //}
        //else if(count >1000)
        //{
        //    rigi.AddForce(transform.right * speed*-1, ForceMode.Acceleration);
        //}
        //if(count == 2000)
        //{
        //    count = 0;
        //}
        //if (movePosition == gameObject.transform.position)  //②playerオブジェクトが目的地に到達すると、
        //{
        //    movePosition = moveRandomPosition();  //②目的地を再設定
        //}
        //this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, movePosition, speed * Time.deltaTime);
        //Debug.Log(currentHP);
        //distance = Vector3.Distance(player.position, this.transform.position);
        if (distance <= detectDistance )
        {
            if(!IsDetected)
            {
                
                //GetComponent<Renderer>().material = chaseMaterial;
            }
            IsDetected = true;

            
        }
        else
        {
            if(IsDetected)
            {
                //GetComponent<Renderer>().material = patrolMaterial;
                
                GotoNextPoint();
            }
            IsDetected = false;
        }

        if(!IsDetected)
        {
            
            //エージェントが現目標地点に近づいたら
            //次の目標地点を選択
            if(!agent.pathPending &&agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
        else
        {
            
            //agent.destination = player.position;
        }

        if(currentHP <= 0)
        {
            audioManager.PlaySE(audioManager.enemyDeath);
            Destroy(gameObject);
            //create = GetComponent<CreateRangeRandomPosition>();
            //create.count--;
            //Instantiate(gameObject, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //movePosition = moveRandomPosition();
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentHP = currentHP - playerStatusSO.ATTACK;

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("weapon"))
        {
            audioManager.PlaySE(audioManager.candleHit);
            currentHP = currentHP - skillStatusSO.skillStatusList[0].ATTACk;
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            //audioManager.PlaySE(audioManager.skill2_SE);
            currentHP = currentHP - skillStatusSO.skillStatusList[1].ATTACk;
        }
    }

    public void OnDetectObject(Collider collider)
    {
        if(collider .gameObject.tag == "Player")
        {
            agent.destination = collider.gameObject.transform.position ;

            //GetComponent<Renderer>().material = chaseMaterial;

            isChase = true;
        }
    }
    public void OnLoseObject(Collider collider)
    {
        if(collider .gameObject .tag == "Player")
        {
            agent.destination = this.gameObject.transform.position * Time.deltaTime;

            //GetComponent<Renderer>().material = patrolMaterial;

            isChase = false;
        }
    }
    //private Vector3 moveRandomPosition()
    //{
    //    //Vector3 randomPosi = new Vector3(Random.Range(gameObject.transform.position.x + 10, gameObject.transform.position.x - 10),
    //    //                                              gameObject.transform.position.y,
    //    //                                 Random.Range(gameObject.transform.position.z + 10, gameObject.transform.position.z - 10));
    //    Vector3 randomPosi = new Vector3(gameObject .transform .position .x, gameObject.transform.position.y, gameObject.transform.position.z);
    //    return randomPosi;
    //}
}
