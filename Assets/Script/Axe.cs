using UnityEngine;

namespace Script
{
    public class Axe : WeaponSystem
    {
        public override void Attack(Collider target)
        {
            print(1);
            base.Attack(target);
            Debug.Log("Chặt bằng rìu!");
            
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"🔄 Va chạm với: {other.gameObject.name}"); 
            Attack(other); 
        }

    }
}