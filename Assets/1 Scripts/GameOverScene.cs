using UnityEngine;
public
class GameOverScene : MonoBehaviour
{
	public
	void Quit( )
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif

	}
	public
	void Replay( )
	{
		Utilities.SceneManagemant.LoadLevel( Constants.GameSceneIdx );

	}

}
