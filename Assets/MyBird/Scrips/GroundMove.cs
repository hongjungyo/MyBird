using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
namespace MyBird
{
    //배경 스크롤

    public class GroundMove : MonoBehaviour
    {
        #region Variables

        //스크롤 이동속도
        [SerializeField] private float moveSpeed = 5f;
        #endregion

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        //배경을 왼쪽으로 이동 시킨다
        //배경의 x좌표가 -8.4 보다 같거나 작으면 x 좌표를 제자리로 놓는다.
        void Move()
        {
            if (GameManager.IsStart == false)
                return;
            //왼쪽으로 moveSpeed 만큼 이동
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);

            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(0f, transform.position.y, 10f);
            }
        }

    }
            
}