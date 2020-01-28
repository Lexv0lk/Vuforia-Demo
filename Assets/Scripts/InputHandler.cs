using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private WallDestroyer _wallDestroyer;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
    }

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Destroyable destroyablePart;
                if (hit.collider.TryGetComponent(out destroyablePart))
                    _wallDestroyer.DestroyWall(hit.point);
            }
        }
    }
}
