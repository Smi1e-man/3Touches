using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //private visual values
	[SerializeField] private GameObject _dir;

    //private values
	private float _defScale = 1f;
	private float _scaleCoef;
	private float _SlowMotion;
	private float _deltaImpulse;
	private float _dynFriction;
	private float _statFriction;
	private float _drag;
	private float _scaleMax;
	private float _scaleMin;
	private Transform _transform;
	private Transform _dirTransform;
	private Collider _col;
	private Rigidbody _rigidbody;
	private Vector3 _dirpos;
	private Vector3 _down;
	private Vector3 _tmp;
	private Vector3 _up;
	private Vector3 _scale = new Vector3();

    /// <summary>
    /// Private Methods.
    /// </summary>
	private void Start()
	{
		_dirTransform = _dir.transform;
		_dirpos = _dirTransform.position;
		_scaleMax = Resources.Load<BallSetting>("Settings/BallSetting").ScaleMax;
		_scaleMin = Resources.Load<BallSetting>("Settings/BallSetting").ScaleMin;
		_deltaImpulse = Resources.Load<BallSetting>("Settings/BallSetting").BallImpulse;
		_drag = Resources.Load<BallSetting>("Settings/BallSetting").Drag;
		 _dynFriction = Resources.Load<BallSetting>("Settings/BallSetting").Dynamic_Friction;
		 _statFriction = Resources.Load<BallSetting>("Settings/BallSetting").Static_Friction;
		 _scaleCoef = Resources.Load<BallSetting>("Settings/BallSetting").Scale_Coef;
		 _SlowMotion = Resources.Load<BallSetting>("Settings/BallSetting").SlowMotion;
		 _transform = transform;
		_rigidbody = _transform.GetComponent<Rigidbody>();
		_col = _transform.GetComponent<Collider>();
		_col.material.dynamicFriction = _dynFriction;
		_col.material.staticFriction = _statFriction;
		_rigidbody.drag = _drag;
	}

    private void Update()
	{
		if (Input.GetMouseButtonDown(0))
			MouseDown();
		if (Input.GetMouseButton(0))
		{
			_tmp = Input.mousePosition;
			Dir();
		}
		if (Input.GetMouseButtonUp(0))
			MouseUp();
		_dirpos.x = _transform.position.x;
		_dirpos.z = _transform.position.z;
		_dirTransform.position = _dirpos;
	}

    private void MouseDown()
	{
		if (_rigidbody.velocity != Vector3.zero)
			Time.fixedDeltaTime = 0.02F * _SlowMotion;
			Time.timeScale = _SlowMotion;
		_down = Input.mousePosition;
	}
    private void MouseUp()
	{
		_rigidbody.useGravity = true;
		Time.fixedDeltaTime = 0.02F;
		Time.timeScale = 1f;
		_up = Input.mousePosition;
		GameManager.Gm.BallMove();
		PushObj();
	}

    private void Dir()
	{
		float distance = Vector3.Distance(_down, _tmp);
		float scale = distance / _scaleCoef + 1;
		if (scale >= _scaleMin && scale <= _scaleMax)
			_scale = ChangeVectorValue(_scale, scale);
		else if (scale < _scaleMin)
			_scale = ChangeVectorValue(_scale, _scaleMin);
		else
			_scale = ChangeVectorValue(_scale, _scaleMax);
		_dirTransform.localScale = _scale;
		Vector3 direction = _tmp - _down + _transform.position;
		direction.z = direction.y;
		direction.y = _dirTransform.position.y;
		_dirTransform.LookAt(direction);
	}

    private void PushObj()
	{
		_scale = ChangeVectorValue(_scale, _scaleMin);
		_dirTransform.localScale = _scale;
		Vector3 _direction = _down - _up + _transform.position;
		_direction.z = _direction.y;
		_direction.y = _transform.position.y;
		_rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(_direction * _deltaImpulse);
		GameManager.Gm.Touch();
	}

    private Vector3 ChangeVectorValue(Vector3 vector, float value)
	{
		vector.x = value;
		vector.y = value;
		vector.z = value;
		return vector;
	}
}
