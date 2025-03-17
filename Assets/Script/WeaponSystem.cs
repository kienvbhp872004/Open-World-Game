using UnityEngine;

namespace Script
{
    public abstract class WeaponSystem : MonoBehaviour
    {
        public string NameWeapon;
        public int Damage;
        public int Range;
        public int Speed;
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
    }
}