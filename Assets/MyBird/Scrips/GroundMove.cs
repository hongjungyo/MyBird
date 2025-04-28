using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
namespace MyBird
{
    //��� ��ũ��

    public class GroundMove : MonoBehaviour
    {
        #region Variables

        //��ũ�� �̵��ӵ�
        [SerializeField] private float moveSpeed = 5f;
        #endregion

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        //����� �������� �̵� ��Ų��
        //����� x��ǥ�� -8.4 ���� ���ų� ������ x ��ǥ�� ���ڸ��� ���´�.
        void Move()
        {
            if (GameManager.IsStart == false)
                return;
            //�������� moveSpeed ��ŭ �̵�
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(0f, transform.position.y, 10f);
            }
        }

    }
            
}