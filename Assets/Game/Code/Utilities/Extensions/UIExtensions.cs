namespace Game.Code.Utilities.Extensions
{
	using System;
	using UniRx;
	using UnityEngine;
	using UnityEngine.UI;

	public static class UIExtensions
	{
		public static void Bind( this Button b, Action action, CompositeDisposable disposable )
		{
			b.onClick.AsObservable()
				.Subscribe( _ => action?.Invoke() )
				.AddTo( disposable );
		}

		public static void Bind( this Button b, Action action, Component component )
		{
			b.onClick.AsObservable()
				.Subscribe( _ => action?.Invoke() )
				.AddTo( component );
		}
	}
}