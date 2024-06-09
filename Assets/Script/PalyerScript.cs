using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PalyerScript : MonoBehaviour
{
    //public GameObject player;
    //private CakeClash inputActions;
    Vector2 vector1;
    Vector2 vector2;
    [SerializeField] float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //inputActions = new CakeClash();
        //inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject p = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
        transform.Translate(vector1.x * Time.deltaTime * speed, 0f, vector1.y * Time.deltaTime * speed, Space.World);  //移動
        var direction = new Vector3(vector2.x * Time.deltaTime, 0f, vector2.y * Time.deltaTime);　　　　　　　　　　　 //回転
        transform.localRotation = Quaternion.LookRotation(direction);
        //transform.Rotate(direction);
    }
    //移動
    public void OnMove(InputAction .CallbackContext context)
    {
       if(context .phase==InputActionPhase.Performed)
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
}
