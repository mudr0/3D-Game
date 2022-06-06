using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject Key;

    private Animation _animation;
    private bool _isOpened = false;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isOpened && Key == null)
        {
            _audioSource.Play();
            _animation.Play();
            _isOpened = true;
        }
    }
}
