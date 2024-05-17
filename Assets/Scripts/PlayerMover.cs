using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private AudioClip _pickaxeHit;
    [SerializeField] private ParticleSystem _playerParticleSystem;
   // [SerializeField] private Animator _playerAnimator;
    [SerializeField] private BuffManager _buffManager;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private LayerMask _blockingLayer;
    [SerializeField] private float _moveTime;
    [SerializeField] private float _smoothFallTime;
    private float _inverseSmoothFall;
    private int _pickaxeDamage;
    private bool _isCriticalHit;
    private BoxCollider2D _myBoxCollider;
    private Rigidbody2D _myRigidBody;
    [NonSerialized] public bool _isMoving;
    [NonSerialized] public bool _isFly;
    [NonSerialized] public float _inverseMoveTime;

    private void Start()
    {
        _isCriticalHit = false;
        _isFly = false;
        _myBoxCollider = GetComponent<BoxCollider2D>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _inverseMoveTime = 1f / _moveTime;
        _inverseSmoothFall = 1f/_smoothFallTime;
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
        _isMoving = true;
        _myBoxCollider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        _myBoxCollider.enabled = true;
        if (hit.collider != null)
        {

            StartCoroutine(Fall(_fallTime, new Vector3(transform.position.x, (hit.collider.gameObject.transform.position.y + 0.55f), 0)));
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
        //_playerAnimator.SetBool("IsJump", false);
        //_playerAnimator.SetBool("IsExtraJump", false);
        _isFly = false;
        _isMoving = false;
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
                //_playerAnimator.SetBool("IsJump", true);
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
        Move(xDir, yDir, out hit);
        if (hit.transform == null)
            return;
        if (hit.transform.gameObject.TryGetComponent<IAmBlock>(out IAmBlock wall))
        {
            HitBlock(xDir, yDir,hit,wall);
        }
    }
    private void HitBlock(float xDir, float yDir, RaycastHit2D hit, IAmBlock wall)
    {
        SoundManager.instance.PlaySingle(_pickaxeHit);
        //_playerAnimator.Play("PlayerMine");
        _playerParticleSystem.Play();
        int pickaxeDamageMax = Random.Range(2, 5);
        if (_buffManager.IsExtraDamageActive)
        {
            _isCriticalHit = true;
            pickaxeDamageMax *= 2;
        }
        else
        {
            _isCriticalHit = false;
        }
        _pickaxeDamage = Random.Range(1,pickaxeDamageMax);
        wall.HitMe(_pickaxeDamage, out bool isFloorDestroyed);
        DamagePopup.Create(gameObject.transform.position + new Vector3(0, 0.5f), _pickaxeDamage, _isCriticalHit);
        if (isFloorDestroyed)
        {
            if (wall.gameObject.TryGetComponent<ExplosionBlock>(out ExplosionBlock e))
            {
                BackGroundGenerator.instance.Invoke();
                AttemptFall(_inverseSmoothFall);
            }
            else
            {
                BackGroundGenerator.instance.Invoke();
                Move(xDir, yDir, out hit);
            }
        }
    }
}
