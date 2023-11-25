using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SourceMusicBase : ScriptableObject
{
    [SerializeField] private AudioClip musicBase;

    public AudioClip MusicBase { get => musicBase; set => musicBase = value; }
}
