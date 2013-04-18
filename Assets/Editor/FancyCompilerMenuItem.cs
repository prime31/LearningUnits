using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;



public class TouchKitMenuItem : Editor
{
	[MenuItem( "prime[31]/Create DLL from selected files...", true )]
	static bool validate()
	{
		foreach( var obj in Selection.objects )
		{
			if( obj.GetType() == typeof( MonoScript ) )
				return true;
		}
		return false;
	}

	
	[MenuItem( "prime[31]/Create DLL from selected files..." )]
	static void createDLL()
	{
		var compileParams = new CompilerParameters();
		
		var buildTargetFilename = "SomeFancyDLL.dll";
		
		compileParams.OutputAssembly = Path.Combine( System.Environment.GetFolderPath( System.Environment.SpecialFolder.Desktop ), buildTargetFilename );
		// for all available compiler options: http://msdn.microsoft.com/en-us/library/6ds95cz0(v=vs.80).aspx
		compileParams.CompilerOptions = "/optimize";
		compileParams.ReferencedAssemblies.Add( Path.Combine( EditorApplication.applicationContentsPath, "Frameworks/Managed/UnityEngine.dll" ) );
		
		var source = getSourceForSelectedScripts();

		var codeProvider = new CSharpCodeProvider( new Dictionary<string, string> { { "CompilerVersion", "v3.0" } } );
    	var compilerResults = codeProvider.CompileAssemblyFromSource( compileParams, source );
		
    	if( compilerResults.Errors.Count > 0 )
    	{
    		foreach( var error in compilerResults.Errors )
    			Debug.LogError( error.ToString() );
		}
		else
		{
			// the dll exists
			EditorUtility.DisplayDialog( "Fancy Script Compiler", buildTargetFilename + " should now be on your desktop.", "OK" );
		}
	}
	
	
	static string[] getSourceForSelectedScripts()
	{
		var source = new List<string>();
		
		foreach( var obj in Selection.objects )
		{
			if( obj.GetType() == typeof( MonoScript ) )
				source.Add( obj.ToString() );
		}
		
		return source.ToArray();
	}

}
