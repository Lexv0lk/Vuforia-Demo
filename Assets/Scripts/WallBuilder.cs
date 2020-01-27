using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Transform _wall;

    public void CreateWall(Vector3 from, Vector3 to)
    {
        _wall.gameObject.SetActive(true);

        float distance = Vector3.Distance(from, to);
        Vector3 direction = to - from;
        float angle = -Vector3.SignedAngle(direction, transform.forward, Vector3.up);
        Vector3 center = (from + to) / 2;

        _wall.position = center;
        _wall.transform.eulerAngles = new Vector3(_wall.eulerAngles.x, angle, _wall.eulerAngles.z);
        _wall.localScale = new Vector3(_wall.localScale.x, _wall.localScale.y, distance);
    }

    public void DestroyWall() => _wall.gameObject.SetActive(false);
}
