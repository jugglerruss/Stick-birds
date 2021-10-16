using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Drag _drag;
    private Vector3 _positionStart;
    void Start()
    {
        _positionStart = transform.position;
    }
    public void ChangePosition()
    {
        var point = _camera.WorldToViewportPoint(_positionStart + _drag.Position);        
        transform.position = CheckPosition(point);
    }
    public void FixPosition()
    {
        _positionStart = transform.position;
    }
    private Vector3 CheckPosition(Vector3 point)
    {
        var minX = 0.15f;
        var minY = 0.05f;
        if (point.x < minX) point.x = minX;
        if (point.y < minY) point.y = minY;
        if (point.x > 1f - minX) point.x = 1f - minX;
        if (point.y > 1f - minY) point.y = 1f - minY;
        return _camera.ViewportToWorldPoint(point);
    }
}
