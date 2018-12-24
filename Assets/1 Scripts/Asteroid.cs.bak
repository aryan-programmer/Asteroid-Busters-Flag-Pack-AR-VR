using UnityEngine;

public class Asteroid : AAttacker
{
#pragma warning disable 0649
	[SerializeField] GameObject[] particles;
	[SerializeField] AudioClip boom;
#pragma warning restore 0649

	private float rotationRate;
	private Vector3 rotationAxis;

	protected override float ScoreIncrease => Random.Range( 1 , 3 );
	protected override float Volume => 1;
	protected override GameObject[] Particles => particles;
	protected override AudioClip Boom => boom;

	// Use this for initialization
	void Start( )
	{
		Vector3 target = Planet.I.transform.position;
		GetComponent<Rigidbody>().AddForce( ( target - transform.position ).normalized * Random.Range( 150f , 250f ) );

		rotationRate = Random.Range( 30f , 100f );
		rotationAxis = Random.onUnitSphere;
	}

	private void Update( ) => 
		transform.Rotate( 
			rotationAxis , 
			Time.deltaTime * rotationRate , 
			Space.World );
}
