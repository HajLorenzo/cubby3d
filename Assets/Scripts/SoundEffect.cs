using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "SoundEffect")]
public class SoundEffect : ScriptableObject
{
    public AudioClip[] audios;
}
