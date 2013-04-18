using UnityEngine;
using System.Collections;


public class ExtensionsGUI : MonoBehaviour
{
	public AudioClip explosion;
	public AudioClip wind;
	public AudioClip[] clips;
	
	private AudioSource _audioSource;
	
	
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}
	

	void OnGUI()
	{
		if( GUI.Button( new Rect( 5, 5, 200, 40 ), "String Append" ) )
		{
			var theString = "Hi.  Im a string.";
			theString.printWithLotsOfLettersAppended();
		}
		
		
		float x = Screen.width - 210;
		
		if( GUI.Button( new Rect( x, 5, 200, 40 ), "Play Explosion" ) )
		{
			_audioSource.playClip( explosion );
		}
		
		
		if( GUI.Button( new Rect( x, 55, 200, 40 ), "Play Explosion with Completion" ) )
		{
			StartCoroutine
			(
				_audioSource.playClip( explosion, () =>
				{
					Debug.Log( "audio clip finished" );
				})
			);
		}
		
		
		if( GUI.Button( new Rect( x, 105, 200, 40 ), "Play Random Clip" ) )
		{
			_audioSource.playRandomClip( clips );
		}
		
		
		if( GUI.Button( new Rect( x, 155, 200, 40 ), "Fade Audio Clip" ) )
		{
			StartCoroutine
			(
				_audioSource.fadeOut( wind, 3.0f, () =>
				{
					Debug.Log( "all done fading" );
				})
			);
		}
	}
}
