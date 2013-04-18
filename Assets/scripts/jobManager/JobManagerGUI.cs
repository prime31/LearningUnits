using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System.Threading;



public class JobManagerGUI : MonoBehaviour 
{
	private Job _job;
	private BackgroundWorker _worker;
	private Thread _workerThread;

	
	void OnGUI()
	{
		var buttonHeight = 60;
		if( GUI.Button( new Rect( 5, 5, 200, buttonHeight ), "Make and Start 5 iteration job" ) )
		{
			var j = Job.make( writeLog( 5 ) );
			j.jobComplete += ( wasKilled ) => { Debug.Log( "job done. was it killed? " + wasKilled ); };
		}
		
		
		if( GUI.Button( new Rect( 5, 100, 200, buttonHeight ), "Make Job Paused" ) )
		{
			_job = Job.make( endlessLog(), false );
			_job.jobComplete += ( wasKilled ) => { Debug.Log( "endless job done. was it killed? " + wasKilled ); };
		}
		
		
		if( GUI.Button( new Rect( 5, 100 + buttonHeight, 200, buttonHeight ), "Start Made Job" ) )
		{
			_job.start();
		}
		
		
		if( GUI.Button( new Rect( 5, 100 + buttonHeight * 2, 200, buttonHeight ), "Pause" ) )
		{
			_job.pause();
		}
		
		
		if( GUI.Button( new Rect( 5, 100 + buttonHeight * 3, 200, buttonHeight ), "Unpause" ) )
		{
			_job.unpause();
		}
		
		
		if( GUI.Button( new Rect( 5, 100 + buttonHeight * 4, 200, buttonHeight ), "Kill Immediately" ) )
		{
			_job.kill();
		}
		

		if( GUI.Button( new Rect( 5, 100 + buttonHeight * 5, 200, buttonHeight ), "Kill After 3s Delay" ) )
		{
			_job.kill( 3 );
		}
		
		
		
		
		if( GUI.Button( new Rect( 5, 100 + buttonHeight * 8, 200, buttonHeight ), "TESTER" ) )
		{
			_worker = new BackgroundWorker();
			_worker.WorkerSupportsCancellation = true;
			_worker.DoWork += ( sender, e ) => 
			{
				Debug.Log( "started with argument: " + e.Argument );
			    var worker = sender as BackgroundWorker;
			
			    for( int i = 1; ( i <= 10 ); i++ )
			    {
			        if( worker.CancellationPending )
			        {
			            e.Cancel = true;
			            break;
			        }
			        else
			        {
			            // Perform a time consuming operation and report progress.
			            System.Threading.Thread.Sleep( 200 );
			            Debug.Log( "tick: " + i );
			        }
			    }
				
				e.Result = "done with you man";
			};
			_worker.RunWorkerCompleted += ( sender, e ) =>
			{
				Debug.Log( "DONE. thread is background: " + System.Threading.Thread.CurrentThread.IsBackground );
				Debug.Log( "finsihed. did cancel: " + e.Cancelled );
				Debug.Log( "all done: " + e.Result );
			};
			
			_worker.RunWorkerAsync( "argument here" );
		}
		
		if( GUI.Button( new Rect( 225, 100 + buttonHeight * 8, 200, buttonHeight ), "Cancel" ) )
		{
			_worker.CancelAsync();
		}
		
		
		
		var xPos = Screen.width - 205;
		if( GUI.Button( new Rect( xPos, 5, 200, buttonHeight ), "Run job with 5 children" ) )
		{
			var j = Job.make( printAfterDelay( "im the parent job", 1 ), false );
			j.jobComplete += ( wasKilled ) => { Debug.Log( "Parent job done" ); };
		
			for( var i = 1; i <= 5; i++ )
			{
				var text = "Job Number " + i;
				j.createAndAddChildJob( printAfterDelay( text, 1 ) );
			}
			j.start();
		}
	}


	
	
	// some sample methods ready to be called in a coroutine
	IEnumerator writeLog( int totalTimes )
	{
		var i = 0;
		var wfs = new WaitForSeconds( 1 );
		
		while( i <= totalTimes )
		{
			Debug.Log( string.Format( "writing log {0} of {1}", i, totalTimes ) );
			i++;
			yield return wfs;
		}
	}
	
	
	IEnumerator endlessLog()
	{
		var i = 0;
		var wfs = new WaitForSeconds( 1 );
		
		while( true )
		{
			Debug.Log( "writing endless log: " + i );
			i++;
			yield return wfs;
		}
	}
	
	
	IEnumerator printAfterDelay( string text, float delay )
	{
		yield return new WaitForSeconds( delay );
		Debug.Log( "printAfterDelay: " + text );
	}

}
