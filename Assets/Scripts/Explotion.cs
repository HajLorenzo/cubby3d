using UnityEngine;
public class Explotion : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float ImpactForce, ImpactRadius;

    private void Awake()
    {
        _transform = transform;
    }
    private void OnEnable()
    {
        Collider[] objects = Physics.OverlapSphere(_transform.position, 5);
        foreach (Collider h in objects)
        {
            Rigidbody r = h.GetComponent<Rigidbody>();
            if (r != null)
                r.AddExplosionForce(ImpactForce, _transform.position, ImpactRadius);
        }
    }
}
