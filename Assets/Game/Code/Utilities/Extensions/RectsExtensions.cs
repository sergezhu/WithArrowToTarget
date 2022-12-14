﻿namespace Game.Code.Utilities.Extensions
{
	using UnityEngine;

	public static class RectsExtensions
	{
		public static Vector2 RandomPoint( this Rect rect )
		{
			float x = Random.Range( rect.min.x, rect.max.x );
			float y = Random.Range( rect.min.y, rect.max.y );

			return new Vector2( x, y );
		}

		public static RectInt Intersection( this RectInt rect, RectInt other )
		{
			Vector2Int min = Vector2Int.Max( rect.min, other.min );
			Vector2Int max = Vector2Int.Min( rect.max, other.max );

			return new RectInt( min, max - min );
		}

		public static RectInt Shrink( this RectInt r, int shrink = 1 )				=> r.Grow( shrink * (-1) );
		public static RectInt Grow( this RectInt r, int extent = 1 )				=> r.Grow( Vector2Int.one * extent );
		public static RectInt Grow( this RectInt r, int extentX, int extentY )		=> r.Grow( new Vector2Int( extentX, extentY ) );
		public static RectInt Grow( this RectInt r, Vector2Int extent )				=> r.Grow( extent, extent );

		public static RectInt Grow( this RectInt r, Vector2Int extentMin, Vector2Int extentMax )
		{
			return new RectInt( r.min - extentMin, r.size + extentMin + extentMax );
		}

		public static Rect ToScreenSpace( this RectTransform transform )
		{
			Vector2 size = Vector2.Scale( transform.rect.size, transform.lossyScale );
			return new Rect( (Vector2) transform.position - (size * 0.5f), size );
		}
	}
}