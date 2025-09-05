using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject laser;

    public float maxRange = 1000;
    public GameObject laserImpact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetLaser(bool fire)
    {
        if (fire)
        {
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (laser.activeSelf)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.TransformPoint(new Vector3(0, 1.1f, 0)), transform.up, out hit, maxRange))
            {
                if (hit.collider.gameObject.CompareTag("Eddite"))
                {
                    hit.collider.gameObject.GetComponent<EdditeController>().Explode();
                }
                Instantiate(laserImpact, hit.point, Quaternion.identity);
                
            }
        }
    }

    // Optional: Visualize the ray in the editor for debugging
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.TransformPoint(new Vector3(0,1.1f,0)), transform.up * maxRange);
    }
}
