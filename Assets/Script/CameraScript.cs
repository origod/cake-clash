using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;      //�v���C���[���i�[�p
    private Vector3 offset;�@�@�@�@ //���΋����擾�p
    // Start is called before the first frame update
    void Start()
    {
        //this.player = GameObject.Find("Player");

        //MainCamera��player�Ƃ̑��΋��������߂�
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�V�����g�����X�t�H�[���̒l��������
        transform.position = player.transform.position + offset;
    }
}
