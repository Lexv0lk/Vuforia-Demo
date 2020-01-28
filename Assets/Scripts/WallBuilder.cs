using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Wall _wallPrefab;

    private Wall _wall;

    public void BuildWall(Target from, Target to)
    {
        DestroyWall();
        CreateWall();

        float distance = Vector3.Distance(from.Center.position, to.Center.position);
        Vector3 distanceCenter = (from.Center.position + to.Center.position) / 2;

        _wall.transform.parent = from.transform;
        _wall.transform.position = distanceCenter;
        _wall.transform.localScale = new Vector3(_wall.transform.localScale.x, _wall.transform.localScale.y, distance);
        _wall.transform.LookAt(to.Center.position);
        _wall.transform.localEulerAngles = new Vector3(_wall.transform.localEulerAngles.x, _wall.transform.localEulerAngles.y, 0);

        _wall.SetColor(distance);
    }

    private void CreateWall()
    {
        _wall = Instantiate(_wallPrefab);
    }

    private void DestroyWall()
    {
        if (_wall != null)
            Destroy(_wall.gameObject);
    }
}
