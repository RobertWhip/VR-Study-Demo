using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioElement {
		public AudioClip audio;
		public float timing;
	}

[RequireComponent(typeof(AudioSource))]
public class AudioTiming : MonoBehaviour {
	public AudioElement[] audioElems;
	private AudioSource audioSource;

    void Start()
    {
		audioSource = GetComponent<AudioSource>();
		StartCoroutine("PlayAudios");
	}
	
	IEnumerator PlayAudios() {
		yield return null;

		for (int i = 0; i < audioElems.Length; i++) {
			audioSource.clip = audioElems[i].audio;
			audioSource.Play();
			while (audioSource.isPlaying) {
				yield return null;
			}
			yield return new WaitForSeconds(audioElems[i].timing);
		}
	}
}
