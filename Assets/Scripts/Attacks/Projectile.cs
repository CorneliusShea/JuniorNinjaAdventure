using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    public float Damage { get; set; }

    public Vector3 Direction { get; set; }

    public void Update()
    {
        transform.Translate(Direction * (projectileSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IDamagable>()?.TakeDamage(Damage);
        Destroy(this.gameObject);
    }



}
