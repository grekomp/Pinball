using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class BlackHole : MonoBehaviour
{
    public CollisionEventForwarder triggerArea;
    public GameObject collider;
    public GameObject output;
    public GameObject vacumedBall;
    public ScoreObstacle scoreObstacle;
    public float delayTime = 3f;
    public Vector3 velocity = new Vector3();

    private void Awake()
    {
        triggerArea.OnTriggerEnterEvent += OnTriggerEnter;
        scoreObstacle = gameObject.GetComponent<ScoreObstacle>();
    }

    public void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            scoreObstacle.Hit();
            vacumedBall = other.gameObject;
            StartCoroutine(KeepBal());
        }
    }

    public IEnumerator KeepBal()
    {
        velocity = vacumedBall.GetComponent<Collider>().attachedRigidbody.velocity;
        vacumedBall.GetComponent<Collider>().attachedRigidbody.velocity = new Vector3();
        vacumedBall.SetActive(false);
        StartCoroutine(TurnOffCollider());
        yield return new WaitForSeconds(delayTime);
        vacumedBall.SetActive(true);
        vacumedBall.GetComponent<Collider>().attachedRigidbody.velocity = velocity * (-1);
    }

    public IEnumerator TurnOffCollider()
    {
        collider.SetActive(false);
        yield return new WaitForSeconds(delayTime + 3f);
        collider.SetActive(true);
    }
}
