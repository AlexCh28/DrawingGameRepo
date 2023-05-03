using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    [SerializeField]
    private float _speed;

    private Transform _target;

    private void FixedUpdate() {

        if (_target == null) {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, _radius,Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Player")){
                _target = hit.transform;
            }
        }

        if (_target == null) return;

        transform.position = Vector2.Lerp(transform.position, _target.position, _speed*Time.fixedDeltaTime);
    }
}
