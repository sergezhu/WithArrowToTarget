namespace Game.Code.Infrastructure
{
	public interface ITickable
	{
		void Tick( float deltaTime );
	}
}