using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly float moveRange = 2.8f;
    private Rigidbody2D rigid;
    private Vector3 mousePos;
    private int timer;
    private bool countFrag;
    private AudioSource audio;
    private Transform obstaclePosition;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        timer = 0;
        countFrag = false;

        audio = GetComponent<AudioSource>();

        obstaclePosition = null;
    }

    // Update is called once per frame
    void Update()
    {
        // マウスの座標を取得
        mousePos = GetMousePos();

        // マウスが画面の範囲外だったら移動しない
        if(Mathf.Abs(mousePos.x) >= moveRange)
        {
            mousePos.x = transform.position.x;
        }

        // 移動
        rigid.MovePosition(mousePos);

        if (countFrag == true)
        {
            //カウント
            timer++;
        }

        if (timer >= 10)
        {
            // 通過
            Through();
            ResetThrough();
        } 
    }

    /// <summary>
    /// マウスのＸ座標を取得
    /// </summary>
    /// <returns></returns>
    private Vector3 GetMousePos()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = transform.position.y;

        return pos;
    }

    /// <summary>
    /// 通過
    /// </summary>
    private void Through()
    {
        if (rigid.bodyType == RigidbodyType2D.Kinematic) return;
        rigid.bodyType = RigidbodyType2D.Kinematic;
    }

    /// <summary>
    /// 透過の初期化
    /// </summary>
    private void ResetThrough()
    {
        if (rigid.bodyType != RigidbodyType2D.Kinematic) return;
        if (obstaclePosition == null) return;

        // 衝突したオブジェクトとの距離を計算
        float distance = obstaclePosition.position.y - transform.position.y;
        if (distance <= -1.5f)
        {
            // 透過をリセット
            countFrag = false;
            rigid.bodyType = RigidbodyType2D.Dynamic;
            timer = 0;
            obstaclePosition = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        obstaclePosition = collision.transform;
        countFrag = true;
        audio.Play();
    }
}
