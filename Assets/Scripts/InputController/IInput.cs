namespace Assets.Scripts.InputController
{
    public interface IInput
    {
        bool GetKeyup();
        bool GetKeyDown();
        bool GetKeyLeft();
        bool GetKeyRight();
    }
}