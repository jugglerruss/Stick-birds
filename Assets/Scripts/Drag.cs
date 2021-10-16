using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
    [SerializeField] public UnityEvent DragEvent;
    [SerializeField] public UnityEvent StopDrag;
    [SerializeField] private Camera _camera;
    public Vector3 Position { get;  private set; }
    private Vector3 _position;
    private void Start()
    {
        
    }
    private void OnMouseDrag()
    {
        Position = _camera.ScreenToWorldPoint(Input.mousePosition) - _position;
        DragEvent.Invoke();
    }
    private void OnMouseDown()
    {
        _position = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        StopDrag.Invoke();
    }
}
