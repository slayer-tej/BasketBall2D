using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool doneSwiping = false;
    private float touchStartedTime, touchEndedTime, totalTime;
    private Vector2 final;
    private Vector2 startpos;
    private Vector2 endpos;
    private Rigidbody2D rb;
    private float throwForce = 0.35f;
    public bool isBallThrown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            final = Vector2.zero;
            doneSwiping = false;
            touchStartedTime = Time.time;
            startpos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            doneSwiping = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Canceled)
        {
            doneSwiping = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            doneSwiping = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (doneSwiping)
            {
                ThrowBall();
                rb.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private void ThrowBall()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        touchEndedTime = Time.time;
        totalTime = touchEndedTime - touchStartedTime;
        endpos = Input.GetTouch(0).position;
        final = endpos - startpos;
        rb.AddForce( final/totalTime * throwForce);
        isBallThrown = true;
    }
}
