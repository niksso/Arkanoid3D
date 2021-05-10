using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _speedAddValue = 1f;
    [SerializeField] private float _maximumSpeed = 50f;

    [Tooltip("Коэфицент, на который умножается значение отскока от платформы.")]
    [SerializeField] private float _platformAngleMultiplyer;

    [Header("Visual")]
    [SerializeField] private Transform _ballGFX;

    [HideInInspector]
    public bool _isSleep = true;

    private void FixedUpdate()
    {
        if (_isSleep)
            return;

        transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        _ballGFX.Rotate(new Vector3(1f, 0f, 0f) * _speed);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _speed/40))
        {
            if (hit.collider.tag == "DeathZone")
            {
                GameManager.Instance.countToFail++;
                GameManager.Instance.UIUpdate();

                GameManager.Instance.activeBall = null;
                Destroy(this.gameObject);
                return;
            }

            Vector3 newDirection = Vector3.Reflect(transform.forward, hit.normal);

            if (hit.collider.tag == "Platform")
            {

                if (hit.collider.transform.position.x >= hit.point.x)
                {
                    newDirection = new Vector3(newDirection.x - _platformAngleMultiplyer * (hit.collider.transform.position.x - hit.point.x), 0, newDirection.z);
                }
                else
                {
                    newDirection = new Vector3(newDirection.x + _platformAngleMultiplyer * (hit.point.x - hit.collider.transform.position.x), 0, newDirection.z);
                }

                transform.rotation = Quaternion.LookRotation(newDirection);

                if (_speed < _maximumSpeed)
                    _speed += _speedAddValue;

                GameManager.Instance.countToCatch++;
                GameManager.Instance.UIUpdate();
            }
            else
            {
                newDirection = new Vector3(newDirection.x, 0, newDirection.z);
            }

            transform.rotation = Quaternion.LookRotation(newDirection);

        }
    }

}
