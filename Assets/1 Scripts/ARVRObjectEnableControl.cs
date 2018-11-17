public class ARVRObjectEnableControl : UnityEngine.MonoBehaviour
{
	[UnityEngine.SerializeField] private bool enableWhenARVR;

	private void Start( ) => gameObject.SetActive( !( ( StartScene.TypeOfScene == StartScene.SceneType.ARVR ) ^ enableWhenARVR ) );

}
