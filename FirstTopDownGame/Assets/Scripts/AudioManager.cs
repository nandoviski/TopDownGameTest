using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
	public static AudioManager Instance;

	void Awake()
	{
		// Make the audio manager persist between scenes
		DontDestroyOnLoad(gameObject);
		// and prevent us to add more than one AudioManager
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		foreach (var item in Sounds)
		{
			item.Source = gameObject.AddComponent<AudioSource>();
			item.Source.clip = item.Clip;
			item.Source.volume = item.Volume;
			item.Source.pitch = item.Pitch;
			item.Source.loop = item.Loop;
		}
	}

	void Start()
	{
		Play("Theme"); // Always play the theme audio of the game, even when changing Scenes
	}

	public void Play(string name)
	{
		var sound = Array.Find(Sounds, s => s.Name == name);
		if (sound != null)
		{
			sound.Source.Play();
		}
		else
		{
			//Debug.LogWarning($"Sound {name} not found");
		}
	}
}
