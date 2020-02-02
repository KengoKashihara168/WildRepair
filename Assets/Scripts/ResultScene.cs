using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    private AudioSource sound;
    private bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
    }

    private void PlaySound()
    {
        sound.Play();
        isStart = true;
    }

    private void NextScene()
    {
        if (sound.isPlaying) return;
        if (!isStart) return;

        SceneManager.LoadScene("TitleScene");
    }

    public void OnTitleScene()
    {
        PlaySound();
    }
}
