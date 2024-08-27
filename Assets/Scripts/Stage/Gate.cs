using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public Transform pos;
    public Vector2 boxSize;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 1), 0);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.CompareTag("Player"))
            {
                SceneManager.LoadScene("Stage2");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
