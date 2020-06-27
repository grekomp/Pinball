using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class Teleport : MonoBehaviour
{
    public GameObject outPoint;
    public GameObject teleportingBall = null;
    public BulbsController bulbController;
    public CollisionEventForwarder triggerArea;
    public float delayTime;
    private Vector3 velocity = new Vector3();

    private void Awake()
    {
        triggerArea.OnTriggerEnterEvent += OnTriggerEnter;
    }

    public void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            teleportingBall = other.gameObject;
            velocity = other.attachedRigidbody.velocity;
            teleportingBall.GetComponent<Collider>().attachedRigidbody.velocity = new Vector3();
            teleportingBall.SetActive(false);
            StartCoroutine(StartTeleport());
        }
    }

    public IEnumerator StartTeleport()
    {
        bulbController.TurnOn(delayTime);
        yield return new WaitForSeconds(delayTime);
        TeleportBall();
    }

    private void TeleportBall()
    {
        teleportingBall.SetActive(true);
        teleportingBall.transform.position = outPoint.transform.position;
        teleportingBall.GetComponent<Collider>().attachedRigidbody.velocity = velocity * 5;
        velocity = new Vector3();
        teleportingBall = null;
    }
}
