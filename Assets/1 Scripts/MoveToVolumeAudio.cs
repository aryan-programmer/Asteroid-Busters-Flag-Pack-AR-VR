using UnityEngine;
public
class MoveToVolumeAudio: MonoBehaviour
{
	#pragma warning disable 0649
	[SerializeField] float ToVolume, speed = 1;
	#pragma warning restore 0649
	AudioSource __audioSource;
	public
	AudioSource SAudioSource
	{

		get
		{
			return __audioSource ?? (__audioSource = GetComponent<AudioSource>());


		}

	}
	void Update( )
	{
		SAudioSource.volume = Mathf.Lerp( SAudioSource.volume , ToVolume , Time.deltaTime * speed );

	}

}
