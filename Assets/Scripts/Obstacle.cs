using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D myCollider2D;
    private List<Collider2D> playerCollider2;
    public ContactFilter2D contactFilter;
    private float t;
    private void Start()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
        playerCollider2 = new List<Collider2D> ();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        t  += Time.fixedDeltaTime *0.05f ;
        spriteRenderer.color =new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(spriteRenderer.color.a,255, t));
        if (spriteRenderer.color.a ==255 )
        {
            CheckForPlayer();
        }
    }
    private void CheckForPlayer()
    {
        Physics2D.OverlapCollider(myCollider2D, contactFilter.NoFilter(), playerCollider2);
        if (playerCollider2.Count != 0)
        {
            foreach (var obj in playerCollider2)
            {
                if (obj.gameObject.name == "Player")
                {
                    Destroy(obj.gameObject);
                    Destroy(gameObject);
                }
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
