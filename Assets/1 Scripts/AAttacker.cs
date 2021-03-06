using UnityEngine;
public abstract
class AAttacker: MonoBehaviour
{

		protected abstract float Volume();
	protected abstract GameObject[ ] Particles();
	protected abstract AudioClip Boom();
	public virtual
	void OnLook( )
	{
		Player.I.LookAtAttacker( this );

	}
	protected virtual
	void OnCollisionEnter( Collision collision )
	{

		if(collision.gameObject.GetComponent<Missile>()?.target == transform)
		{
			Player.I.RemoveAttacker( this );
			Destroy();
			Destroy( collision.gameObject );

		}

	}
	protected virtual
	void Destroy( )
	{

		foreach(GameObject particle in Particles())
		{
			Destroy( Instantiate( particle , transform.position , Quaternion.identity ) , 5 );

		}
		Planet.I.SAudioSource.PlayOneShot( Boom() , Volume() );
		CountryFlag.Instantiate( transform.position );
		Destroy( gameObject );

	}

}
