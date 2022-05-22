using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _gun;
    [SerializeField] float MouseSensitivity;

    private float _y;

    void Update()
    {
        var xRot = Input.GetAxis("Mouse X");
        var yRot = Input.GetAxis("Mouse Y");

        _y -= yRot;
        _y = Mathf.Clamp(_y, -60, 60);

        _player.Rotate(new Vector3(0, xRot * MouseSensitivity * 2, 0));
        _gun.Rotate(new Vector3(-yRot * MouseSensitivity * 2, 0, 0));
        transform.localRotation = Quaternion.Euler(_y * MouseSensitivity, 0, 0);
    }
}
