namespace Game.Code.Configs
{
	using Game.Code.Enums;
	using UnityEngine;

	[CreateAssetMenu( fileName = "Hero", menuName = "Configs/Hero", order = (int)EConfig.Hero )]
	public class HeroConfig : ScriptableObject
	{
		public float ArrowLengthMultiplier = 1f;
		public float ArrowMaxSize = 1f;
		public float MoveDuration = 2f;
	}
}

