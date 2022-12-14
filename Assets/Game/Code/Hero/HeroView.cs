namespace Game.Code.Hero
{
	using UnityEngine;

	public interface IHeroView
	{
		void SetPosition( Vector3 position );
	}

	public class HeroView : MonoBehaviour, IHeroView
	{
		private Transform _transform;

		public Transform Transform => _transform ??= transform;
		
		public void SetPosition( Vector3 position )
		{
			Transform.position = position;
		}
	}
}