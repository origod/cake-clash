using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.SocialPlatforms.GameCenter;

public class FunnnelSkikll : MonoBehaviour
{
    [SerializeField] SkillGauge gauge;
    public Transform orbitCenter;
    public float orbitSpeed = 30.0f;
    public float rotationSpeed = 80.0f;
    public float skillTime;
    public bool callskill = false;
    private bool calledskill = false;

    private float time;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
        //callskill = true;
    }
    void Update()
    {
        if (callskill)
        {
            time = time + Time.deltaTime;
            gameObject.SetActive(true);
            if (time > skillTime)
            {
                time = 0f;
                calledskill = false;
                callskill = false;
                gameObject.SetActive(false);
            }
        }

        OrbitAround();
        //SelfRotate();
    }

    void OrbitAround()
    {
        transform.RotateAround(orbitCenter.position, Vector3.up, orbitSpeed * Time.deltaTime*-1);
    }

    void SelfRotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        audioManager.PlaySE(audioManager.candleHit);
    //        Destroy(collision.gameObject);
    //    }
    //}
    public void Skill_1(InputAction.CallbackContext context)
    {
        if(gauge.currentgauge >= 5)
        {
            
            if (!calledskill)
            {
                gauge.currentgauge = gauge.currentgauge - 5;
                gameObject.SetActive(true);
                calledskill = true;
                callskill = true;

            }
         
        }
        //Debug.Log(time);
        
    }
    //void CallFunnel()
    //{
    //    gameObject.SetActive(true);
    //    transform.position = new Vector3(orbitCenter.position.x, orbitCenter.position.y, orbitCenter.position.z + 8);
    //    callskill = false;
    //}
}
