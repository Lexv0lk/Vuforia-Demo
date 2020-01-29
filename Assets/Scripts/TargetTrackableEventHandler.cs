using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Target))]
public class TargetTrackableEventHandler : DefaultTrackableEventHandler
{
    public UnityAction<Target> OnTargetMoved;
    public new UnityAction<Target> OnTargetFound;
    public new UnityAction<Target> OnTargetLost;

    private Target _target;

    private void Awake()
    {
        _target = GetComponent<Target>();
    }

    private void OnEnable()
    {
        _target.OnMoved += OnMoved; 
    }

    private void OnDisable()
    {
        _target.OnMoved -= OnMoved;
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
