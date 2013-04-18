using UnityEngine;
using System.Collections;


public class EventListener1 : MonoBehaviour
{
	void OnEnable()
	{
		EventManager1.onPoweredUp += onPoweredUp;
	}
	
	
	void OnDisable()
	{
		EventManager1.onPoweredUp -= onPoweredUp;
	}
	
	
	void onPoweredUp( bool isPoweredUp )
	{
		if( isPoweredUp )
		{
			renderer.material.color = Color.red;
			StartCoroutine( bounce() );
		}
		else
		{
			renderer.material.color = new Color( 1.0f, 1.0f, 1.0f, 1.0f );
			StopAllCoroutines();
		}
	}
	
	
	public IEnumerator bounce()
	{
		while( true )
		{
			Vector3 pos = transform.position;
			pos.y = Mathf.PingPong( Time.time * 10.0f, 2.0f );
			transform.position = pos;
			
			Debug.Log( pos.y );
			
			yield return null;
		}
	}

}
