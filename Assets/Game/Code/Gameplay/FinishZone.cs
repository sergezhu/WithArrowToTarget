namespace Game.Code.Gameplay
{
	using System;
	using UnityEngine;

	public class FinishZone : MonoBehaviour
	{
		[SerializeField] private float _radius;

		public float Radius => _radius;

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere( transform.position, _radius );
		}
	}
}