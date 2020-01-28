using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TargetConnecter : MonoBehaviour
{
    [SerializeField] private Target[] _targets;
    [SerializeField] private WallBuilder _wallBuilder;

    private List<Target> _foundTargets = new List<Target>();
    private List<Target> _connectedTargets = new List<Target>();

    private void OnEnable()
    {
        foreach (var target in _targets)
        {
            target.TargetTrackableEventHandler.OnTargetFound += OnTargetFound;
            target.TargetTrackableEventHandler.OnTargetLost += OnTargetLost;
            target.TargetTrackableEventHandler.OnTargetMoved += OnTargetMoved;
        }
    }

    private void OnDisable()
    {
        foreach (var target in _targets)
        {
            target.TargetTrackableEventHandler.OnTargetFound -= OnTargetFound;
            target.TargetTrackableEventHandler.OnTargetLost -= OnTargetLost;
            target.TargetTrackableEventHandler.OnTargetMoved -= OnTargetMoved;
        }
    }

    private void ReconnectTargets()
    {
        _connectedTargets.Clear();
        if (_foundTargets.Count <= 1)
            return;

        SortTargets();
        _wallBuilder.BuildWall(_foundTargets[0], _foundTargets[1]);

        _connectedTargets.Add(_foundTargets[0]);
        _connectedTargets.Add(_foundTargets[1]);
    }

    private void SortTargets() => _foundTargets = _foundTargets.OrderBy(x => GetDistance(x.transform.position)).ToList();

    private void OnTargetMoved(Target target)
    {
        if (_connectedTargets.Contains(target) == false)
            return;
        ReconnectTargets();
    }

    private void OnTargetFound(Target target)
    {
        _foundTargets.Add(target);

        if (_foundTargets.Count >= 2)
        {
            SortTargets();
            if (_connectedTargets.Contains(_foundTargets[0]) == false && _connectedTargets.Contains(_foundTargets[1]) == false)
                ReconnectTargets();
        }
    }

    private void OnTargetLost(Target target)
    {
        _foundTargets.Remove(target);
        _connectedTargets.Remove(target);

        if (_connectedTargets.Count <= 1)
            ReconnectTargets();
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
