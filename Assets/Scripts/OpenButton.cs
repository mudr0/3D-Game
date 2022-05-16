using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    [SerializeField] GameObject OpenableDoor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(OpenableDoor);
        }
    }
}
