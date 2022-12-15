namespace Game.Code.Configs
{
	using Game.Code.Enums;
	using Game.Code.Input;
	using UnityEngine;

	[CreateAssetMenu( fileName = "Gameplay", menuName = "Configs/Gameplay", order = (int)EConfig.Gameplay )]
	public class GameplayConfig : ScriptableObject
	{		
		[Space]
		public float TouchRelativeDeadZone = 0.05f;
		public TouchZone TouchZone;
		
		[Space]
		public Material ObstaclesCrashMaterial;
	}
}

