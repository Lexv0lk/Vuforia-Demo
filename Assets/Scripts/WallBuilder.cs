using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Transform _wall;

    public void SetWall(Target from, Target to)
    {
        float distance = Vector3.Distance(from.Center.position, to.Center.position);
        Vector3 distanceCenter = (from.Center.position + to.Center.position) / 2;

        _wall.parent = from.transform;
        _wall.position = distanceCenter;
        _wall.localScale = new Vector3(_wall.localScale.x, _wall.localScale.y, distance);
        _wall.LookAt(to.Center.position);
        _wall.localEulerAngles = new Vector3(_wall.localEulerAngles.x, _wall.localEulerAngles.y, 0);
    }

    public void EnableWall() => ChangeWallState(true);

    public void DisableWall() => ChangeWallState(false);

    private void ChangeWallState(bool newState)
    {
        Renderer renderer;
        if (_wall.TryGetComponent(out renderer))
            renderer.enabled = newState;
    }
}
