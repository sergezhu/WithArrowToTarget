using UnityEngine;

namespace Game.Code.Utilities
{
	public class AutoDestroy : MonoBehaviour
	{
		private void Awake()
		{
			Destroy( gameObject );
		}
	}
}
