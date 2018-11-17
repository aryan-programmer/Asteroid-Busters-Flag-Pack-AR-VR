using UnityEngine;
using Utilities;
using Utilities.Timers;

public class GameManager : Singleton<GameManager>
{
#pragma warning disable 0649
	[SerializeField] private GameObject[ ] AsteroidPrefabs;
#pragma warning restore 0649

	private RandomizedIncreaseingTimer SpawnTimer;

	private void Start( ) => SpawnTimer = new RandomizedIncreaseingTimer( 1.5f , 10f , 0.5f , 0.75f , SpawnAsteroids );

	private void Update( ) => SpawnTimer.OnUpdate();

	public void ResetRotation( ) => LeanTween.rotate( Camera.main.gameObject , Vector3.zero , 0.75f );

	private void SpawnAsteroids( )
	{
		float scale;
		Instantiate(
			AsteroidPrefabs.GetRandomElement() ,
			Planet.I.transform.position + ( Random.onUnitSphere * 40 ) ,
			Random.rotation ).
			transform.localScale =
			new Vector3(
				scale = Random.Range( 0.25f , 0.95f ) ,
				scale ,
				scale );
	}

	internal void GUIGameOver( ) => SceneManagemant.LoadLevel( Constants.DeathSceneIdx );
}
