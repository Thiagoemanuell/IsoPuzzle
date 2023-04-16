using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MusicManager : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip[] MinhasMusicas;
    public int count = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioS = GetComponent<AudioSource>(); //pega o component AudioSource

        audioS.clip = MinhasMusicas[0]; //o primeiro audio a tocar da lista
        audioS.Play(); //play
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 0.1f && !audioS.isPlaying)
        {
            PlayNextMusic(); //metdodo chamado para tocar aleatoriamente
        }
    }

    void PlayNextMusic()
    {
        if (count < MinhasMusicas.Length)
        {
            count++;            
        }
        else
        {
            count = 0;
        }

        audioS.clip = MinhasMusicas[count]; //ramdom entre a primeira e a ultima mus da lista
        audioS.Play();
    }
}
