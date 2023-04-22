using Mirror;
using UnityEngine;

namespace ShooterTopDown
{
    public class PlayerShoot : NetworkBehaviour
    {
        [SerializeField] [SyncVar] private int _damage;

        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private PlayerAnimator _playerAnimator;

        [ClientCallback]
        void Update()
        {
            if (!isLocalPlayer)
                return;

            if (_inputSystem.IsShoot)
            {
                CmdFire();
            }
        }

        [Command]
        void CmdFire()
        {
            var bullet = Instantiate(_bulletPrefab, _bulletPoint.position, _bulletPoint.rotation);
            bullet.SetDamage(_damage);
            NetworkServer.Spawn(bullet.gameObject);
            RpcOnFire();
        }

        [ClientRpc]
        void RpcOnFire()
        {
            _playerAnimator.SetTrigger("Aim");
            _playerAnimator.SetTrigger("Shoot");
        }
    }
}