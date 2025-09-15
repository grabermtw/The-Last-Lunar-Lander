using UnityEngine;

public class EdditeExploder : MonoBehaviour
{
   

    public void OnParticleSystemStopped()
    {
        Destroy(transform.parent.gameObject);
    }
}
