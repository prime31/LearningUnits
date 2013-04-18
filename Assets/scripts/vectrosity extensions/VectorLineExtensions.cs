using UnityEngine;
using System.Collections;
using System.Linq;


public static class VectorLineExtensions
{
	/*
	public static IEnumerator animateTo( this VectorLine vectorLine, Vector2[] endLinePoints, float duration )
	{
		return animateTo( vectorLine, endLinePoints, duration, Easing.Linear.easeIn );
	}
	
	
	public static IEnumerator animateTo( this VectorLine vectorLine, Vector2[] endLinePoints, float duration, System.Func<float, float> ease )
	{
		var totalLength = vectorLine.points2.Length;
		
		// sanity check
		if( totalLength != endLinePoints.Length )
			Debug.LogError( "vectorLine does not have the same amount of points as endLinePoints" );
		
		// copy our original array for reference when animating
		var startLinePoints = new Vector2[totalLength];
		System.Array.Copy( vectorLine.points2, startLinePoints, totalLength );
		
		// setup vars needed for the animation
		var startTime = Time.time;
		var endTime = startTime + duration;
		float easePosition;
		
		// loop until we reach endTime
		while( startTime <= endTime )
		{
			// calculate our easePosition which will always be between 0 and 1
			easePosition = Mathf.Clamp01( ( Time.time - startTime ) / duration );
			
			// loop through all the points animating vectorLine.points2[i] towards endLinePoints[i]
			for( var i = 0; i < totalLength; i++ )
			{
				vectorLine.points2[i] = Vector2.Lerp( startLinePoints[i], endLinePoints[i], ease( easePosition ) );
			}
			
			// update the line
			Vector.DrawLine( vectorLine );
			
			yield return null;
		}
	}
	
	
	public static IEnumerator animateColorTo( this VectorLine vectorLine, Color[] colorPoints, float duration )
	{
		return animateColorTo( vectorLine, colorPoints, duration, Easing.Linear.easeIn );
	}
	
	
	public static IEnumerator animateColorTo( this VectorLine vectorLine, Color[] colorPoints, float duration, System.Func<float, float> ease )
	{
		// this is actually 4 times greater than colorPoints
		var totalLength = vectorLine.lineColors.Length / 4;
		
		// sanity check.  continuous requires length - 1 colorPoints and discrete requires length / 2 colorPoints
		if( totalLength != colorPoints.Length )
			Debug.LogError( "invalid colorPoints length: continuous lines require length - 1 colors and discrete require length / 2!" );
		
		// this will hold our newly calculated colors and get updated each iteration of the animation loop
		var newColorPoints = new Color[colorPoints.Length];
		
		// copy our original array of colors for reference when animating but we only want every 4th element
		var startColorPoints = vectorLine.lineColors.Where( ( x, i ) => i % 4 == 0 ).ToArray();
		
		// setup vars needed for the animation
		var startTime = Time.time;
		var endTime = startTime + duration;
		float easePosition;
		
		// loop until we reach endTime
		while( startTime <= endTime )
		{
			// calculate our easePosition which will always be between 0 and 1
			easePosition = Mathf.Clamp01( ( Time.time - startTime ) / duration );
			
			// loop through all the points animating vectorLine.points2[i] towards endLinePoints[i]
			for( var i = 0; i < totalLength; i++ )
			{
				newColorPoints[i] = Color.Lerp( startColorPoints[i], colorPoints[i], ease( easePosition ) );
			}
			
			Vector.SetColors( vectorLine, newColorPoints );
			
			yield return null;
		}
	}
	*/
}
