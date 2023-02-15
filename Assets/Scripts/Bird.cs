using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _lunchForce = 500;
    
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2d;

    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Awake(){
    _rigidbody2d = GetComponent<Rigidbody2D>();
    _spriteRenderer = GetComponent<SpriteRenderer>();

    } 

    void Start()
    {

        _startPosition = GetComponent<Rigidbody2D>().position;
        _rigidbody2d.isKinematic = true;
        
    }


    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

    void OnMouseUp()
    {
        var currentPosition = _rigidbody2d.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
        _rigidbody2d.isKinematic = false;

        _rigidbody2d.AddForce(direction *_lunchForce );  
        _spriteRenderer.color = Color.white;

    } 

    void OnMouseDrag()
    {
        Vector3 mousePosition  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
        
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2d.position = _startPosition;
        _rigidbody2d.isKinematic = true;
        _rigidbody2d.velocity = Vector2.zero;


    }


}
