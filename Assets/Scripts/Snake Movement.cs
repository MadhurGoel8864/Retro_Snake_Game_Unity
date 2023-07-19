using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SnakeMovement : MonoBehaviour
{
    public Vector2 direc = Vector2.right;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public Text score_txt;
    public Text game_txt;
    public Button btn;
    bool is_alive = true;
    void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
        is_alive = false;
        }
        if (collision.gameObject.tag == "own")
        {
        is_alive = false;
        }
    }

    public void RestartLeve()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void Update()
    {
        if(is_alive == true)
        {
            game_txt.enabled = false;
            btn.gameObject.SetActive(false);
        }
        else
        {
            btn.gameObject.SetActive(true);
            game_txt.enabled=true;

        }

        score_txt.text = "Score: " + segments.Count.ToString();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direc = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direc = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direc = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direc = Vector2.left;
        }
    
    }
    private void FixedUpdate()
    {
        if (is_alive)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;

            }
            this.transform.position = new Vector2(Mathf.Round(this.transform.position.x + direc.x), Mathf.Round(this.transform.position.y + direc.y));
        }
    }
    public void Grow()
    {
        Transform seg = Instantiate(this.segmentPrefab);
        seg.transform.position = segments[segments.Count - 1].position; 
        segments.Add(seg);
    }

}
