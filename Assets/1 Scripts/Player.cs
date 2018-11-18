using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Player : Singleton_<Player>
{
#pragma warning disable 0649
	[SerializeField] GameObject[] missiles;
	[SerializeField] Transform spawnPoint1, spawnPoint2;
#pragma warning restore 0649

	List<GameObject> prevHitTargets = new List<GameObject>();

	internal void RemoveAttacker( AAttacker attacker ) => 
		prevHitTargets.Remove( attacker.gameObject );

	internal void LookAtAttacker( AAttacker attacker )
	{
		if ( ( !prevHitTargets.Contains( attacker.gameObject ) ) )
		{
			GameObject missile = missiles.GetRandomElement();
			Missile missile1 =
				Instantiate(
					missile ,
					spawnPoint1.position ,
					transform.rotation ,
					null ).
					GetComponent<Missile>();
			Missile missile2 =
				Instantiate(
					missile ,
					spawnPoint2.position ,
					transform.rotation ,
					null ).
					GetComponent<Missile>();
			missile1.target = missile2.target = attacker.transform;
			missile1.pairedMissile = missile2;
			missile2.pairedMissile = missile1;
			missile1.setRendererEffects();
			prevHitTargets.Add( attacker.gameObject );
		}
	}
}
