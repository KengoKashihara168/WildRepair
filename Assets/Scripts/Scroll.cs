using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private readonly float ScreenEnd = -6.0f;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0.0f, speed, 0.0f);
        transform.Translate(move);

        if(transform.position.y <= ScreenEnd)
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float accel)
    {
        speed = accel;
    }
}
