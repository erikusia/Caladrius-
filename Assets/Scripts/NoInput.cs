using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputKey
{

    public static class NoInput
    {
        static bool isCheck_Input;

        public static bool NoInputKey(KeyCode key)
        {
            if (Input.anyKeyDown == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetKeyDown(key))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }


        //public static bool InputX(string Xbutton)
        //{
        //    if (Input.anyKey == false) isCheck_Input = false;

        //    if (isCheck_Input == false)
        //    {
        //        if (Input.GetButton(Xbutton))
        //        {
        //            isCheck_Input = true;
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public static bool InputX(string Xbutton)
        {
            if (Input.anyKey == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetButton(Xbutton))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }


        public static bool InputB(string Bbutton)
        {
            if (Input.anyKey == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetButton(Bbutton))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }


        public static bool InputY(string YButton)
        {
            if (Input.anyKey == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetButton(YButton))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }
    }
}
