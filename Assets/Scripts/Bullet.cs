using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float LifeTime = 1;
    [SerializeField] float Damage;
    [SerializeField] string TargetTag;

    private float _currentTime = 0;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= LifeTime)
        {
            _currentTime = 0;
            Destroy(gameObject);
        }
    }

    public void MoveBullet(Transform gunPoint)
    {
        _rigidBody.AddForce(gunPoint.forward * Speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
