using UnityEngine;
using Utilities;
using Utilities.Timers;

public class GameManager : Singleton_<GameManager>
{
#pragma warning disable 0649
	[SerializeField] private GameObject[ ] AsteroidPrefabs;
#pragma warning restore 0649

	private RandomizedIncreaseingTimer SpawnTimer;

	private void Start( ) => SpawnTimer = new RandomizedIncreaseingTimer( _secondsBetweenTicksMin: 1.5f , _secondsBetweenTicksMax: 10f , _decreaseInSecondsBetweenTicksMaxMin: 0.5f , _decreaseInSecondsBetweenTicksMaxMax: 0.75f , _functionToCallEachTick: SpawnAsteroids );

	private void Update( ) => SpawnTimer.OnUpdate();

	public void ResetRotation( ) => LeanTween.rotate( Camera.main.gameObject , Vector3.zero , 0.75f );

	private void SpawnAsteroids( ) => 
		Instantiate(
			AsteroidPrefabs.GetRandomElement() ,
			Planet.I.transform.position + ( Random.onUnitSphere * 40 ) ,
			Random.rotation ).
			transform.localScale =
			Vector3.one * Random.Range( 0.25f , 0.95f );

	internal void GUIGameOver( ) => SceneManagemant.LoadLevel( Constants.DeathSceneIdx );
}
