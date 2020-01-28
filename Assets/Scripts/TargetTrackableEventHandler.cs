using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Target))]
public class TargetTrackableEventHandler : DefaultTrackableEventHandler
{
    [SerializeField] private float _maximalMoveDelta;

    public UnityAction<Target> OnTargetMoved;
    public new UnityAction<Target> OnTargetFound;
    public new UnityAction<Target> OnTargetLost;

    private Target _target;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _lastPosition = transform.position;
        _target = GetComponent<Target>();
    }

    private void Update()
    {
        if (Vector3.Distance(_lastPosition, transform.position) > _maximalMoveDelta)
            OnMoved();
        _lastPosition = transform.position;
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        OnTargetFound?.Invoke(_target);
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        OnTargetLost?.Invoke(_target);
    }

    protected virtual void OnMoved()
    {
        OnTargetMoved?.Invoke(_target);
    }
}
