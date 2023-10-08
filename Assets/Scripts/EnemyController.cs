using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Transform[] Points;
    private IEnumerator<Transform> _currentPoint;
    //[SerializeField] private SpriteRenderer spriteRender;
    public int speed;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //spriteRender = gameObject.GetComponent<SpriteRenderer>();
        InitPatrol();
    }
    private void Update()
    {
        UpdatePatrol();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Inside collision enemy");
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player)
        {
            player.KillPlayer();
            //Destroy(gameObject);
        }

    }

    
    public IEnumerator<Transform> GetPathEnumerator()
    {
        if (Points == null || Points.Length < 1)
        {
            yield break;
        }
        var direction = 1;
        var indx = 0;
        while (true)
        {
            yield return Points[indx];
            if (Points.Length == 1)
                continue;
            if (indx <= 0)
                direction = 1;
            else if (indx >= Points.Length - 1)
            {
                direction = -1;
            }
            indx += direction;
        }
    }
    public void InitPatrol()
    {
        if (Points == null)
        {
            Debug.LogError("Path cannot be null", gameObject);
            return;
        }
        _currentPoint = GetPathEnumerator();
        _currentPoint.MoveNext();
        if (_currentPoint == null)
        { return; }
        transform.position = _currentPoint.Current.position;
    }
    private void UpdatePatrol()
    {
        if (_currentPoint == null || _currentPoint.Current == null) { return; }
        
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        
        //Flip enemy
        Vector3 scale = transform.localScale;
        if (_currentPoint.Current.position.x < transform.position.x)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
        
        var distsqr = (transform.position - _currentPoint.Current.position).sqrMagnitude;
        if (distsqr < 0.1)
        {
            _currentPoint.MoveNext();
        }
    }
}
