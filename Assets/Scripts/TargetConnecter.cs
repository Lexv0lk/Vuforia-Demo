using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TargetConnecter : MonoBehaviour
{
    [SerializeField] private Target[] _targets;
    [SerializeField] private WallBuilder _wallBuilder;

    private List<Target> _foundTargets = new List<Target>();

    private void Awake()
    {
        foreach (var target in _targets)
        {
            target.DefaultTrackableEventHandler.OnTargetFound.AddListener(() => OnTargetFound(target));
            target.DefaultTrackableEventHandler.OnTargetLost.AddListener(() => OnTargetLost(target));
        }
    }

    private void Update()
    {
        if (_foundTargets.Count <= 1)
            return;
        _foundTargets = _foundTargets.OrderBy(x => GetDistance(x.transform.position)).ToList();
        _wallBuilder.BuildWall(_foundTargets[0], _foundTargets[1]);
    }

    private void OnTargetFound(Target target)
    {
        _foundTargets.Add(target);
    }

    private void OnTargetLost(Target target)
    {
        _foundTargets.Remove(target);
    }

    private float GetDistance(Vector3 to)
    {
        Vector3 origin = Camera.main.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(origin, to - origin, out hit))
            return hit.distance;
        else
            throw new ArgumentException("Invalid vector");
    }
}
