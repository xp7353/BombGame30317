using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public AudioSource enermyAudio;
    public GameObject explosionEffect;
    public Transform target;
    private Rigidbody rig;
    public float speed = 20f;
    private bool scored = false;

    public AudioSource enermyaudio;

    void Start()
    {
        enermyaudio = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < 10f)
        {
            Vector3 trans = target.position - transform.position;
            rig.AddForce(trans * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && scored == false)
        {
            enermyaudio.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            scored = true;
            GameManager.instance.AddScore(1);
            transform.position = new Vector3(Random.Range(-30, 30), 0.5f, Random.Range(-30, 30));
            scored = false;
        }
    }
}