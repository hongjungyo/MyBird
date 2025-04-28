using UnityEngine;
namespace MyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        #region Variables
        //기둥 프리팹
        public GameObject pipePrefab;

        //1초 타이머
        [SerializeField] private float pipeTimer = 1f;
        private float countdown = 0f;

        //스폰 위치
        [SerializeField] private float maxSpwanY = 4.1f;
        [SerializeField] private float minSpwanY = -2.1f;

        //스폰 간견
        [SerializeField] private float maxSpwanTime = 1.05f;
        [SerializeField] private float minSpwanTime = 0.95f;

        #endregion

        //1초마다 기둥 하나씩 생성, 게임 시작시 (IsStart == true)

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

        //기둥 생성
        void SpawnPipe()
        {
            float spawnY = this.transform.position.y + Random.Range(minSpwanY, maxSpwanY);
            Vector3 spawnPoistion = new Vector3(transform.position.x, spawnY, transform.position.z);
            Instantiate(pipePrefab, spawnPoistion, Quaternion.identity);
        }
    }
}