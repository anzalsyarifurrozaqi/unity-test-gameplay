using UnityEngine;
using Manager;

public class Setting : MonoBehaviour {
    private void Awake() {
        Debug.Log("init setting");
        InputManager.Instance.LoadPlayerInput();
    }
}
