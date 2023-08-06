namespace App
{
    public class GameListeners
    {
    }

    public interface IGameListener
    {
    }

    public interface IGameStartListener : IGameListener
    {
        void OnGameStarted();
    }

    public interface IGameFinishListener : IGameListener
    {
        void OnGameFinished();
    }

    public interface IGameUpdateListener : IGameListener
    {
        void OnUpdate(float deltaTime);
    }

    public interface IGameFixedUpdateListener : IGameListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}