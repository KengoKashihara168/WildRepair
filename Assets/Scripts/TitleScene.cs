using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
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

        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                SceneManager.LoadScene("CatGame");
                break;
            case 1:
                SceneManager.LoadScene("MouseGame");
                break;
        }
    }

    public void OnGameScene()
    {
        PlaySound();
    }
}
