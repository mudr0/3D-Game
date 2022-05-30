using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] GameObject _pauseMenu;

    private Vector3 m_Movement;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        transform.Translate(m_Movement * Time.deltaTime * _speed);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
