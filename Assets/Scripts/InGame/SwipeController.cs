using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private bool _canTouch = true;
    [SerializeField] private float _dragDistance = 1f;
    [SerializeField] private float _shrinkSpeed = 1f;
    [SerializeField] private float _shrinkScale = .5f;

    private bool _hasBeenShot;
    private Vector2 _startTouchPosition, _endTouchPosition, _direction;
    private float _timeShot;
    private Rigidbody2D _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(_hasBeenShot)
        {
            float timeSinceShot = Time.time - _timeShot;

            float scaler = Mathf.Lerp(1f, _shrinkScale, timeSinceShot * _shrinkSpeed);
            transform.localScale = Vector3.one * scaler;
        }

        if(Input.touchCount> 0 && Input.GetTouch(0).phase==TouchPhase.Began  && _canTouch)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }
        if(Input.touchCount> 0 && Input.GetTouch(0).phase==TouchPhase.Ended  && _canTouch)
        {
                _timeShot = Time.time;
                _endTouchPosition = Input.GetTouch(0).position;
                if(_endTouchPosition.x > _startTouchPosition.x + _dragDistance || _endTouchPosition.y > _startTouchPosition.y + _dragDistance){
                    _direction = _startTouchPosition - _endTouchPosition;
                    _canTouch = false;
                    _rb.simulated = true;
                    _hasBeenShot = true;
                    _rb.AddForce(-_direction.normalized * _force, ForceMode2D.Impulse);
                }
        }

        //PC TESTING
        /*
        if(Input.GetMouseButtonDown(0)  && _canTouch)
        {
            _startTouchPosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0) && _canTouch)
        {
                _timeShot = Time.time;
                _endTouchPosition = Input.mousePosition;
                _direction = _startTouchPosition - _endTouchPosition;

                _canTouch = false;
                _rb.simulated = true;
                _hasBeenShot = true;
                _rb.AddForce(-_direction.normalized * _force, ForceMode2D.Impulse);
        }*/
    }
}
