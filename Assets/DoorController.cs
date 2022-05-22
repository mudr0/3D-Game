using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject Key;

    private Animation _animation;
    private bool _isOpened = false;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isOpened && Key == null)
        {
            _animation.Play();
            _isOpened = true;
        }
    }
}
