using UnityEngine;
using Utilities.Extensions;

public class Missile : MonoBehaviour
{
#pragma warning disable 0649
	[SerializeField] float speed;
	[Header( "Renderer Effects" ), SerializeField]
	private RendererRandomizableInformation m_rendInformation;
#pragma warning restore 0649

	internal Transform target;
	internal Missile pairedMissile;

	// Update is called once per frame
	void Update( )
	{
		if ( target != null )
		{
			transform.LookAt( target );
			transform.position = Vector3.MoveTowards( transform.position , target.position , Time.deltaTime * 4 * speed );
		}
	}

	public void setRendererEffects( )
	{
		RendererInformation rendInfo = new RendererInformation( m_rendInformation.meshes.GetRandomElement() , m_rendInformation.materials.GetRandomElement() );
		setRendererState( rendInfo );
		pairedMissile.setRendererState( rendInfo );
	}

	void setRendererState( RendererInformation rendInfo )
	{
		m_rendInformation.rendererObject.GetComponent<MeshFilter>().mesh = rendInfo.mesh;
		m_rendInformation.rendererObject.GetComponent<MeshCollider>().sharedMesh = rendInfo.mesh;
		m_rendInformation.rendererObject.GetComponent<MeshRenderer>().material = rendInfo.material;
	}

	// This function is called when the MonoBehaviour will be destroyed
	public void OnDestroy( )
	{
		if ( pairedMissile != null ) Destroy( pairedMissile.gameObject );
	}

	[System.Serializable]
	public struct RendererRandomizableInformation
	{
		public GameObject rendererObject;
		public Mesh[] meshes;
		public Material[] materials;
	}

	public struct RendererInformation
	{
		public Mesh mesh;
		public Material material;
		public RendererInformation( Mesh _mesh , Material _material )
		{
			mesh = _mesh;
			material = _material;
		}
	}
}