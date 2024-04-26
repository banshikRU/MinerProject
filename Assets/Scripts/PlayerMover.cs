using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField]private List<AudioClip> sfx;
    [SerializeField] private LayerMask _floorLayer;
    private Collider2D[] collider2Ds;
    [SerializeField] private int _destroyBlocks;
    [SerializeField] private int _timeInFly;
    [SerializeField]private LayerMask _blockingLayer;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _smoothFallTime;
    public float _inverseMoveTime;
    private float _inverseSmoothFall;
    public bool _isMoving;
    public bool _isFly;
    private bool _isDestroyMod;
    private BoxCollider2D _myBoxCollider;
    private Rigidbody2D _myRigidBody;
    private void Start()
    {
        _isDestroyMod = false;
        _isFly = false;
        _myBoxCollider = GetComponent<BoxCollider2D>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _inverseMoveTime = 1f / _moveTime;
        _inverseSmoothFall = 1f/_smoothFallTime;
    }
    private void Update()
    {
        if (_isDestroyMod)
        {
            OnBlockEnter(); 
        }
    }
    private void OnBlockEnter()
    {
        collider2Ds =  Physics2D.OverlapBoxAll(transform.position, new Vector2(0.7f, 0.7f), 0f,_floorLayer);
        foreach (var colliders in collider2Ds)
        {
            colliders.gameObject.GetComponent<IAmBlock>().DestroyAll();
        }

    }
    private IEnumerator SmoothMovement(Vector3 end)
    {
        _isMoving = true;
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(_myRigidBody.position, end, _inverseMoveTime * Time.fixedDeltaTime);
            _myRigidBody.MovePosition(newPostion);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        _myRigidBody.MovePosition(end);
        if (_isFly == true)
        {
            AttemptFall(_inverseSmoothFall);
        }
        _isMoving = false;
    }
    public void AttemptFall(float _fallTime)
    {
        float _dB;
        _isMoving = true;
        _myBoxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        _myBoxCollider.enabled = true;
        if (hit.collider != null)
        {
            if (_fallTime == _inverseMoveTime)
            {
                _isDestroyMod = true;
                _dB = _destroyBlocks;
            }
            else
            {
                _dB = 0;
            }
            StartCoroutine(Fall(_fallTime, new Vector3(transform.position.x,(hit.collider.gameObject.transform.position.y+1f)-_dB,0)));
        }
    }
    private IEnumerator Fall(float _fallTime, Vector3 end)
    {
        yield return new WaitForSeconds(0.2f);
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPostion = Vector3.MoveTowards(_myRigidBody.position, end, _fallTime * Time.fixedDeltaTime);
            _myRigidBody.MovePosition(newPostion);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
        _myRigidBody.MovePosition(end);
        _isFly = false;
        _isMoving = false;
        _isDestroyMod = false;
    }
    private bool Move(float xDir, float yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        _myBoxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, _blockingLayer);
        _myBoxCollider.enabled = true;
        if (hit.transform == null)
        {
            if (yDir > 0)
            {
                _isFly = true;
            }
            StartCoroutine(SmoothMovement(end));
            return true;
        }
        return false;
    }
    public void AttemptMove<T>(float xDir, float yDir) where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
            return;
        if (hit.transform.gameObject.TryGetComponent<IAmBlock>(out IAmBlock wall))
        {
            HitBlock(xDir, yDir,hit,wall);
        }
    }
    private void HitBlock(float xDir, float yDir, RaycastHit2D hit, IAmBlock wall)
    {
        SoundManager.instance.RandomizeSfx(sfx);
        wall.HitMe(1, out bool isFloorDestroyed);
       // _gameManager.CurentPickaxeEndurance--;
        DamagePopup.Create(gameObject.transform.position + new Vector3(0, 0.5f), 1, false);
        if (isFloorDestroyed)
        {
            Move(xDir, yDir, out hit);
        }
    }
}
