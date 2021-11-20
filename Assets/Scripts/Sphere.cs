using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private enum State { Pooled, Spawned };
    private State state;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        Pool();
    }

    private void Pool()
    {
        state = State.Pooled;
        this.rigidbody.isKinematic = true;
        this.transform.localPosition = new Vector3((int)Random.Range(-10f, 10f), 0f, 0f);
    }

    public void Spawn()
    {
        if (state == State.Pooled)
        {
            state = State.Spawned;
            this.rigidbody.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            Pool();
        }
    }
}
