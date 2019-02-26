using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float moveSpeed = 100f;
    public GameObject centre;
    private GameManager _gm;

    private float movement = 0f;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        {
            transform.RotateAround(Vector3.zero, Vector3.down, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            _gm.ScorePlus();
            Destroy(this.gameObject);
        }
    }
}
