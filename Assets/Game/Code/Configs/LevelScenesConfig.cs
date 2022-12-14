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
		
		[Space] 
		public List<SceneField> Levels;
	}
}

