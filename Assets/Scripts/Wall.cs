using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float _minimalColorLength;
    [SerializeField] private float _maximalColorLength;
    [SerializeField] private Material _material;

    public void SetColor(float wallLength)
    {
        float colorPart = 1 - Convert(Mathf.Clamp(wallLength, _minimalColorLength, _maximalColorLength), _minimalColorLength, _maximalColorLength, 0, 1);
        _material.color = new Color(1, colorPart, colorPart, 1);
    }

    private float Convert(float value, float lastMinimum, float lastMaximum, float newMinimum, float newMaximum) => (value - lastMinimum) / (lastMaximum - lastMinimum) * (newMaximum - newMinimum) + newMinimum;
}
