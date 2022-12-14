using UnityEngine;

namespace Game.Code.Hero
{
	using System;
	using Game.Code.Utilities.Extensions;

	public class HeroArrow : MonoBehaviour
	{
		[SerializeField] private float _length = 1;
		[SerializeField] private float _size = 0.5f;
		[SerializeField] private Vector2 _dir;

		[Space]
		[SerializeField] private float _offsetFromHero;
		[SerializeField] private float _arrowOffset;
		[SerializeField] private Transform _bodyPart;
		[SerializeField] private Transform _arrowPart;

		public void SetLength( float length )
		{
			SetGeometry( length, _size );
		}

		public void SetSize( float size )
		{
			SetGeometry( _length, size );
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
		
		public void SetGeometry(float length, float size )
		{
			_length = length;
			_size = size;
			
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

		private void OnValidate()
		{
			#if UNITY_EDITOR
			SetGeometry( _length, _size );
			SetDirection( _dir );
			#endif
		}
	}
}
