namespace Game.Code.Hero
{
	using UnityEngine;

	public interface IHeroView
	{
		void SetPosition( Vector3 position );
		void SetArrowDir( Vector3 dir );
		void ShowArrow();
		void HideArrow();
		void SetArrowMaxSize(float size);
	}

	public class HeroView : MonoBehaviour, IHeroView
	{
		[SerializeField] private HeroArrow _heroArrow;
		
		private Transform _transform;

		public Transform Transform => _transform ??= transform;
		
		public void SetPosition( Vector3 position )
		{
			Transform.position = position;
		}

		public void SetArrowMaxSize(float size)
		{
			_heroArrow.SetMaxSize( size );
		}

		public void SetArrowDir( Vector3 dir )
		{
			var length = dir.magnitude;
			
			_heroArrow.SetLength( length );
			_heroArrow.SetDirection( dir );
		}

		public void ShowArrow() => _heroArrow.Show();
		public void HideArrow() => _heroArrow.Hide();
	}
}