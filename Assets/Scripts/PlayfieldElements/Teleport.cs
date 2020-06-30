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
    public AudioController audioController;
    public ScoreObstacle scoreObstacle;
    public float delayTime;
    private Vector3 velocity = new Vector3();

    private void Awake()
    {
        triggerArea.OnTriggerEnterEvent += OnTriggerEnter;
        scoreObstacle = gameObject.GetComponent<ScoreObstacle>();
        audioController = GameObject.Find("Main Camera").GetComponent<AudioController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            scoreObstacle.Hit();
            teleportingBall = other.gameObject;
            velocity = other.gameObject.GetComponent<Collider>().attachedRigidbody.velocity;
            teleportingBall.GetComponent<Collider>().attachedRigidbody.velocity = new Vector3();
            teleportingBall.SetActive(false);
            audioController.Teleport();
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
