using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBase : MonoBehaviour
{
    // sgt
    static public MusicBase intance;
    private void Awake()
    {
        MusicBase.intance = this;

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicBase");
        if (musicObj.Length > 1) Destroy(this.gameObject);
        else
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = SourceMusic.MusicBase;
            audioSource.Play();
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
    [SerializeField] SourceMusicBase sourceMusic;

    public SourceMusicBase SourceMusic { get => sourceMusic; set => sourceMusic = value; }
}
