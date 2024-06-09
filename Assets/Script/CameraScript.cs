using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;      //プレイヤー情報格納用
    private Vector3 offset;　　　　 //相対距離取得用
    // Start is called before the first frame update
    void Start()
    {
        //this.player = GameObject.Find("Player");

        //MainCameraとplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;
    }
}
