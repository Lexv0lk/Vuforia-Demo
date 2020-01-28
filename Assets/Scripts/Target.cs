using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform Center => _center;
    public DefaultTrackableEventHandler DefaultTrackableEventHandler => _defaultTrackableEventHandler;

    [SerializeField] private Transform _center;
    [SerializeField] private DefaultTrackableEventHandler _defaultTrackableEventHandler;
}
