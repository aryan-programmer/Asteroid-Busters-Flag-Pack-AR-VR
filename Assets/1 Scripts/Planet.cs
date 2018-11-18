using System.Collections;
using UnityEngine;

public class Planet : Singleton_<Planet>
{
#pragma warning disable 0649
	[SerializeField] Vector3 axis;
	[SerializeField] float Speed;
	[SerializeField] GameObject[] particles;
	[SerializeField] AudioClip death;
	private AudioSource __audioSource;

	public AudioSource SAudioSource => 
		__audioSource ?? ( __audioSource = GetComponent<AudioSource>() );
#pragma warning restore 0649

	private void FixedUpdate( ) => 
		transform.Rotate( axis , Time.fixedDeltaTime * Speed , Space.Self );

	public void OnCollisionEnter( Collision collision )
	{
		if ( collision.gameObject.GetComponent<Asteroid>() )
		{
			StartCoroutine( GameOver( collision.transform.position ) );
			Destroy( collision.gameObject );
		}
	}

	IEnumerator GameOver( Vector3 pos )
	{
		foreach ( GameObject particle in particles )
			Instantiate( particle , pos , Quaternion.identity );
		SAudioSource.PlayOneShot( death , 5 );
		yield return new WaitForSeconds( 3f );
		GameManager.I.GUIGameOver();
	}
}
