 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodcontroller : MonoBehaviour
{
    public BoxCollider2D gridarea;
    public SnakeMovement scr;   
    
    private void RanomIzePosition()
    {
        Bounds bound = this.gridarea.bounds;
        float x= Mathf.Round( Random.Range(bound.min.x, bound.max.x));
        float y= Mathf.Round(Random.Range(bound.min.y, bound.max.y));
        
        this.transform.position = new Vector2(x, y);
    }
    private void Start()
    {
        RanomIzePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.name == "Snake")
        {
            RanomIzePosition();
            scr.Grow();
        }
    }


}
