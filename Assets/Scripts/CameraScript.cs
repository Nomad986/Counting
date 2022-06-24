using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Rigidbody cameraRB;

    [SerializeField] private float dragSpeed = 1;
    private float yaw = 0;
    private float pitch = 0;

    [SerializeField] private float hoverSpeed = 7;
    private float movementIntoDepth = 0;
    private float movementHorizontal = 0;

    [SerializeField] float ballForceMultiplier = 10;

    private void Start()
    {
        cameraRB = GetComponent<Rigidbody>();
        yaw = -41f;
        pitch = -4f;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            yaw -= dragSpeed * Input.GetAxisRaw("Mouse X");
            pitch += dragSpeed * Input.GetAxisRaw("Mouse Y");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        movementIntoDepth = Input.GetAxisRaw("Vertical") * hoverSpeed;
        movementHorizontal = Input.GetAxisRaw("Horizontal") * hoverSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mouseHit;
            int ballLayerMask = 1 << 6;

            if (Physics.Raycast(mouseRay, out mouseHit, Mathf.Infinity, ballLayerMask))
            {
                GameObject ballToMove = mouseHit.transform.gameObject;
                Vector3 hitPoint = mouseHit.point;

                MoveBall(ballToMove, hitPoint);
                Debug.Log("Hit!");
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 movementsForVelocity = new Vector3(movementHorizontal, 0, movementIntoDepth);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        cameraRB.velocity = transform.TransformDirection(movementsForVelocity);
    }

    private void MoveBall(GameObject ball, Vector3 hitPoint)
    {
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        Vector3 moveDir = ball.transform.position - hitPoint;
        moveDir.y = 0f;

        ballRB.AddForce(moveDir * ballForceMultiplier, ForceMode.Impulse);
    }
}
