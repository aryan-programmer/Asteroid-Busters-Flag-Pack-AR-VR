using UnityEngine;

public class MouseLook : MonoBehaviour
{
#pragma warning disable 0649
	[SerializeField] float XSensitivity = 2f;
	[SerializeField] float YSensitivity = 2f;
	[SerializeField] bool smooth;
	[SerializeField] float smoothTime = 5f;
#pragma warning restore 0649

	private Quaternion m_TargetRot;

	internal void SetZeroTarget( ) => m_TargetRot = Quaternion.identity;

	public void Start( )
	{
		Input.gyro.enabled = true;
		m_TargetRot = transform.localRotation;
	}


	public void Update( )
	{
		if ( !Application.isMobilePlatform )
		{
			if ( !Cursor.visible )
				m_TargetRot *= Quaternion.Euler( 
					-Input.GetAxis( "Mouse Y" ) * YSensitivity , 
					Input.GetAxis( "Mouse X" ) * XSensitivity , 
					0f );
		}
		else m_TargetRot = Input.gyro.attitude;

		if ( smooth )
			transform.localRotation = 
				Quaternion.Slerp( 
					transform.localRotation , 
					m_TargetRot , 
					smoothTime * Time.deltaTime );
		else transform.localRotation = m_TargetRot;

		InternalLockUpdate();
	}

	private void InternalLockUpdate( )
	{
		if ( !Input.GetKey( KeyCode.LeftAlt ) )
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}
