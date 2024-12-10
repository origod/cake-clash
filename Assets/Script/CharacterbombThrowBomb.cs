using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterThrowBomb : MonoBehaviour
{
    [SerializeField] SkillGauge gauge;
    public GameObject bombPrefab;
    public Transform launchPoint;
    private bool isThrowing = true;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isThrowing)
        {
            //LaunchBomb();
        }
    }

    public void LaunchBomb(InputAction.CallbackContext context)
    {
        if (gauge.currentgauge >= 10)
        {
            if (!context.started)
            {
                return;
            }

            if (bombPrefab != null)
            {
                gauge.currentgauge = gauge.currentgauge - 10;
                GameObject bomb = Instantiate(bombPrefab, launchPoint.position, launchPoint.rotation);
                Rigidbody rd = bomb.GetComponent<Rigidbody>();

                if (rd != null)
                {
                    Vector3 launchDirection = (launchPoint.forward + Vector3.up).normalized;
                    rd.AddForce(launchDirection * 10f, ForceMode.VelocityChange);
                }

                isThrowing = false;

                StartCoroutine(ResetThrowFlag());
                Destroy(bomb, 2f);
            }
        }
       
    }

    private IEnumerator ResetThrowFlag()
    {
        yield return new WaitForSeconds(1f);
        isThrowing = true;
    }
}