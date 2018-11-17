using System;
using UnityEngine;
using Utilities;
using Utilities.Timers;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
#pragma warning disable 0649
	[SerializeField] private GameObject[ ] AsteroidPrefabs;
#pragma warning restore 0649

	private int score;
	private RandomizedIncreaseingTimer SpawnTimer;
	private bool isGameRunning = true;

	private void Start( ) => SpawnTimer = new RandomizedIncreaseingTimer( 1.5f , 10f , 0.5f , 0.75f , SpawnAsteroids );

	private void Update( )
	{
		if ( isGameRunning ) SpawnTimer.OnUpdate();
	}

	private void StartGame( )
	{
		Planet.I.transform.parent = null;
		FindObjectOfType<Light>().transform.parent = null;
		isGameRunning = true;
	}

	public void ResetRotation( ) => LeanTween.rotate( Camera.main.gameObject , Vector3.zero , 0.75f );

	public void Pause( ) => isGameRunning = false;

	public void Resume( ) => isGameRunning = true;

	public void ResetHighscore( ) => PlayerPrefsManager.ResetHighscore();

	private void SpawnAsteroids( )
	{
		float scale;
		Instantiate(
			Utils.GetRandomElementFromArray( AsteroidPrefabs ) ,
			Planet.I.transform.position + ( Random.onUnitSphere * 40 ) ,
			Random.rotation ).
			transform.localScale =
			new Vector3(
				scale = Random.Range( 0.25f , 0.95f ) ,
				scale ,
				scale );
	}

	internal void GUIGameOver( ) => throw new NotImplementedException();
	public void PlayAgain( ) => SceneManagemant.LoadLevel();

	public void IncreaseScore( int points ) => score += points;// ScoreText.text = $"Score:{score:D3}";

	public void Quit( ) => SceneManagemant.Quit();
}
