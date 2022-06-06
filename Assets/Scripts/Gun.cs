using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform GunPoint;
    [SerializeField] float CoolDownTime;

    private AudioSource _audioSource;
    private float _currentTime = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space) && _currentTime >= CoolDownTime)
        {
            _audioSource.Play();
            _currentTime = 0;
            var bullet = Instantiate(Bullet, GunPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().MoveBullet(GunPoint);
        }
    }
}
