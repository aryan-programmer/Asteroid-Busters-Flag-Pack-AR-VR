using UnityEngine;
using Utilities;

public class CountryFlag : MonoBehaviour
{
	internal static CountryFlag Instantiate( Vector3 pos ) =>
		Instantiate( Prefabs.I[ "CountryFlag" ] , pos , Quaternion.identity ).
		GetComponent<CountryFlag>();

	[System.Serializable]
	internal struct Statics
	{
		public float FlagDisplayTime;
		public Texture[] textures;
	}

	[SerializeField] Statics statics;

	// Use this for initialization
	void Start( )
	{
		transform.LookAt( transform.parent = Player.I.transform );
		var rot = transform.localEulerAngles;
		rot.z = 0;
		transform.localEulerAngles = rot;
		transform.parent = null;
		var randTex = statics.textures.GetRandomElement();
		GetComponent<MeshRenderer>().material.mainTexture = randTex;
		WindowsVoice.Speak( randTex.name );
		print( randTex.name );
		transform.localScale *= Mathf.Abs( Vector3.Distance( Player.I.transform.position , transform.position ) );
		Destroy( gameObject , statics.FlagDisplayTime );
	}
}
