using UnityEngine;

namespace Script
{
    public class RabbitController:MonoBehaviour
    {
        public float speed = 3.0f;
        private const float balance = 0.02f;
        bool isIdle;
        bool isRunning;
        public float timeRun;
        public float timeIdle;
        float timeRemainRun;
        float timeRemainIdle;
        Animator animator;
        public int moveDirection;
        void Start()
        {
            timeIdle = Random.Range(4,7);
            timeRun = Random.Range(4,7);
            timeRemainRun = timeRun;
            timeRemainIdle = 0;
            animator = GetComponent<Animator>();
            animator.SetBool("isRunning", true);
            moveDirection = Random.Range(0,3);
        }

        void FixedUpdate()
        {
            if (timeRemainRun > 0)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
                timeRemainRun -= Time.deltaTime;
                switch (moveDirection)
                {
                    case  0:
                        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                        transform.position += transform.forward * (speed * balance);
                        break;
                    case  1:
                        transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                        transform.position += transform.forward * (speed * balance) ;
                        break;
                    case  2:
                        transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                        transform.position += transform.forward * (speed * balance) ;
                        break;
                    case  3:
                        transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                        transform.position += transform.forward * (speed * balance) ;
                        break;
                        
                }
            }
            else if (timeRemainIdle > 0)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
                timeRemainIdle -= Time.deltaTime;
            }
            else
            {
                timeRemainIdle = timeIdle;
                timeRemainRun = timeRun;
                moveDirection = Random.Range(0,3);
            }

        }
    }
}