using System;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public delegate void GetOperation(Sound s);

    public Sound[] sounds;
    public Sound[] songs;

    private Sound[] allSounds;
    private int randomSong;
    public bool isSongNeeded = true;

    [HideInInspector]
    public string currentSongName;

    private void Update()
    {
        if (!songs[randomSong].source.isPlaying && isSongNeeded && !PauseMenu.isPaused)
        {
            if (songs[randomSong].name == currentSongName)
                randomSong = UnityEngine.Random.Range(0, songs.Length);
            PlayRandomSong();
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        allSounds = sounds.Concat(songs).ToArray();

        foreach (Sound sound in allSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void DoOperation(GetOperation op, string name)
    {
        Sound s = Array.Find(allSounds, sound => sound.name == name);

        if (s != null)
            op?.Invoke(s);
        else
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
    }

    public void Play(Sound s)
    {
        if (s.source.isPlaying && s.source.loop)
            return;
        else
            s.source.Play();
    }

    public void Stop(Sound s)
    {
        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sound s in allSounds)
            DoOperation(Stop, s.name);
    }

    public void Pause(Sound s)
    {
        s.source.Pause();
    }

    public void PauseAll()
    {
        foreach (Sound s in allSounds)
            DoOperation(Pause, s.name);
    }

    public void UnPause(Sound s)
    {
        s.source.UnPause();
    }

    public void UnPauseAll()
    {
        foreach (Sound s in allSounds)
            DoOperation(UnPause, s.name);
    }

    public void PlayRandomSong()
    {
        randomSong = UnityEngine.Random.Range(0, songs.Length);

        while (songs[randomSong].name == "Theme")
            randomSong = UnityEngine.Random.Range(0, songs.Length);

        DoOperation(Play, songs[randomSong].name);
        currentSongName = songs[randomSong].name;
    }
}
