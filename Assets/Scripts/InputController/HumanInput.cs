using UnityEngine;

namespace Assets.Scripts.InputController
{
    public class HumanInput : IInput
    {
        //todo: buffer

        public bool GetKeyup()
        {
            return Input.GetKey(KeyCode.UpArrow);
        }

        public bool GetKeyDown()
        {
            return Input.GetKey(KeyCode.DownArrow);
        }

        public bool GetKeyLeft()
        {
            return Input.GetKey(KeyCode.LeftArrow);
        }

        public bool GetKeyRight()
        {
            return Input.GetKey(KeyCode.RightArrow);
        }
    }
}