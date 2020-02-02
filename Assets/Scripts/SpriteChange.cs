using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        int spriteNum = Random.Range(0, sprites.Length);
        renderer.sprite = sprites[spriteNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
