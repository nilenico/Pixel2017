using System.Collections;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour {
    protected int pid = 0;
    public float speed = 10;
    private Vector3 velocity;
    bool gameStarted = false;

    private const float raycastLength = 0.03f;
    private const float raycastDistance = 1.8f;

    //panic mode (close to dying)
    private const float panicRaycastLenght = 3.0f;
    private const float panicRaycastDistance = 1.8f;

    protected delegate void Panic();
    protected event Panic OnPanic;

    protected delegate void Die();
    protected event Die OnDie;


    public delegate void RemovePlayer();
    public static event RemovePlayer OnRemovePlayer;
    
    

    public void setPid(int pid) {
        this.pid = pid;
    }

    IEnumerator waitForStart()
    {
        yield return new WaitForSeconds(5.0f);
        gameStarted = true;
    }

    void FixedUpdate() {
        if(!gameStarted)
            StartCoroutine(waitForStart());

        if (InputManager.Devices.Count >= 0 && gameStarted)
        {
            Vector3 offset = transform.position + transform.up * raycastDistance;
            RaycastHit2D upHit = Physics2D.Raycast(offset, transform.up, raycastLength);
            //Debug.DrawRay(offset, transform.up);
            offset = transform.position - transform.right * raycastDistance;
            RaycastHit2D leftHit = Physics2D.Raycast(offset, -transform.right, raycastLength);

            onPanic();

            if (leftHit.collider != null && (leftHit.transform.tag == "Wall" || leftHit.transform.tag == "Border"))
            {
                offset = transform.position + transform.right * raycastDistance;
                RaycastHit2D rightHit = Physics2D.Raycast(offset, transform.right, raycastLength);
                //Debug.DrawRay(offset, transform.right);
                if (rightHit.collider != null && (rightHit.transform.tag == "Wall" || rightHit.transform.tag == "Border"))
                {
                    if (OnDie != null)
                        OnDie();
                    if (OnRemovePlayer != null)
                        OnRemovePlayer();
                }
            }

            if (upHit.collider != null && (upHit.transform.tag == "Wall" || upHit.transform.tag == "Border"))   
            {
                offset = transform.position - transform.up ;
                RaycastHit2D downHit = Physics2D.Raycast(offset, -transform.up, raycastLength);
                //Debug.DrawRay(offset, -transform.up);
                if (downHit.collider != null && (downHit.transform.tag == "Wall" || downHit.transform.tag == "Border")) {
                    if (OnDie != null)
                        OnDie();
                    if (OnRemovePlayer != null)
                        OnRemovePlayer();

                }
            }
            velocity = Vector3.zero;
            velocity.x += InputManager.Devices[pid].LeftStickX.Value * speed;
            velocity.y += InputManager.Devices[pid].LeftStickY.Value * speed;
            transform.position += velocity * speed * Time.deltaTime;
        }
    }

    void onPanic()
    {
        Vector3 horizontalOffset = transform.position - Vector3.right * panicRaycastDistance;
        RaycastHit2D leftHit = Physics2D.Raycast(horizontalOffset, -Vector2.right, panicRaycastLenght);

        if (leftHit.collider != null && (leftHit.transform.tag == "Wall" || leftHit.transform.tag == "Border"))
        {

            horizontalOffset = transform.position + Vector3.right * panicRaycastDistance;
            RaycastHit2D rightHit = Physics2D.Raycast(horizontalOffset, Vector2.right, panicRaycastLenght);

            if (rightHit.collider != null && (rightHit.transform.tag == "Wall" || rightHit.transform.tag == "Border"))
            {
                //Debug.DrawRay(horizontalOffset, transform.right * panicRaycastLenght, Color.green);

                if (OnPanic != null)
                    OnPanic();
            }
        }

        Vector3 verticalOffset = transform.position + Vector3.up * panicRaycastDistance;
        RaycastHit2D upHit = Physics2D.Raycast(verticalOffset, Vector2.up, panicRaycastLenght);

        if (upHit.collider != null && (upHit.transform.tag == "Wall" || upHit.transform.tag == "Border"))
        {
            //Debug.DrawRay(verticalOffset, transform.up * panicRaycastLenght, Color.green);

            verticalOffset = transform.position - Vector3.up;
            RaycastHit2D downHit = Physics2D.Raycast(verticalOffset, -Vector2.up, panicRaycastLenght);

            if (downHit.collider != null && (downHit.transform.tag == "Wall" || downHit.transform.tag == "Border"))
            {
                //Debug.DrawRay(verticalOffset, -transform.up * panicRaycastLenght, Color.green);

                if (OnPanic != null)
                    OnPanic();
            }
        }
    }
}
