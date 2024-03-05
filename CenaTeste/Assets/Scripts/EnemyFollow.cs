using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float velocidade;
    public float stoppingDistance;
    private Transform alvo;


    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position, alvo.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
        }
    }
}
