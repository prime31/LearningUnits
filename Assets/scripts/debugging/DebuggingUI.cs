using UnityEngine;
using System.Collections;


#pragma warning disable 0414
public class GnarlyClass
{
	public class InnerClass
	{
		public struct DataHolder
		{
			int t;
			public string s;
			float f;
			
			public DataHolder( int t )
			{
				this.t = t;
				s = "doodler";
				f = 666.66f;
			}
		}
		
		public DataHolder holder = new DataHolder( 123445 );
		private string className = "im not a class, im a struct";
	}
	
	public InnerClass innerClass = new InnerClass();
	private string className = "GnarlyClass";
}


public class DebuggingUI : MonoBehaviour
{
	private string theString = "im a string";
	private bool isTrue = true;
	private int bigNumber = 23423;
	protected GnarlyClass gnarly = new GnarlyClass();
	
	
	void OnGUI()
	{
		float yPos = 5.0f;
		float xPos = 5.0f;
		float width = ( Screen.width >= 960 || Screen.height >= 960 ) ? 320 : 160;
		float height = ( Screen.width >= 960 || Screen.height >= 960 ) ? 80 : 40;
		float heightPlus = height + 10.0f;
	
	
		if( GUI.Button( new Rect( xPos, yPos, width, height ), "Log, warn and error" ) )
		{
			D.log( "this is a log with formatting: {0:0.0}", 12.123213 );
			D.warn( "warning! warning!" );
			D.error( "error time. the value of gnarly.innerClass.holder.s is: {0}", gnarly.innerClass.holder.s );
		}
	

		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Call with null string" ) )
		{
			protectMyInput( null, 140 );
		}


		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Call with low number" ) )
		{
			protectMyInput( string.Empty, 3 );
		}


		if( GUI.Button( new Rect( xPos, yPos += heightPlus, width, height ), "Call with valid input" ) )
		{
			protectMyInput( string.Empty, 300 );
		}
	}
	
	
	public void protectMyInput( string shouldNeverBeNull, int shouldBeAboveOneHundred )
	{
		D.assert( shouldNeverBeNull != null, "shouldNeverBeNull is null. that's not good" );
		D.assert( shouldBeAboveOneHundred > 100, "shouldBeAboveOneHundred is less than 100", true );
	}

}
#pragma warning restore 0414