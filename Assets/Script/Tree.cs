using UnityEngine;

namespace Script
{
    public class Tree: MonoBehaviour, IChoppable 
    {
        public float chopsRequired = 10;

        public void Chop(float chopPower)
        {
            Debug.Log($"Cây bị chặt! Sức chặt: {chopPower}, Máu cây còn: {chopsRequired}");
            chopsRequired -= chopPower;
            if (chopsRequired <= 0)
            {
                Fall();
            }
        }

        private void Fall()
        {
            Debug.Log("Cây đã bị đốn ngã!");
            Destroy(gameObject);
        }
    }
}