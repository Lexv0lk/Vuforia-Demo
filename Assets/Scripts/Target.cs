using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform Center => _center;
    public TargetTrackableEventHandler TargetTrackableEventHandler => _targetTrackableEventHandler;

    [SerializeField] private Transform _center;
    [SerializeField] private TargetTrackableEventHandler _targetTrackableEventHandler;
}
