using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public float jumpPower;     //มกวมทย

    [SerializeField]
    private bool OnGround;
    private bool AirJump;

    public LayerMask Mask;

    Rigidbody2D rb2D;

    PlayerMove playerMove;
    void Start()
    {
        jumpPower = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        if (Input.GetButtonDown("JumpC"))
        {
            if (OnGround)
            {
                rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            if (!AirJump)
            {
                rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                AirJump = false;
            }
        }
    }
    private void GroundCheck()
    {
        float RayLength = playerMove.Playercollider2D.bounds.center.y - playerMove.Playercollider2D.bounds.min.y + 0.05f;
        RaycastHit2D hit = Physics2D.Raycast(playerMove.Playercollider2D.bounds.center, Vector2.down, RayLength, Mask);
        if (playerMove.transform.localScale.x < 0)
        {
            hit = Physics2D.Raycast(new Vector2(playerMove.Playercollider2D.bounds.max.x - playerMove.Playercollider2D.bounds.center.x - 0.001f, playerMove.Playercollider2D.bounds.center.y), Vector2.down, RayLength, Mask);
            if (hit.collider != null)
            {
                OnGround = true;
                AirJump = true;
                return;
            }
        }
        else if (playerMove.transform.localScale.x > 0)
        {
            hit = Physics2D.Raycast(new Vector2(playerMove.Playercollider2D.bounds.center.x - playerMove.Playercollider2D.bounds.min.x + 0.001f, playerMove.Playercollider2D.bounds.center.y), Vector2.down, RayLength, Mask);
            if (hit.collider != null)
            {
                OnGround = true;
                AirJump = true;
                return;
            }
        }
        else
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.transform.gameObject);
                OnGround = true;
                AirJump = true;
                return;
            }
        }
        OnGround = false;
    }
}
