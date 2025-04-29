using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;

        //애니메이션
        public Animator animator;

        //점프
        private bool KeyJump = false;    //점프 키 인풋 체크
        [SerializeField]
        private float jumpForce = 5f;    //위 방향으로 주는 힘

        //회전
        private Vector3 birdRocation;
        //올라갈때 회전속도
        [SerializeField] private float upRocate = 5f;
        //내려갈때 회전속도
        [SerializeField] private float downRocate = -5f;

        //이동
        //이동속도 - translate 시작하면 자동으로 오른쪽으로 이동
        [SerializeField] private float moveSpeed = 5f;

        //대기
        [SerializeField]

        private float readyForce = 1f;

        //UI
        public GameObject readyUI;
        public GameObject resultUI;
        #endregion

        #region
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            //인풋 처리
            InputBird();

            if (GameManager.IsStart == false)
            {
                //버드 대기
                readyBird();
                return;
            }

            //버드 회전
            RocationBird();

            //버드 이동
            MoveBird();

        }
        private void FixedUpdate()
        {
            if (GameManager.IsDeath == true)
                return;
            //점프하기
            if (KeyJump)
            {
                Debug.Log("점프");
                JumpBird();

                KeyJump = false;

            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Collision: 부딛힌 콜라이더의 정보를 가지고 있다.
            if(collision.gameObject.tag == "Ground")
            {
                
                DieBird();
            }
            else if (collision.gameObject.tag == "Pipe")
            {
                
                DieBird();
            }

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Point")
            {
                GameManager.Score++;
                Debug.Log("점수 획득");
            }
        }

        #endregion


        //인풋 처리
        void InputBird()
        {
            KeyJump |= Input.GetKeyDown(KeyCode.Space);
            KeyJump |= Input.GetMouseButtonDown(0);

            //게임 start 전이고 점프키가 눌리면
            if(GameManager.IsStart == false && KeyJump == true)
            {
                StartMove();
            }
        }

        //버드 점프
        void JumpBird()
        {
            //아래쪽에서 위로 힘을 준다
            //rb2D.AddForce(Vector2.up *jumpForce(힘));
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        //버드 회전

        void RocationBird()
        {
            //올라갈때 최대 +30도 까지 회전 : rocatespeed = upRocate
            //내려갈때 최소 - 90도까지 회전 : rocatespeed = downRocate
            float rotateSpeed = 0f;

            if (rb2D.linearVelocity.y > 0f)
            {
                rotateSpeed = upRocate;
            }
            else if (rb2D.linearVelocity.y < 0f)
            {
                rotateSpeed = downRocate;
            }
            birdRocation = new Vector3(0f, 0f, Mathf.Clamp((birdRocation.z + rotateSpeed), -90f, 30f));
            this.transform.eulerAngles = birdRocation;
        }

        //버드 대기
        void readyBird()
         {
            //아래쪽에서 떨어지지 않도록 위쪽으로 힘을 준다.
            if (rb2D.linearVelocity.y < 0)
            rb2D.linearVelocity = Vector2.up * readyForce;
         }


        //버드 이동

        void MoveBird()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed, Space.World);

        }

        //버드 죽음
        void DieBird()
        {
            //두번죽음 체크
            if (GameManager.IsDeath)
                return;
            GameManager.IsDeath = true;
            animator.enabled = false;
            rb2D.linearVelocity = Vector2.zero;

            //UI
            resultUI.SetActive(true);
        }

        //버드 이동 시작
        void StartMove()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }
    }
}