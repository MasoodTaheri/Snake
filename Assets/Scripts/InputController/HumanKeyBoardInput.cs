using UnityEngine;

namespace Assets.Scripts.InputController
{
    public class HumanKeyBoardInput : IInput
    {
        public bool GetKeyup()
        {
            return Input.GetKey(KeyCode.W);
        }

        public bool GetKeyDown()
        {
            return Input.GetKey(KeyCode.S);
        }

        public bool GetKeyLeft()
        {
            return Input.GetKey(KeyCode.A);
        }

        public bool GetKeyRight()
        {
            return Input.GetKey(KeyCode.D);
        }
    }
}
