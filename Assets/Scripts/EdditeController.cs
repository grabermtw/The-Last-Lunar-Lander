using UnityEngine;

public class EdditeController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject edditeMesh;
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent;
    Transform moonBase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        moonBase = GameObject.FindWithTag("MoonBase").transform;
        agent.destination = moonBase.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void Explode()
    {
        explosion.SetActive(true);
        edditeMesh.SetActive(false);
        agent.isStopped = true;
    }
}
