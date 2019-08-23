using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// Доработать...
    /// </summary>
    //private
    /*
    Transform _start;
    Transform _end;

    Vector3 _rotation = new Vector3(0f, 0f, -180f);
    Vector3 _position;

    Vector3 _startAngle;

    bool _stopRotation = false;

    //test
    float _nextTime = 0f;
    float _stepTime = 1f;

    float _startTime;

    bool _active;

    float _x;
    float _y;
    float _z;

    private void Awake()
    {
        _end = transform;
        _position = transform.position;
        _rotation = transform.eulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(_position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopRotation && _nextTime > 0f && _nextTime < Time.time)
        {
            //Debug.Log(_position);

            if (_active)
            {
                _active = false;
                _startTime = Time.time;
                _startAngle = transform.eulerAngles;
                //_startAngle.z *= -1;
                Debug.Log("A  " + _startAngle);
                Debug.Log("Rot = " + _rotation);
                if (_startAngle.x > 180)
                    _startAngle.x = 360 - _startAngle.x;
                if (_startAngle.y > 180)
                    _startAngle.y = 360 - _startAngle.y;
                if (_startAngle.z > 180)
                    _startAngle.z = 360 - _startAngle.z;

                Debug.Log("B  " + _startAngle);

            }

            transform.position = _position;
            //if (transform.rotation.x > 0f)
            //    _x = transform.rotation.x - 0.1f;
            //if (transform.rotation.y > 0f)
            //    _y = transform.rotation.y - 0.1f;
            //if (transform.rotation.z > 180f)
            //    _z = transform.rotation.z - 0.1f;
            //else if (transform.rotation.z < 180f)
            //    _z = transform.rotation.z + 0.1f;

            //transform.rotation = Quaternion.Euler(new Vector3(_x, _y, _z));
            transform.eulerAngles = Vector3.Lerp(_startAngle, _rotation, (Time.time - _startTime) * 3f);
            if (transform.eulerAngles == _rotation)
                _stopRotation = false;
        }
        else if (!_stopRotation)
        {
            transform.position = _position;
            transform.rotation = Quaternion.Euler(_rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Control>())
        {
            _stopRotation = true;
        _active = true;
            _nextTime = Time.time + _stepTime;
        }
    }
    */
}
