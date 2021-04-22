using UnityEngine;

[System.Serializable] // I'm using this class in a public variable on AudioManager, without this tag, it doesn't show in Unity
public class Sound
{
	public string Name;
	public AudioClip Clip;

	[Range(0f, 1f)] // Add a slider when setting it in Unity
	public float Volume;

	[Range(.1f, 3f)]
	public float Pitch;

	public bool Loop;

	[HideInInspector] // even tho this var is public, it won't show in Unity
	public AudioSource Source;
}
