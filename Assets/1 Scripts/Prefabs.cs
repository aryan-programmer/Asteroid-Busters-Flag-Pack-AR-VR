using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public
class Prefabs: Singleton_<Prefabs> ,  IReadOnlyDictionary<string, GameObject>
{
	[System.Serializable]
	struct GameObjectAndID
	{
		[SerializeField] public string id;
		[SerializeField] public GameObject prefab;

	}
	[SerializeField] GameObjectAndID[] m_prefab;
	Dictionary<string, GameObject> prefabs;
	// Region IReadOnlyDictionary<string, GameObject>;
	public
	System.Collections.Generic.IEnumerable<string> Keys
	{

		get
		{
			return prefabs.Keys;


		}

	}
	public
	System.Collections.Generic.IEnumerable<GameObject> Values
	{

		get
		{
			return prefabs.Values;


		}

	}
	public
	int Count
	{

		get
		{
			return prefabs.Count;


		}

	}
	public
	GameObject this[ string key ]
	{

		get
		{
			return prefabs[ key ];


		}

	}
	public
	bool ContainsKey( string key )
	{
		return prefabs.ContainsKey( key );

	}
	public
	bool TryGetValue( string key , out GameObject value )
	{
		return prefabs.TryGetValue( key , out value );

	}
	public
	System.Collections.Generic.IEnumerator<KeyValuePair<string , GameObject>> GetEnumerator( )
	{
		return prefabs.GetEnumerator();

	}
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
	{
		return prefabs.GetEnumerator();

	}
	// EndRegion;
	void Start( )
	{
		prefabs = m_prefab.ToDictionary( delegate( GameObjectAndID prefab ) {
		return prefab.id;
		}, delegate( GameObjectAndID prefab ) {
		return prefab.prefab;
		} );

	}

}
