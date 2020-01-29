using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityAction OnMoved;

    public Transform Center => _center;
    public TargetTrackableEventHandler TargetTrackableEventHandler => _targetTrackableEventHandler;

    [SerializeField] private Transform _center;
    [SerializeField] private TargetTrackableEventHandler _targetTrackableEventHandler;
    [SerializeField] private float _maximalMoveDelta;

    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(_lastPosition, transform.position) >= _maximalMoveDelta)
            OnMoved?.Invoke();
        _lastPosition = transform.position;
    }
}
