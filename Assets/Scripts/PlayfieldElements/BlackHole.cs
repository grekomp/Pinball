using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class BlackHole : MonoBehaviour
{
    public CollisionEventForwarder triggerArea;
    public GameObject output;
    public GameObject vacumedBall;
    public float delayTime = 3f;
    public Vector3 velocity = new Vector3();

    private void Awake()
    {
        triggerArea.OnTriggerEnterEvent += OnTriggerEnter;
    }

    public void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            vacumedBall = other.gameObject;
            StartCoroutine(KeepBal());
        }
    }

    public IEnumerator KeepBal()
    {
        vacumedBall.GetComponent<Collider>().attachedRigidbody.velocity = new Vector3();
        vacumedBall.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        vacumedBall.SetActive(true);
        vacumedBall.GetComponent<Collider>().attachedRigidbody.velocity = velocity * (-1);
    }
}
