using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringClip : SerializableDictionary<string, AudioClip> { };
public class Sound
{
    public string name; //사운드 아름
    public AudioClip Clip; // 곡
}

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("SoundManager");
                    instance = instanceContainer.AddComponent<SoundManager>();
                }
            }

            return instance;
        }

    }
    public AudioSource audioSourcBgm;
    public AudioSource[] audioSourceEffect;
    public AudioClip[] BGMClips;
    public AudioClip[] EffectClips;

    public StringClip sounds;

    void LoadSounddata()
    {
        foreach(AudioClip sound in BGMClips)
        {
            sounds.Add(sound.name, sound);
        }

        foreach (AudioClip sound in EffectClips)
        {
            sounds.Add(sound.name, sound);
        }
    }


    private void Awake()
    {
        audioSourcBgm = GetComponent<AudioSource>();
        LoadSounddata();
    }

    public void PlayBGM(string name)
    {
        for(int i = 0; i< BGMClips.Length;i++)
        {
            if (name == BGMClips[i].name)
            {
                audioSourcBgm.clip = BGMClips[i];
                audioSourcBgm.Play();
                return;
            }
        }

       Debug.Log("sound" + name + "이 없습니다.");
    }

    public void PlaySoundEffect(string name)
    {
    }

}
