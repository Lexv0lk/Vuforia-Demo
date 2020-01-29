using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _minimalColorLength;
    [SerializeField] private float _maximalColorLength;
    [SerializeField] private Renderer _wallRenderer;
    [SerializeField] private Material _material;

    private Destroyable[] _wallParts;

    private void Awake()
    {
        _wallParts = transform.GetComponentsInChildren<Destroyable>();
    }

    private void OnEnable()
    {
        foreach (var destroyablePart in _wallParts)
            destroyablePart.OnExploded += DisableWallRenderer;
    }

    private void OnDisable()
    {
        foreach (var destroyablePart in _wallParts)
            destroyablePart.OnExploded -= DisableWallRenderer;
    }

    public void SetColor(float wallLength)
    {
        float colorPart = 1 - Convert(Mathf.Clamp(wallLength, _minimalColorLength, _maximalColorLength), _minimalColorLength, _maximalColorLength, 0, 1);
        _material.color = new Color(1, colorPart, colorPart, 1);
    }

    private void DisableWallRenderer() => _wallRenderer.enabled = false;

    private float Convert(float value, float lastMinimum, float lastMaximum, float newMinimum, float newMaximum) => (value - lastMinimum) / (lastMaximum - lastMinimum) * (newMaximum - newMinimum) + newMinimum;
}
