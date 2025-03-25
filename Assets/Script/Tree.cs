using UnityEngine;

namespace Script
{
    public class Tree: MonoBehaviour,IChoppable 
    {
        public float chopsRequired = 10;
        public void Chop(float chopPower)
        {
            Debug.Log(chopsRequired);
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
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"🔄 Va chạm với: {other.gameObject.name}"); // Kiểm tra xem có nhận diện đối tượng khôn  
        }

    }
}