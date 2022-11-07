using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Function
{
    public class Look : CharacterFunction
    {
        public override void RunFunction(Vector2 pointerPosition)
        {
            Debug.Log(pointerPosition);
        }
    }
}
