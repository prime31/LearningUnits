using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ObjectRecycler
{
	public delegate void ObjectRecylerChangedEventHandler( int available, int total );
	public event ObjectRecylerChangedEventHandler onObjectRecylerChanged;

	private List<GameObject> objectList;
	private GameObject objectToRecycle;
	

    public ObjectRecycler( GameObject go, int totalObjectsAtStart )
    {
		objectList = new List<GameObject>( totalObjectsAtStart );
		objectToRecycle = go;
		
		for( int i = 0; i < totalObjectsAtStart; i++ )
		{
			// Create a new instance and set ourself as the recycleBin
			GameObject newObject = Object.Instantiate( go ) as GameObject;
			newObject.gameObject.active = false;
			
			// add it to object store for later use
			objectList.Add( newObject );
		}
		
    }
    
    
    private void fireRecyledEvent()
    {
		if( onObjectRecylerChanged != null )
		{
			var allFree = from item in objectList
						  where item.active == false
						  select item;
			
			onObjectRecylerChanged( allFree.Count(), objectList.Count );
		}
    }


    // Gets the next available free object or null
    public GameObject nextFree
    {
		get
		{
			var freeObject = (from item in objectList
							  where item.active == false
							  select item).FirstOrDefault();
			
			if( freeObject == null )
			{
				freeObject = Object.Instantiate( objectToRecycle ) as GameObject;
				objectList.Add( freeObject );
			}
			
			freeObject.active = true;
			
			fireRecyledEvent();
			
			return freeObject;
		}
    }


    // MUST be called by any object that wants to be reused
    public void freeObject( GameObject objectToFree )
    {
 		objectToFree.gameObject.active = false;
 		
 		fireRecyledEvent();
    }


}
