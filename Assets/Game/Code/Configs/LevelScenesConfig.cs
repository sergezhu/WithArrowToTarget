namespace Game.Code.Configs
{
	using System.Collections.Generic;
	using Game.Code.Enums;
	using Game.Code.Utilities;
	using UnityEngine;

	[CreateAssetMenu( fileName = "Scenes", menuName = "Configs/Scenes", order = (int) EConfig.LevelScenes )]
	public class LevelScenesConfig : ScriptableObject
	{
		public SceneField StartScene;
		
		[Space] // TO DO here was pages disabled
		public List<SceneField> Levels;

		[Space]
		public bool UseOverride;
		public SceneField OverrideLevel;
	}
}

