using UnityEngine;
using System.Collections;


public class EventManager1 : MonoBehaviour
{
	public delegate void PowerUpHandler( bool isPoweredUp );
	public static event PowerUpHandler onPoweredUp;
	
	
	void OnGUI()
	{
		if( GUI.Button( new Rect( 5, 5, 150, 40 ), "Power Up" ) )
		{
			if( onPoweredUp != null )
				onPoweredUp( true );
		}
		
		
		if( GUI.Button( new Rect( 5, 50, 150, 40 ), "Power Up Over" ) )
		{
			if( onPoweredUp != null )
				onPoweredUp( false );
		}
	}

}
