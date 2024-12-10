using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PalyerScript : MonoBehaviour
{
    //public GameObject player;
    //private CakeClash inputActions;
    Vector2 vector1;
    Vector2 vector2;
    Animator animator;
    [SerializeField] int enemyNumber;
    public int currentHP;
    public float currentSpeed;
    public bool endFlag;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    //[SerializeField] TMP_Text hpText;
    [SerializeField] FunnnelSkikll skill_1;
    [SerializeField]AutomaticAttack bulletTime;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //inputActions = new CakeClash();
        //inputActions.Enable();
        //hpText.GetComponent<TMP_Text>().text = "HP:" + currentHP;
        currentHP = playerStatusSO.HP;
        currentSpeed = playerStatusSO.SPEED;
        endFlag = false;
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("BulletSpeed", bulletTime.interval*10.0f);
        //hpText.GetComponent<TMP_Text>().text = "HP:" + currentHP ;
        //GameObject p = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
        if(currentHP >0)
        {
            transform.Translate(vector1.x * Time.deltaTime * currentSpeed, 0f, vector1.y * Time.deltaTime * currentSpeed, Space.World);  //移動
            var direction = new Vector3(vector2.x * Time.deltaTime, 0f, vector2.y * Time.deltaTime);            //回転
            transform.localRotation = Quaternion.LookRotation(direction);
        }
        //transform.Rotate(direction);
        if(skill_1 .callskill )
        {
            animator.SetTrigger("toSkill_1");
        }
    }
    //移動
    public void OnMove(InputAction .CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            var v = context.ReadValue<Vector2>();
            vector1 = v;
            //Debug.Log(v);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            var v = context.ReadValue<Vector2>();
            vector1 = v;
            //Debug.Log("Canceled" + v);
        }
        //else if(context .phase==InputActionPhase.Started)
        // {
        //     Debug.Log("Started");
        // }
    }
    //回転
    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            var v = context.ReadValue<Vector2>();
            vector2 = v;
            //Debug.Log(v);
        }
        //else if (context.phase == InputActionPhase.Canceled)
        //{
        //    var v = context.ReadValue<Vector2>();
        //    vector2 = v;
        //    //Debug.Log("Canceled" + v);
        //}
    }
    public void OnDeath()
    {
        endFlag = true;
        audioManager.StopBGM();
        //Debug.Log("アニメーション終了");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!collision .gameObject .CompareTag ("weapon"))
            {
                if(currentHP >1)
                {
                    animator.SetTrigger("toHit");
                    currentHP = currentHP - enemyStatusSO.enemyStatusList[enemyNumber].ATTACk;
                    Destroy(collision.gameObject);
                }
               else
                {
                    animator.SetTrigger("ToDeath");
                    currentHP = currentHP - enemyStatusSO.enemyStatusList[enemyNumber].ATTACk;

                }
               
            }
          
        }
       
    }
}
