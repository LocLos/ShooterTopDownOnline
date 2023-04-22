using Mirror;
using UnityEngine;

namespace ShooterTopDown
{
    public class PlayerMove : NetworkBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InputSystem _inputSystem;

        [SerializeField] private float _speed;
        private Camera _camera;


        public override void OnStartAuthority()
        {
            _cameraController.gameObject.SetActive(true);
            _camera = _cameraController.MainCamera;
        }

        [ClientCallback]
        void Update()
        {
            if (!isLocalPlayer)
                return;

            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = _inputSystem.InputVector * _speed;
            var mousePos = _camera.ScreenToWorldPoint(_inputSystem.MousePosition) - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos);
        }
    }
}