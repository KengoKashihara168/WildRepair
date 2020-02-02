using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] private GameObject    obstacle = null;
    [SerializeField] private ScrollManager bg1      = null;
    [SerializeField] private ScrollManager bg2      = null;
    [SerializeField] private SpeedUp speedUp = null;

    private readonly float CreateRange  = 2.5f; // 生成される範囲
    private readonly float CreateHeight = 7.5f; // 生成される高さ
    private readonly int   ExpediteTime = 300;
    private readonly int   AccelTime    = 1200;
    private readonly float ScrollAccel  = 0.05f;

    private float createInterval; // 生成される間隔
    private List<Scroll> obstacles;
    private int timeCount;      // 経過時間のカウント

    // Start is called before the first frame update
    void Start()
    {
        createInterval = 3.0f;
        obstacles = new List<Scroll>();
        StartCoroutine("Create"); // 生成の開始
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount++;
        Expedite();
        AccelScroll();
    }

    /// <summary>
    /// 生成頻度の加速
    /// </summary>
    private void Expedite()
    {
        if (timeCount % ExpediteTime != 0) return;
        if (createInterval <= 0.5f) return;
        createInterval -= 0.5f;
    }

    private void AccelScroll()
    {
        if (timeCount % AccelTime != 0) return;
        if (bg1.GetSpeed() >= 2.0f) return;
        bg1.SpeedUp(ScrollAccel);
        bg2.SpeedUp(ScrollAccel);
        float scrollSpeed = bg1.GetSpeed();
        foreach(var obst in obstacles)
        {
            obst.SetSpeed(scrollSpeed);
        }
        speedUp.PlayEffect();
    }

    /// <summary>
    /// 生成コルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator Create()
    {
        while (true)
        {
            yield return new WaitForSeconds(createInterval);
            // 座標を設定
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(-CreateRange, CreateRange);
            pos.y = CreateHeight;
            // 生成
            GameObject obj = Instantiate(obstacle, pos, Quaternion.identity);
            float scrollSpeed = bg1.GetSpeed();
            Scroll scroll = obj.GetComponent<Scroll>();
            scroll.SetSpeed(scrollSpeed);
            obstacles.Add(scroll);
        }
    }
}
