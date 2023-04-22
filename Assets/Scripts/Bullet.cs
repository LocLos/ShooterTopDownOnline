using Mirror;
using ShooterTopDown;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private int _damage;

    public override void OnStartClient()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    [ServerCallback]
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth health))
        {
            health.GetDamage(_damage);
        }

        NetworkServer.Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
}