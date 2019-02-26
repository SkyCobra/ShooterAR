using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public float power = 100;
    public int max_rate;

    private int rate = 10;
    private int Shoot = 0;
    private object touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButton("Fire1") && Shoot == 0)
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * power * 2);
            Destroy(clone.gameObject, 10);
            Shoot = 1;
        }
        if (rate < 0)
        {
            rate = max_rate;
            Shoot = 0;
        }
        rate--;
    }
}
