using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    [SerializeField] private float _blowRadius;
    [SerializeField] private float _blowForce;

    public void DestroyWall(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _blowRadius);
        foreach (var collider in colliders)
        {
            Destroyable destroyablePart;
            if (collider.TryGetComponent(out destroyablePart))
            {
                collider.gameObject.AddComponent<Rigidbody>();
                collider.attachedRigidbody.AddExplosionForce(_blowForce, position, _blowRadius);
            }
        }
    }
}
