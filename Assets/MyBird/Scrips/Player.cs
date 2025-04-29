using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
namespace MyBird
{
    public class Player : MonoBehaviour
    {
        #region Variables
        private Rigidbody2D rb2D;

        //�ִϸ��̼�
        public Animator animator;

        //����
        private bool KeyJump = false;    //���� Ű ��ǲ üũ
        [SerializeField]
        private float jumpForce = 5f;    //�� �������� �ִ� ��

        //ȸ��
        private Vector3 birdRocation;
        //�ö󰥶� ȸ���ӵ�
        [SerializeField] private float upRocate = 5f;
        //�������� ȸ���ӵ�
        [SerializeField] private float downRocate = -5f;

        //�̵�
        //�̵��ӵ� - translate �����ϸ� �ڵ����� ���������� �̵�
        [SerializeField] private float moveSpeed = 5f;

        //���
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
            //����
            rb2D = this.GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            //��ǲ ó��
            InputBird();

            if (GameManager.IsStart == false)
            {
                //���� ���
                readyBird();
                return;
            }

            //���� ȸ��
            RocationBird();

            //���� �̵�
            MoveBird();

        }
        private void FixedUpdate()
        {
            if (GameManager.IsDeath == true)
                return;
            //�����ϱ�
            if (KeyJump)
            {
                Debug.Log("����");
                JumpBird();

                KeyJump = false;

            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Collision: �ε��� �ݶ��̴��� ������ ������ �ִ�.
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
                Debug.Log("���� ȹ��");
            }
        }

        #endregion


        //��ǲ ó��
        void InputBird()
        {
            KeyJump |= Input.GetKeyDown(KeyCode.Space);
            KeyJump |= Input.GetMouseButtonDown(0);

            //���� start ���̰� ����Ű�� ������
            if(GameManager.IsStart == false && KeyJump == true)
            {
                StartMove();
            }
        }

        //���� ����
        void JumpBird()
        {
            //�Ʒ��ʿ��� ���� ���� �ش�
            //rb2D.AddForce(Vector2.up *jumpForce(��));
            rb2D.linearVelocity = Vector2.up * jumpForce;
        }

        //���� ȸ��

        void RocationBird()
        {
            //�ö󰥶� �ִ� +30�� ���� ȸ�� : rocatespeed = upRocate
            //�������� �ּ� - 90������ ȸ�� : rocatespeed = downRocate
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

        //���� ���
        void readyBird()
         {
            //�Ʒ��ʿ��� �������� �ʵ��� �������� ���� �ش�.
            if (rb2D.linearVelocity.y < 0)
            rb2D.linearVelocity = Vector2.up * readyForce;
         }


        //���� �̵�

        void MoveBird()
        {
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed, Space.World);

        }

        //���� ����
        void DieBird()
        {
            //�ι����� üũ
            if (GameManager.IsDeath)
                return;
            GameManager.IsDeath = true;
            animator.enabled = false;
            rb2D.linearVelocity = Vector2.zero;

            //UI
            resultUI.SetActive(true);
        }

        //���� �̵� ����
        void StartMove()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }
    }
}