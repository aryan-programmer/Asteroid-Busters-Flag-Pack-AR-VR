using UnityEngine;
using Utilities;
public
class CountryFlag: MonoBehaviour
{
	public static
	CountryFlag Instantiate( Vector3 pos )
	{
		return Instantiate( Prefabs.I[@"CountryFlag"
		] , pos , Quaternion.identity ).GetComponent<CountryFlag>();

	}
	[System.Serializable]
	struct Statics
	{
		public float FlagDisplayTime;
		public Texture[] textures;

	}
	[SerializeField] Statics statics;
	void Start( )
	{
		transform.LookAt( transform.parent = Player.I.transform );
		var rot = transform.localEulerAngles;
		rot.z = 0;
		transform.localEulerAngles = rot;
		transform.parent = null;
		var randTex = statics.textures.GetRandomElement();
		GetComponent<MeshRenderer>().material.mainTexture = randTex;
		Speaker.Speak( randTex.name );
		print( randTex.name );
		transform.localScale *= Mathf.Abs( Vector3.Distance( Player.I.transform.position , transform.position ) );
		Destroy( gameObject , statics.FlagDisplayTime );

	}

}
