using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputKey
{
    /// <summary>
    /// 同時入力を禁止する
    /// </summary>
    public static class MyInput
    {
        static string isCheck_Input;

        public static bool MyInputKey(KeyCode key)
        {
            //if (Input.anyKey == false) isCheck_Input = false;

            //if (isCheck_Input == false)
            //{
            //    if (Input.GetKey(key))
            //    {
            //        isCheck_Input = true;
            //        return true;
            //    }
            //}
            return false;
        }

        public static bool MyInputButton(string key)
        {
            if (Input.anyKey == false) isCheck_Input = null;
            if (isCheck_Input == null)
            {
                if(Input.GetButton(key))
                {
                    isCheck_Input = key;
                    Debug.Log(isCheck_Input);               
                    if (Input.GetButton(key)==Input.GetButton(isCheck_Input))
                    {
                        return false;
                    }
                    return true;

                }
                
            }
            return false;

        }
    }
}