using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataStorage : MonoBehaviour {

    public static bool SoundPlaying, MusicPlaying, InitiallyChangedSettings;
    public bool SoundPlayingGetSet, MusicPlayingGetSet, InitiallyChangedSettingsGetSet;
    public int RoundsPlayed;
    public static SceneDataStorage i;

    public GameObject MusicPlayer;

    //public static bool SoundPlayingCheck, MusicPlayingCheck;


    void Awake()
    {
        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        SoundPlayingGetSet = SoundPlaying;
        MusicPlayingGetSet = MusicPlaying;
        InitiallyChangedSettingsGetSet = InitiallyChangedSettings;

        if (InitiallyChangedSettings == true)
        {
            if (MusicPlaying == true)
            {
                Debug.Log("Music is supposed to be playing...");
                //MusicPlayer.GetComponent<AudioSource>().Play();
            }
            else if (MusicPlaying == false)
            {
                Debug.Log("Music isn't supposed to be playing...");
            }
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        SoundPlayingGetSet = SoundPlaying;
        MusicPlayingGetSet = MusicPlaying;
        InitiallyChangedSettingsGetSet = InitiallyChangedSettings;
    }
    public void SoundPlayingSet (bool ChangedSoundPlaying)
    {
        SoundPlaying = ChangedSoundPlaying;
    }

    public void MusicPlayingSet(bool ChangedMusicPlaying)
    {
        Debug.Log("Changed music...");
        MusicPlaying = ChangedMusicPlaying;
    }

    public void InitiallyChangedSettingsSet(bool ChangedInitialSettings)
    {
        InitiallyChangedSettings = ChangedInitialSettings;
    }

}
