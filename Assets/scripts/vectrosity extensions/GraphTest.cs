using UnityEngine;
using System.Collections;
using System.Linq;


public class GraphTest : MonoBehaviour
{
	public int totalPoints = 10;

	/* requires Vectrocity
	private VectorLine graphLine;
	private const int xOffset = 30;
	private const int yOffset = 40;
	private int xAxisSpacing;
	private int yAxisSpacing;
	

	void Start()
	{
		// figure out our x-axis spacing to evenly space out our points
		var availableWidth = Screen.width - xOffset;
		xAxisSpacing = availableWidth / totalPoints;
		
		// generate some data for the graph and create our VectorLine
		var graphData = generateGraphData( totalPoints );
		graphLine = new VectorLine( "graphData", graphData, Color.green, null, 4.0f, 0.0f, 0, LineType.Continuous, Joins.Open );
		Vector.DrawLine( graphLine );
		
		// draw axis lines
		var linePoints = new Vector2[] { new Vector2( xOffset, 50 ), new Vector2( xOffset, Screen.height - 40 ), new Vector2( xOffset, 50 ), new Vector2( 500, 50 ) };
		var axisLine = new VectorLine( "axes", linePoints, null, 3.0f, 1.5f, 1, LineType.Discrete, Joins.Open );
		Vector.DrawLine( axisLine );
		
		// figure out our y-axis spacing
		var availableHeight = Screen.height - yOffset;
		yAxisSpacing = availableHeight / 5;
	}
	
	
	void OnGUI()
	{
		if( GUI.Button( new Rect( 5, 5, 150, 40 ), "Animate Points" ) )
		{
			StopAllCoroutines();
			
			// create a random assortment of data points then animate to them
			var newGraphData = generateGraphData( totalPoints );
			StartCoroutine( graphLine.animateTo( newGraphData, 1.0f, Easing.Sinusoidal.easeIn ) );
		}
		
		
		if( GUI.Button( new Rect( ( Screen.width - 150 ) / 2, 5, 150, 40 ), "Animate Both" ) )
		{
			StopAllCoroutines();
			
			// create a random assortment of data and color points then animate to them
			var newGraphData = generateGraphData( totalPoints );
			var newColors = generateRandomColors( totalPoints - 1 );
			
			StartCoroutine( graphLine.animateTo( newGraphData, 0.5f ) );
			StartCoroutine( graphLine.animateColorTo( newColors, 0.5f ) );
		}
		
		
		if( GUI.Button( new Rect( Screen.width - 155, 5, 150, 40 ), "Animate Colors" ) )
		{
			StopAllCoroutines();
			
			var newColors = generateRandomColors( totalPoints - 1 );
			StartCoroutine( graphLine.animateColorTo( newColors, 2.0f ) );
		}
		
		
		// draw our axis labels
		for( var i = 0; i < totalPoints; i++ )
			GUI.Label( new Rect( ( i * xAxisSpacing ) + xOffset, Screen.height - yOffset, 25, 25 ), i.ToString() );
	
		// figure out our max y.  We know min is 0
		var maxY = graphLine.points2.Max( vec => vec.y );
		var step = (int)( maxY / 5 );
		
		for( var i = 0; i < 5; i++ )
			GUI.Label( new Rect( xOffset - 27, Screen.height - yOffset - 20 - ( i * yAxisSpacing ), 25, 25 ), ( i * step ).ToString( "000" ) );
	}
	
	
	private Vector2[] generateGraphData( int length )
	{
		// fill in the vectors
		var graphData = new Vector2[length];
		
		// create a random assortment of data points
		for( int i = 0; i < length; i++ )
			graphData[i] = new Vector2( ( i * xAxisSpacing ) + xOffset, Random.Range( yOffset + 10, Screen.height - yOffset ) );

		return graphData;
	}
	
	
	private Color[] generateRandomColors( int length )
	{
		var colors = new Color[length];
		
		// create random colors of joy
		for( var i = 0; i < length; i++ )
			colors[i] = new Color( Random.Range( 0.0f, 1.0f ), Random.Range( 0.0f, 1.0f ), Random.Range( 0.0f, 1.0f ) );
		
		return colors;
	}
	*/
}
