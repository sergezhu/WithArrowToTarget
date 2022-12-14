namespace Game.Code.Input
{
	using System;
	using UnityEngine;

	[Serializable]
	public struct TouchZone
	{
		[Range( 0, 1 )]
		[SerializeField] private float _xMin;
		[Range( 0, 1 )]
		[SerializeField] private float _xMax;
		[Range( 0, 1 )]
		[SerializeField] private float _yMin;
		[Range( 0, 1 )]
		[SerializeField] private float _yMax;

		public float XMin => Mathf.Min( _xMax, _xMin );
		public float XMax => Mathf.Max( _xMax, _xMin );
		public float YMin => Mathf.Min( _yMax, _yMin );
		public float YMax => Mathf.Max( _yMax, _yMin );

		
		public bool InZone( Vector2 v )
		{
			return v.x >= XMin && v.x <= XMax && v.y >= YMin && v.y <= YMax;
		}
	}
}