using UnityEngine;

namespace Player.Function {
    public class ShotDirection : PlayerFunction {
        static private float _shotDistance = 10f;
        public override void RunFunction() {
            RaycastHit hit;

            if (Physics.Raycast(PlayerControl.transform.position, PlayerControl.transform.forward, out hit, _shotDistance)) {
                Debug.Log(hit.transform.name);
            }

            Debug.DrawRay(PlayerControl.transform.position, PlayerControl.transform.forward * 10, Color.red);
        }
    }
}


