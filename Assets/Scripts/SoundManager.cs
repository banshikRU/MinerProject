using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System.Collections.Generic;
public class SoundManager : MonoBehaviour 
	{
		public AudioSource efxSource;					
		public AudioSource musicSource;
		public AudioSource reserveEfxSourcee;
		public static SoundManager instance = null;		
		public float lowPitchRange = .95f;				
		public float highPitchRange = 1.05f;
	void Awake()
	{
		instance = this;
	}
    private void Update()
    {
        if (efxSource.isPlaying || reserveEfxSourcee.isPlaying)
		{ 
			musicSource.volume = 0.3f;
		}
		else
		{
            musicSource.volume = 1f;
        }
    }
    public void PlaySingle(AudioClip clip)
		{
			float randomPitch = Random.Range(lowPitchRange, highPitchRange);
			efxSource.pitch = randomPitch;
			efxSource.clip = clip;
			efxSource.Play();
		}
		public void RandomizeSfx(List<AudioClip> clips)
		{
			int randomIndex = Random.Range(0, clips.Count);
			float randomPitch = Random.Range(lowPitchRange, highPitchRange);
			efxSource.pitch = randomPitch;
			efxSource.clip = clips[randomIndex];
			efxSource.Play();
		}
	}

