using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyBird
{
    //게임 결과 보여주기: 베스트 스코어, 스코어 보여주고 다시하기, 메뉴가기 버튼 기능 구현
    public class ResultUI : MonoBehaviour
    {
        #region Variable
        //Info UI
        public SceneFader fader;
        public TextMeshProUGUI bestScore;
        public TextMeshProUGUI score;
        public TextMeshProUGUI newText;
        [SerializeField] private string SceneToload = "Title";

        #endregion

        private void OnEnable()
        {
            //GameManager.BestScore와 GameManager.Score비교
            if(GameManager.BestScore< GameManager.Score)
            {
                //최고점수 갱신
                GameManager.BestScore = GameManager.Score;
                //파일 저장
                PlayerPrefs.SetInt("BestScore", GameManager.Score);
                newText.text = "New";
            }
            else
            {
                newText.text = "";
            }

            bestScore.text = GameManager.BestScore.ToString();
            score.text = GameManager.Score.ToString();
        }

        //다시하기


        public void Retry()
        {
            //현재 씬 다시 불러오기

            fader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            fader.FadeTo(SceneToload);

        }

    }
}