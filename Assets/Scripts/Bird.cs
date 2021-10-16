using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Linq;

public class Bird : MonoBehaviour
{
    [SerializeField] public UnityEvent OnNotFree;

    private Birds _birds;
    private bool _isFree;
    public PositionsBirds PositionAround { get; private set; }

    void Start()
    {
        if (transform.parent.TryGetComponent(out Birds birds))
        {
            _birds = birds;
            _isFree = false;
            PositionAround = transform.parent.GetComponentsInChildren<PositionsBirds>().Where(p => p.IsEmpty()).First();
            PositionAround.PutIn();
        }
    }
    public void Activate()
    {
        _isFree = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isFree)
        {
            if ( collision.gameObject.TryGetComponent(out Bird bird) )
            {
                if (_birds!=null)
                {
                    bird.transform.SetParent(_birds.transform);
                    bird.PositionAround = transform.parent.GetComponentsInChildren<PositionsBirds>().Where(p => p.IsEmpty()).First();
                    bird.PositionAround.PutIn();
                    bird.NotFree();
                }
            }
            if (collision.gameObject.TryGetComponent(out Rockets rocket))
            {
                PositionAround.Clear();
                gameObject.SetActive(false);
                rocket.gameObject.SetActive(false);
            }
        }
    }
    public void NotFree()
    {
        _isFree = false;
        OnNotFree.Invoke();
    }

}
