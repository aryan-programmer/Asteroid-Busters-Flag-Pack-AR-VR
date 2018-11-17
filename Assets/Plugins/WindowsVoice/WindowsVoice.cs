﻿using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class WindowsVoice : MonoBehaviour
{
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
	[DllImport( "WindowsVoice" )]
	public static extern void initSpeech( );
	[DllImport( "WindowsVoice" )]
	public static extern void destroySpeech( );
	[DllImport( "WindowsVoice" )]
	public static extern void addToSpeechQueue( string s );
	[DllImport( "WindowsVoice" )]
	public static extern void clearSpeechQueue( );
	[DllImport( "WindowsVoice" )]
	public static extern void statusMessage( StringBuilder str , int length );
	public static WindowsVoice I = null;

	// Use this for initialization
	private void OnEnable( )
	{
		if ( I == null )
		{
			I = this;
			Debug.Log( "Initializing speech" );
			DontDestroyOnLoad( gameObject );
			initSpeech();
		}
		else Destroy( gameObject );
	}
	public static void Speak( string msg ) => addToSpeechQueue( msg );

	private void OnDestroy( )
	{
		if ( I == this )
		{
			Debug.Log( "Destroying speech" );
			destroySpeech();
			I = null;
		}
	}
	public static string GetStatusMessage( )
	{
		StringBuilder sb = new StringBuilder( 40 );
		statusMessage( sb , 40 );
		return sb.ToString();
	}
#else
	public static void Speak( string msg ){}
#endif
}