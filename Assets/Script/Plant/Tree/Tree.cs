using UnityEngine;

namespace Script
{
    public class Tree: MonoBehaviour, IChoppable 
    {
        public float chopsRequired = 10;
        private const float WoodDropRate = 0.5f ;
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        public void Chop(float chopPower)
        {
            AddDropItem();
            Debug.Log($"Cây bị chặt! Sức chặt: {chopPower}, Máu cây còn: {chopsRequired}");
            chopsRequired -= chopPower;
            animator.SetTrigger("Chop");
            if (chopsRequired <= 0)
            {
                animator.SetTrigger("Fall"); 
            }
        }
        public void AddDropItem()
        {
            float valWood = Random.value;
            if (valWood < WoodDropRate)
            {
                InventorySystem.Instance.AddItem("Stick");
            }
        }
        private void Fall()
        {
            Debug.Log("Cây đã bị đốn ngã!");
            Destroy(gameObject);
        }
    }
}