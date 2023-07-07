using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D grid;
    private void Start()
    {
        randomPos();
    }

    private void randomPos()
    {
        Bounds bounds = this.grid.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(x, y, 0.0f);


    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.tag== "Player")
        {
            randomPos();
        }
       
    }
}
