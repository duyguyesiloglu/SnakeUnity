using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{
    private Vector2 hareket = Vector2.right;
    private List<Transform> ekleme;

    public Transform eklemePrefab;

    private void Start()
    {
        ekleme = new List<Transform>();
        ekleme.Add(this.transform);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            hareket = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            hareket = Vector2.down;

        } else if (Input.GetKeyDown(KeyCode.A))
        {
            hareket = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            hareket = Vector2.right;
        }



    }
    private void FixedUpdate()
    {
        for (int i = ekleme.Count - 1; i > 0; i--)
        {
            ekleme[i].position = ekleme[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + hareket.x,
            Mathf.Round(this.transform.position.y) + hareket.y, 0.0f
            );
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.eklemePrefab);
        segment.position = ekleme[ekleme.Count - 1].position;
        ekleme.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.tag == "Food")
        {
           Grow();
        } else if (other.tag == "ob")
        {
            // ReserState()
        }

    }
}

