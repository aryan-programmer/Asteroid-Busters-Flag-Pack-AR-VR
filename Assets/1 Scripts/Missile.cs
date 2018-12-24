using UnityEngine;
using Utilities;
public
class Missile: MonoBehaviour
{
	#pragma warning disable 0649
	[SerializeField] float speed;
	[Header( "Renderer Effects" ), SerializeField] RendererRandomizableInformation m_rendInformation;
	#pragma warning restore 0649
	internal Transform target;
	internal Missile pairedMissile;
	void Update( )
	{

		if(target != null)
		{
			transform.LookAt( target );
			transform.position = Vector3.MoveTowards( transform.position , target.position , Time.deltaTime * 4 * speed );

		}

	}
	public
	void setRendererEffects( )
	{
		var rendInfo = new RendererInformation( m_rendInformation.meshes.GetRandomElement() , m_rendInformation.materials.GetRandomElement() );
		setRendererState( rendInfo );
		pairedMissile.setRendererState( rendInfo );

	}
	void setRendererState( RendererInformation rendInfo )
	{
		m_rendInformation.rendererObject.GetComponent<MeshFilter>().mesh = rendInfo.mesh;
		m_rendInformation.rendererObject.GetComponent<MeshCollider>().sharedMesh = rendInfo.mesh;
		m_rendInformation.rendererObject.GetComponent<MeshRenderer>().material = rendInfo.material;

	}
	public
	void OnDestroy( )
	{

		if(pairedMissile != null)
		{
			Destroy( pairedMissile.gameObject );

		}

	}
	[System.Serializable] public
	struct RendererRandomizableInformation
	{
		public GameObject rendererObject;
		public Mesh[] meshes;
		public Material[] materials;

	}
	public
	struct RendererInformation
	{
		public Mesh mesh;
		public Material material;
		public
		RendererInformation ( Mesh _mesh , Material _material )
		{
			mesh = _mesh;
			material = _material;

		}

	}

}
