using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private Animator anime;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayEffect()
    {
        anime.SetTrigger("Start");
        sound.Play();
    }
}
