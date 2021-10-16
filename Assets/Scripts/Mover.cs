using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Mover : MonoBehaviour
{
    [Header("Move To Camera")]
    [SerializeField] private float _stopPointAfterCamera;
    [Header("Moves")]
    [SerializeField] private bool _makeMoveDown;
    [SerializeField] private float _durationY;
    [SerializeField] private float _durationX;

    [SerializeField] private bool _makeEndlessRotation;
    [SerializeField] private float _durationRotation;

    private PositionsBirds[] _wayPoints;
    private bool isMoveAround;
    private Tweener _tween;
    private Vector3 _targetLastPosition;
    private Transform _target;

    private Sequence _sequenceTwins;
    void Start()
    {
        _sequenceTwins = DOTween.Sequence();
        if (_makeEndlessRotation)
            MoveEndlessRotation();
    }
     void Update()
    {
        if(isMoveAround && _targetLastPosition != _target.position)
        {
            _tween.ChangeEndValue(_target.position, true).Restart();
            _targetLastPosition = _target.position;
        }
    }
    public void StartMove()
    {
        if (_makeMoveDown)
            MoveDown();
    }
    public void MoveEndlessRotation()
    {
        transform.DORotate(new Vector3(0,0,270), _durationRotation).SetEase(Ease.Linear).SetRelative().SetLoops(-1);
    }
    public void MoveDown()
    {
        transform.DOMoveY(_stopPointAfterCamera, _durationY).SetEase(Ease.Linear);
    }
    public void Stop()
    {
        transform.DOKill();
    }
    public void MoveAround()
    {
        isMoveAround = true;
        _target = GetComponent<Bird>().PositionAround.transform;
        _tween = transform.DOMove(_target.position, 2).SetAutoKill(false);
        _targetLastPosition = _target.position;
        //Tween tween = transform.DOPath(_wayPoints, 5, PathType.CatmullRom).SetOptions(true).SetLoops(-1);
    }
}
