using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _ballPrefab;
    [Tooltip("«начение (по модулю) угла, максимального при старте")]
    [SerializeField] private float _absSpawnAngle = 30f;

    private void FixedUpdate()
    {
        if (GameManager.Instance.activeBall == null)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameManager.Instance.activeBall = Instantiate(_ballPrefab, _point);
    }

    void OnSpawn()
    {
        GameManager.Instance.activeBall.transform.localRotation = Quaternion.Euler(0f, Random.Range(-_absSpawnAngle, _absSpawnAngle), 0f);
        GameManager.Instance.activeBall.GetComponent<BallMovement>()._isSleep = false;
        GameManager.Instance.activeBall.transform.SetParent(null);
    }
}
