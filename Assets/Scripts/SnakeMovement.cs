using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField]private GameObject targetPrefab;
    private Transform targetTransform;
    public float speed = 5f;
    private bool reachedTarget = false;
    private bool isFirstBlock;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        isFirstBlock = false;
        RotateToPlayer();
        targetTransform =  Instantiate(targetPrefab,player.transform.position ,Quaternion.identity).transform;
    }
    void Update()
    {

        if (targetTransform != null)
        {
            Vector3 direction = targetTransform.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.1f && !reachedTarget)
            {
                reachedTarget = true;
                targetTransform.position += direction * 10f; 
            }
            else if(Vector3.Distance(transform.position, targetTransform.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
       
    }
    private void RotateToPlayer()
    {
        Vector3 directionn = player.position - gameObject.transform.position;
        gameObject.transform.rotation= Quaternion.LookRotation(Vector3.forward, directionn);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" && isFirstBlock == false)
        {
            //CameraControl.instance.ShakeCamera(3, 3f);
            isFirstBlock = true;
            collision.GetComponent<Wall>().RevertSprite();
        }
    }

}
