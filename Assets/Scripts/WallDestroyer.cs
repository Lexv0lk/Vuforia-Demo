using UnityEngine;

public class WallDestroyer : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void DestroyWall(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);
        foreach (var collider in colliders)
        {
            Destroyable destroyablePart;
            if (collider.TryGetComponent(out destroyablePart))
                destroyablePart.Explode(_explosionForce, position, _explosionRadius);
        }
    }
}
