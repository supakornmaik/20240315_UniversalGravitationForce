using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAttraction : MonoBehaviour
{
    public Rigidbody rb;

    private const float G = 6.67f;

    public static List<PlanetAttraction> pAttraction;

    void AttractorFormular(PlanetAttraction other)
    {
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        // F = G * (M1*m2)/D^2
        float forceMagnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance , 2);

        Vector3 forceDir = direction.normalized * forceMagnitude;

        rbOther.AddForce(forceDir);

    }

    void FixedUpdate()
    {
        foreach (var attraction in pAttraction)
        {
            if (attraction != this)
            {
                AttractorFormular(attraction);
            }
        }
    }//FixedUpdate


    private void OnEnable()
    {
        if (pAttraction == null)
        {
            pAttraction = new List<PlanetAttraction>();
        }

        pAttraction.Add(this);
    }

}//PlanetAttraction
