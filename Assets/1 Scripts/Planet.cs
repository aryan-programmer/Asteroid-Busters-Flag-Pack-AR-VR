using System.Collections;
using UnityEngine;
public
class Planet: Singleton_<Planet>
{
	#pragma warning disable 0649
	[SerializeField] Vector3 axis;
	[SerializeField] float Speed;
	[SerializeField] GameObject[] particles;
	[SerializeField] AudioClip death;
	#pragma warning restore 0649
	AudioSource __audioSource;
	public
	AudioSource SAudioSource
	{

		get
		{
			return __audioSource ?? (__audioSource = GetComponent<AudioSource>());


		}

	}
	void FixedUpdate( )
	{
		transform.Rotate( axis , Time.fixedDeltaTime * Speed , Space.Self );

	}
	void OnCollisionEnter( Collision collision )
	{

		if(collision.gameObject.GetComponent<Asteroid>())
		{
			StartCoroutine( GameOver( collision.transform.position ) );
			Destroy( collision.gameObject );

		}

	}
	System.Collections.IEnumerator GameOver( Vector3 pos )
	{

		foreach(GameObject particle in particles)
		{
			Instantiate( particle , pos , Quaternion.identity );

		}
		SAudioSource.PlayOneShot( death , 5 );
		yield return new WaitForSeconds( 3f );
		GameManager.I.GUIGameOver();

	}

}
