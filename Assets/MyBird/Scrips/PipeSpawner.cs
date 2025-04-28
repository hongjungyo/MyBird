using UnityEngine;
namespace MyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        #region Variables
        //��� ������
        public GameObject pipePrefab;

        //1�� Ÿ�̸�
        [SerializeField] private float pipeTimer = 1f;
        private float countdown = 0f;

        //���� ��ġ
        [SerializeField] private float maxSpwanY = 4.1f;
        [SerializeField] private float minSpwanY = -2.1f;

        //���� ����
        [SerializeField] private float maxSpwanTime = 1.05f;
        [SerializeField] private float minSpwanTime = 0.95f;

        #endregion

        //1�ʸ��� ��� �ϳ��� ����, ���� ���۽� (IsStart == true)

        private void Update()
        {
            if (GameManager.IsStart == false)
                return;
            countdown += Time.deltaTime;
            if(countdown >= pipeTimer)
            {
                SpawnPipe();

                countdown = 0f;

                pipeTimer = Random.Range(minSpwanTime, maxSpwanTime);
            }
        }

        //��� ����
        void SpawnPipe()
        {
            float spawnY = this.transform.position.y + Random.Range(minSpwanY, maxSpwanY);
            Vector3 spawnPoistion = new Vector3(transform.position.x, spawnY, transform.position.z);
            Instantiate(pipePrefab, spawnPoistion, Quaternion.identity);
        }
    }
}