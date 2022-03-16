using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrls : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Interaction")]
    public float Idledistance;
    public float GreetingDistance;
    public float TalkDistance;
    
    GameObject player;
    Transform tr;
    Animator anim;
    float dist;
    Vector3 dir;
    enum State
    {
        Idle,
        Waving,
        Talk,
    }
    State state;
    void Start()
    {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        player = GameObject.Find("Player");

        state = State.Idle;
    }
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, tr.position);
        Debug.Log(dist);
        dir = player.transform.position - tr.position;
        dir.Normalize();
        switch(state)
        {
            case State.Idle:
                UpdateIdle();
                break;
            
            case State.Waving:
                UpdateWaving();
                break;

            case State.Talk:
                UpdateTalk();
                break;

            default:
                 break;
        }
    }
    void UpdateIdle()
    {
        if(dist < GreetingDistance)
        {
            anim.SetTrigger("Greet_0"+ Random.Range(1, 3));
            state = State.Waving;
        }
    }

    void UpdateWaving()
    {
        tr.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));

        if(dist < TalkDistance)
        {
            anim.SetTrigger("Talk_0"+ Random.Range(1, 4));
            state = State.Talk;

        }
        else if(dist > Idledistance)
        {
            anim.SetTrigger("Idle");
            state = State.Idle;
        }
    }
    void UpdateTalk()
    {  
        tr.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));

        if(dist > TalkDistance + 1f)
        {
            anim.SetTrigger("Greet_0"+ Random.Range(1, 3));
            state = State.Waving;
        }
    }
    void EndTalk()
    {
            anim.SetTrigger("Talk_0"+ Random.Range(1, 5));
    }

}
