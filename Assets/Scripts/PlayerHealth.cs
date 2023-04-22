using Mirror;
using UnityEngine;

namespace ShooterTopDown
{
    public class PlayerHealth : NetworkBehaviour
    {
        [SerializeField] [SyncVar(hook = nameof(HandleChangeHp))]
        private int _value;

        private void HandleChangeHp(int oldValue, int newValue)
        {
            Debug.Log(newValue);
        }

        [ServerCallback]
        public void GetDamage(int damage)
        {
            _value -= damage;
            if (_value >= 1)
                return;

            NetworkServer.Destroy(gameObject);
        }
    }
}