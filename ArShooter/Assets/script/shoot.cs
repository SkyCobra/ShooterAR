using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public float power = 100;

    public int CoolDown = 1;
    private int Shoot = 0;
    private object touch;
    private bool inCoolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1") && inCoolDown == false)
        {
            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.velocity = transform.TransformDirection(Vector3.forward * power * 2);
            Destroy(clone.gameObject, 5);
            inCoolDown = true;
            StartCoroutine(CoolDownShoot());
        }
    }

    private IEnumerator CoolDownShoot()
    {
        yield return new WaitForSeconds(CoolDown);
        inCoolDown = false;
    }
}
