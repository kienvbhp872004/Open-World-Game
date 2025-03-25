using UnityEngine;

namespace Script
{
    public class WeaponSystem : MonoBehaviour
    {
        public float damage = 10f;
        public float chopPower = 1f; // Sức chặt cây
        public LayerMask hitLayers;
        private Animator _animator;

        void Start()
        {
            _animator =  GetComponent<Animator>();
        }

        void Update()
        {
            AnimationHit();
        }

        void AnimationHit()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("Hit");
            }
        }
        public virtual void Attack(Collider target)
        {
            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
            else if (target.TryGetComponent(out IChoppable choppable))
            {
                print(222);
                choppable.Chop(chopPower);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            Attack(other); 
        }
    }
}