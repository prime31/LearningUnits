using UnityEngine;
using System.Collections;


public class LINQPlayerManager : MonoBehaviour
{
	public GUIText headUpText;
	public GameObject bulletPrefab;
	
	private ObjectRecycler recycler;
	
	
	void Start()
	{
		// create an object recycler to manage our bullets
		recycler = new ObjectRecycler( bulletPrefab, 3 );
		
		recycler.onObjectRecylerChanged += delegate( int available, int total )
		{
			headUpText.text = string.Format( "Available bullets: {0}\r\nTotal bullets: {1}", available, total );
		};
	}
	
	
	void OnGUI()
	{
		if( GUI.Button( new Rect( Screen.width - 150, 0, 150, 50 ), "Fire" ) )
		{
			var go = recycler.nextFree;
			
			// shoot the bullet
			StartCoroutine( shootBullet( go ) );
		}
	}
	
	
	private IEnumerator shootBullet( GameObject bullet )
	{
		// Set bullet transform and prepare to apply forces
		bullet.transform.position = transform.position;
		
		Vector3 force = transform.position + new Vector3( 0, 0.05f, 1 ) * 2000.0f;
		bullet.rigidbody.AddForce( force );
		
		// Wait for 3 seconds
		yield return new WaitForSeconds( 3.0f );
		
		// Recycle the bullet
		recycler.freeObject( bullet );
	}
	
}
