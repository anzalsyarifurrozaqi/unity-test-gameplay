using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Function
{
    public class Look : PlayerFunction
    {
        public override void RunFunction(Vector2 pointerPosition)
        {
            Debug.Log(pointerPosition);
        }
    }
}
