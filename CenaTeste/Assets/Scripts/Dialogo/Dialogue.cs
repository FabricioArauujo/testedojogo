using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechText;
    public string actorName;
    private bool estaAberto;

    public LayerMask playerLayer;
    public float radius;

    private DialogueControl dc;
    bool onRadious;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadious && !estaAberto)
        {
            dc.Speech(profile, speechText, actorName);
            estaAberto = true;
        }
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
