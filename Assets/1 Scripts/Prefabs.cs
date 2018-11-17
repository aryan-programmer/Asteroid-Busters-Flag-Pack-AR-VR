using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : Singleton<Prefabs>, 
	IReadOnlyDictionary<string, GameObject>
{
	[System.Serializable]
	struct GameObjectAndID
	{
		[SerializeField] public string id;
		[SerializeField] public GameObject prefab;
	}
	[SerializeField] GameObjectAndID[] m_prefab;

	Dictionary<string , GameObject> prefabs;

	#region IReadOnlyDictionary<string, GameObject>
	public IEnumerable<string> Keys => prefabs.Keys;

	public IEnumerable<GameObject> Values => prefabs.Values;

	public int Count => prefabs.Count;

	public GameObject this[ string key ] => prefabs[ key ];

	public bool ContainsKey( string key ) => prefabs.ContainsKey( key );
	public bool TryGetValue( string key , out GameObject value ) =>
		prefabs.TryGetValue( key , out value );
	public IEnumerator<KeyValuePair<string , GameObject>> GetEnumerator( ) =>
		prefabs.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator( ) => prefabs.GetEnumerator();
	#endregion

	private void Start( )
	{
		prefabs = new Dictionary<string , GameObject>( m_prefab.Length );
		foreach ( var prefab in m_prefab )
			prefabs.Add( prefab.id , prefab.prefab );
	}
}
