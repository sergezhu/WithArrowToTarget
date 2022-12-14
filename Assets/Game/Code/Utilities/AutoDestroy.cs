using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	private void Awake()
	{
		Destroy( gameObject );
	}
}
