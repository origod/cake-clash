using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject effectPrefab;
    //public AudioClip sound;

    // 爆風の力
    public float power = 10f;

    // 爆風が及ぶ範囲（半径）
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

        // 着弾点を爆心地にする
        Vector3 explosionPos = collision.transform.position;

        // 爆心地から『指定した半径内』にあるオブジェクトのcolliderを取得する。
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
                // 爆風の発生
                rb.AddExplosionForce(power, collision.transform.position, radius, 1.0f, ForceMode.VelocityChange);
            }
        }
    }
}
