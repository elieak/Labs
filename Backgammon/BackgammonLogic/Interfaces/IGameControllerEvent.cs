namespace BackgammonLogic.Interfaces
{
    public interface IGameControllerEvent
    {
        void OnGamestateUpdate();
        void OnGameEnd();
    }
}