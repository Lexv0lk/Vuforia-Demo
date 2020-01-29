using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour
{
    public UnityAction OnExploded;

    private Rigidbody _rigidbody;

    public void Explode(float explositonForce, Vector3 explosionPosition, float explosionRadius)
    {
        if (_rigidbody == null)
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.AddExplosionForce(explositonForce, explosionPosition, explosionRadius);
        OnExploded?.Invoke();
    }
}
