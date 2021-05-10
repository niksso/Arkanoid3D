using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlatfromMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float _speed = 2f;
    
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameManager.Instance.SwitchCursorStatus(false);
    }

    void OnMovement(InputValue value)
    {
        float _direction = value.Get<float>();

        _rigidbody.velocity = new Vector3(_direction * _speed, 0f, 0f);
    }
}
