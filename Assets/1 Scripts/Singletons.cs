using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletons : Singleton_<Singletons>,
	IReadOnlyDictionary<System.Type , Behaviour>
{
	[System.Serializable]
	struct GameObjectAndID
	{
		[SerializeField] public string id;
		[SerializeField] public GameObject @object;
	}
	[SerializeField] GameObjectAndID[] singletonObjects;

	Dictionary<Type , Behaviour> singletons;

	public IEnumerable<Type> Keys => singletons.Keys;

	public IEnumerable<Behaviour> Values => singletons.Values;

	public int Count => singletons.Count;

	public Behaviour this[ Type key ] => singletons[ key ];

	public bool ContainsKey( Type key ) => singletons.ContainsKey( key );
	public bool TryGetValue( Type key , out Behaviour value ) => singletons.TryGetValue( key , out value );
	public IEnumerator<KeyValuePair<Type , Behaviour>> GetEnumerator( ) => singletons.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator( ) => singletons.GetEnumerator();

	public T Get<T>( ) where T : Behaviour => singletons[ typeof( T ) ] as T;

	private void Start( )
	{
		singletons = new Dictionary<Type , Behaviour>( singletonObjects.Length );
		foreach ( var @object in singletonObjects )
		{
			var behv = @object.@object.GetComponent( @object.id ) as Behaviour;
			if ( behv == null )
				Debug.LogError(
					$"There is no component on the object:{@object.@object.name} with the name: {@object.id}" );
			else singletons.Add( behv.GetType() , behv );
		}
	}
}
