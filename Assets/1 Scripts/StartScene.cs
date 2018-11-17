public class StartScene : UnityEngine.MonoBehaviour
{
	public enum SceneType { VR, ARVR }
	public static SceneType TypeOfScene { get; private set; }
	public void SwitchSceneVR( )
	{
		TypeOfScene = SceneType.VR;
		SwitchScene();
	}
	public
	void SwitchSceneARVR( )
	{
		TypeOfScene = SceneType.ARVR;
		SwitchScene();
	}

	private void SwitchScene( ) => Utilities.SceneManagemant.LoadLevel( Constants.GameSceneIdx );
}
