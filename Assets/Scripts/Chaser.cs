using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float from = transform.position.x;
        float to = target.position.x;
        pos.x = Mathf.Lerp(from, to, chaseTime * Time.deltaTime);
        transform.position = pos;
    }
}
