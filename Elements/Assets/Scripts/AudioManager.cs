using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource music;

    public static AudioSource win;
    public static AudioSource death;

    public static AudioSource upgrade;

    public static AudioSource menu;



    // Start is called before the first frame update
    void Start()
    {
        AudioSource []sounds = GetComponents<AudioSource>();
        music = sounds[0];
        win = sounds[1];
        death = sounds[2];
        upgrade = sounds[3];
    }

}
