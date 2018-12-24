using UnityEngine;
public
class Asteroid: AAttacker
{
	#pragma warning disable 0649
	[SerializeField] GameObject[] particles;
	[SerializeField] AudioClip boom;
	#pragma warning restore 0649
	private float rotationRate;
	private Vector3 rotationAxis;
	protected override
	float Volume()
	{
		return 1;

	}
	protected override
	GameObject[] Particles()
	{
		return particles;

	}
	protected override
	AudioClip Boom()
	{
		return boom;

	}
	void Start( )
	{
		Vector3 target = Planet.I.transform.position;
		GetComponent<Rigidbody>().AddForce( ( target - transform.position ).normalized * Random.Range( 150f , 250f ) );
		rotationRate = Random.Range( 30f , 100f );
		rotationAxis = Random.onUnitSphere;

	}
	void Update( )
	{
		transform.Rotate( rotationAxis , Time.deltaTime * rotationRate , Space.World );;

	}

}
