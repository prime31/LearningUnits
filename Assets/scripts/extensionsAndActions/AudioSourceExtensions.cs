using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public static class AudioSourceExtensions
{

	public static void playClip( this AudioSource audioSource, AudioClip audioClip )
	{
		audioSource.clip = audioClip;
		audioSource.Play();
	}
	
	
	public static IEnumerator playClip( this AudioSource audioSource, AudioClip audioClip, Action onComplete )
	{
		audioSource.playClip( audioClip );
		
		while( audioSource.isPlaying )
			yield return null;
		
		onComplete();
	}
	
	
	public static void playRandomClip( this AudioSource audioSource, AudioClip[] clips )
	{
		int clipIndex = UnityEngine.Random.Range( 0, clips.Length );
		audioSource.playClip( clips[clipIndex] );
	}
	
	
	public static IEnumerator fadeOut( this AudioSource audioSource, AudioClip audioClip, float duration, Action onComplete )
	{
		audioSource.playClip( audioClip );
		
		var startingVolume = audioSource.volume;
		
		// fade out the volume
		while( audioSource.volume > 0.0f )
		{
			audioSource.volume -= Time.deltaTime * startingVolume / duration;
			yield return null;
		}
		
		// done fading out
		if( onComplete != null )
			onComplete();
	}

}
