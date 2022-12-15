namespace Game.Code.Hero
{
	using System;
	using UnityEngine;

	public interface IHeroView
	{
		Vector3 Position { get; set; }
		void SetArrowDir( Vector3 dir );
		void ShowArrow();
		void HideArrow();
		void SetArrowMaxSize(float size);
		float GetRadius();
		void SetArrowOverlapState( bool arrowEndOverlap );
		HeroArrow Arrow { get; }
		float Size { get; }
		void SetCrashedState();
		void SetFinishedState();
	}

	public class HeroView : MonoBehaviour, IHeroView
	{
		[SerializeField] private HeroArrow _heroArrow;
		[SerializeField] private MeshRenderer _heroRenderer;
		
		private Transform _transform;

		public Transform Transform => _transform ??= transform;
		public HeroArrow Arrow => _heroArrow;
		public float Size => Mathf.Max( Transform.localScale.x, Transform.lossyScale.y );
		
		public void SetCrashedState()
		{
			Debug.Log( $"<color=red>CRASHED</color>" );
			_heroRenderer.sharedMaterial.color = Color.red;
		}

		public void SetFinishedState()
		{
			Debug.Log( $"<color=green>FINISHED</color>" );
			_heroRenderer.sharedMaterial.color = Color.green;
		}

		public Vector3 Position
		{
			get => Transform.position; 
			set => Transform.position = value; 
		}

		public float GetRadius()
		{
			var scale = Transform.lossyScale;
			var radius = 0.5f * Mathf.Max( scale.x, scale.y );

			return radius;
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

		public void SetArrowOverlapState( bool arrowEndOverlap )
		{
			_heroArrow.SetOverlapState( arrowEndOverlap );
		}


		public void ShowArrow() => _heroArrow.Show();

		public void HideArrow() => _heroArrow.Hide();

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere( Arrow.BodyCenter, .5f );
			
			var m = Gizmos.matrix;
			Gizmos.matrix = Arrow.Transform.localToWorldMatrix;
			Gizmos.DrawWireCube( Arrow.BodyLocalCenter, Arrow.BodySize );
			Gizmos.matrix = m;
		}
	}
}