using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToCameraMover : MonoBehaviour
{
    [Header("Move To Camera")]
    [SerializeField] private bool _makeMoveToCamera;
    [SerializeField] private float _speedToCamera;
    [SerializeField] private float _stopPointToCamera;
    public UnityEvent Activate;
    void Start()
    {
        StartCoroutine(MovingDown());
    }

    private void OnDestroy()
    {
        StopCoroutine(MovingDown());
    }
    IEnumerator MovingDown()
    {
        while (transform.position.y > _stopPointToCamera)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - _speedToCamera * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Activate.Invoke();
    }
}
