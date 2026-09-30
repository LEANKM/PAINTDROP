using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartTeleport(Vector3 newPosition)
    {
        StartCoroutine(RoutineTeleport(newPosition));
    }

    IEnumerator RoutineTeleport(Vector3 newPosition)
    {
        yield return new WaitForSeconds(0.5f);

        transform.position = newPosition;
    }
}