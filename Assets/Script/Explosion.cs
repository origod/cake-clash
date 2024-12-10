using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject effectPrefab;
    //public AudioClip sound;

    // �����̗�
    public float power = 10f;

    // �������y�Ԕ͈́i���a�j
    public float radius = 100f;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        //AudioSource.PlayClipAtPoint(sound, transform.position);
        audioManager.PlaySE(audioManager.skill2_SE);

        // ���e�_�𔚐S�n�ɂ���
        Vector3 explosionPos = collision.transform.position;

        // ���S�n����w�w�肵�����a���x�ɂ���I�u�W�F�N�g��collider���擾����B
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if(hit.gameObject .tag!="Player"&& hit.gameObject.tag !="Untagged"&& hit.gameObject.tag !="weapon")
            {
                Destroy(hit.gameObject);
            }
            if (rb)
            {
                // �����̔���
                rb.AddExplosionForce(power, collision.transform.position, radius, 1.0f, ForceMode.VelocityChange);
            }
        }
    }
}
