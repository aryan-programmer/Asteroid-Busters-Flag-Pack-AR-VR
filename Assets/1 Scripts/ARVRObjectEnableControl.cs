public
class ARVRObjectEnableControl : UnityEngine.MonoBehaviour
{
	[UnityEngine.SerializeField] bool enableWhenARVR;
	void Start( )
	{
		gameObject.SetActive( !( ( StartScene.TypeOfScene == StartScene.SceneType.ARVR ) ^ enableWhenARVR ) );

	}

}
