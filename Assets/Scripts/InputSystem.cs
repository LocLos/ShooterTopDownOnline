using UnityEngine;

namespace ShooterTopDown
{
    public class InputSystem : MonoBehaviour
    {
        public Vector2 MousePosition =>
            Input.mousePosition;

        public bool IsShoot =>
            Input.GetMouseButtonDown(0);

        public Vector2 InputVector =>
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}