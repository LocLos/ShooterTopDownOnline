using UnityEngine;

namespace ShooterTopDown
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private Camera _camera;

        public Camera MainCamera
        {
            get { return _camera; }
        }

        private void OnEnable()
        {
            _camera = Camera.main;
        }


        private void LateUpdate()
        {
            _camera.transform.position = transform.position + _offset;
        }
    }
}