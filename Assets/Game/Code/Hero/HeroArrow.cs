using UnityEngine;

namespace Game.Code.Hero
{
	using Game.Code.Utilities.Extensions;

	public class HeroArrow : MonoBehaviour
	{
		[SerializeField] private float _offsetFromHero;
		[SerializeField] private float _arrowOffset;
		[SerializeField] private Transform _bodyPart;
		[SerializeField] private Transform _arrowPart;
		[SerializeField] private MeshRenderer[] _renderers;

		[SerializeField] private Material _defaultMaterial;
		[SerializeField] private Material _overlapMaterial;

		private float _length = 1;
		private Vector2 _dir;
		private float _maxSize;

		public Vector3 EndPosition => _arrowPart.position;
		public Vector3 BodyPosition => _bodyPart.position;
		public Vector3 BodySize => _bodyPart.localScale;
		public Quaternion BodyRotation => _bodyPart.rotation;

		public void SetLength( float length )
		{
			SetGeometry( length );
		}

		public void SetMaxSize( float size )
		{
			_maxSize = size;
		}

		public void SetDirection( Vector2 dir )
		{
			if(Mathf.Approximately( dir.x, 0 ) && Mathf.Approximately( dir.y, 0 ) )
				return;
			
			_dir = dir;
			var normDir = dir.normalized;
			var angle = Mathf.Atan2( normDir.y, normDir.x ) * 180f / Mathf.PI; 
			
			transform.localRotation = Quaternion.Euler( 0, 0, angle );
		}
		
		private void SetGeometry(float length )
		{
			_length = length;
			var size = _maxSize * Mathf.Clamp( length / 1f, 0, 1f );
			
			var newBodyPartSize = _bodyPart.localScale.WithX( length ).WithY( size );
			_bodyPart.localScale = newBodyPartSize;

			_bodyPart.localPosition = (_offsetFromHero) * Vector3.right;

			var newArrowPartSize = (size * Vector3.one).WithZ( _arrowPart.localScale.z );
			_arrowPart.localScale = newArrowPartSize;

			_arrowPart.localPosition = (_offsetFromHero + _arrowOffset * size + length) * Vector3.right;
		}

		public void Show()
		{
			gameObject.SetActive( true );
		}

		public void Hide()
		{
			gameObject.SetActive( false );
		}

		public void SetOverlapState( bool arrowEndOverlap )
		{
			var mat = arrowEndOverlap ? _overlapMaterial : _defaultMaterial;
			_renderers.ForEach( r=> r.sharedMaterial = mat );
		}
	}
}
