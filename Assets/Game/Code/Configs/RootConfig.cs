namespace Game.Code.Configs
{
	using Game.Code.Enums;
	using Game.Configs;
	using UnityEngine;

	[CreateAssetMenu( fileName = "Root", menuName = "Configs/Root", order = (int)EConfig.Root )]
	public class RootConfig : ScriptableObject
	{
		public GameplayConfig Gameplay;
		public HeroConfig Hero;
		public FXConfig FX;

		public LevelScenesConfig LevelScenes;
		public EditorConfig Editor;
	}
}

