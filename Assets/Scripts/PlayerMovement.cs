using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigidBody;
    private Vector3 change;
    private Animator anim;
    public PlayerState currentState;


    // Start is called before the first frame update
    void Start()    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        //anim.SetFloat("moveX", 0);
        //anim.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()  {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack) {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk) {
            UpdatAnimationAndMovement();
        }
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

    }

    private IEnumerator AttackCo() {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);
        currentState = PlayerState.walk;
    }

    void MoveCharacter() {
        change.Normalize();
        playerRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime);
    }

    void UpdatAnimationAndMovement() {
        if (change != Vector3.zero) {
            MoveCharacter();
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }

    }




}
