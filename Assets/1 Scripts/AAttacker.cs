using UnityEngine;

public abstract class AAttacker : MonoBehaviour
{
	protected abstract float ScoreIncrease { get; }
	protected abstract float Volume { get; }
	protected abstract GameObject[ ] Particles { get; }
	protected abstract AudioClip Boom { get; }

	public virtual void OnLook( ) => Player.I.LookAtAttacker( this );

	protected virtual void OnCollisionEnter( Collision collision )
	{
		Missile missile = collision.gameObject.GetComponent<Missile>();
		if ( missile != null )
		{
			if ( missile.target = transform )
			{
				Player.I.RemoveAttacker( this );
				Destroy();
				GameManager.I.IncreaseScore( Random.Range( 1 , 3 ) );
				Destroy( collision.gameObject );
			}
		}
	}

	protected virtual void Destroy( )
	{
		foreach ( GameObject particle in Particles )
			Destroy( Instantiate( particle , transform.position , Quaternion.identity ) , 5 );
		Planet.I.SAudioSource.PlayOneShot( Boom , Volume );
		CountryFlag.Instantiate( transform.position );
		Destroy( gameObject );
	}
}
