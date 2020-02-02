using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    bool scrollFlag = true;

    [SerializeField] private float speed;

    private void Start()
    {
        speed = -0.1f;
    }

    void Update()
    {
        //スクロールを止める処理
        if (scrollFlag == true)
        {
            //下スクロール
            transform.Translate(0, speed, 0);
        }

        //もしyが-13.2より下に行けば13,2に戻る
        if (transform.position.y < -12.0f)
        {
            transform.position = new Vector3(0, 13.2f, 0);
        } 
    }

    /// <summary>
    /// スクロールの開始
    /// </summary>
    public void ScrollStart()
    {
        scrollFlag = true;
    }

    /// <summary>
    /// スクロールの停止
    /// </summary>
    public void ScrollStop()
    {
        scrollFlag = false;
    }

    /// <summary>
    /// 加速
    /// </summary>
    /// <param name="upSpeed">加速度</param>
    public void SpeedUp(float upSpeed)
    {
        speed -= upSpeed;
    }

    /// <summary>
    /// 速度の取得
    /// </summary>
    /// <returns>速度</returns>
    public float GetSpeed()
    {
        return speed;
    }
}
