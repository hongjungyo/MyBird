using UnityEngine;
namespace MyBird
{
    // ī�޶� ���� - �÷��̾� �̵��� ���� ���� �̵��Ѵ�.
    public class CarmeraController : MonoBehaviour
    {
        #region Variables
        //�÷��̾� ������Ʈ
        public Transform Player;

        //ī�޶� ��ġ offset
        [SerializeField] private float offsetx = 1.5f;
        #endregion
        private void Start()
        {
            FollowPlayer();
        }

        private void Update()
        {
            FollowPlayer();
        }

        //ī�޶��� ��ġ�� �÷��̾��� ��ġ���� z�������� -10��ŭ ��ġ�ϰ� �����.
        void FollowPlayer()
        {
            this.transform.position = new Vector3(Player.position.x + offsetx, transform.position.y, transform.position.z);
        }
      
    }
}