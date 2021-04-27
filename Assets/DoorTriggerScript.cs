using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    public GameObject Door;
    public Transform PosClosed;
    public Transform PosOpen;
    public float OpenTime = 0.0f;
    public bool DoorClosed = true;

    private float speed = 0;
    private Transform endPoint;

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(DoorOpen());
    }

    IEnumerator DoorOpen()
    {
        speed = Vector3.Distance(PosClosed.position, PosOpen.position) / OpenTime;

        if (DoorClosed == true)
        {
            endPoint = PosOpen;
            DoorClosed = false;
        }
        else
        {
            endPoint = PosClosed;
            DoorClosed = true;
        }

        while ((Door.transform.position - endPoint.position).sqrMagnitude > 0.001f)
        {
            Door.transform.position = Vector3.MoveTowards(Door.transform.position,
                endPoint.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
