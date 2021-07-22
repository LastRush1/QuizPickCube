using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticle : MonoBehaviour
{
    #region Singleton
    public static StarParticle Instance;
    #endregion

    [SerializeField]
    ParticleSystem particle1;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

    }

    ParticleSystem partSys;

    public void OnParticle(Transform transform)
    {
        if (partSys != null)
        {
            Destroy(partSys.gameObject);
        }
        partSys = Instantiate(particle1, gameObject.transform);
        partSys.transform.position = new Vector3(transform.position.x, transform.position.y, -195);
        partSys.transform.localPosition = new Vector3(partSys.transform.localPosition.x, partSys.transform.localPosition.y, -195);
    }

    public void OffParticle()
    {
        particle1.Stop();

    }
}
