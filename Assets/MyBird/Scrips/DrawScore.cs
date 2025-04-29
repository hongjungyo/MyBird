using UnityEngine;
using TMPro;
namespace MyBird
{

    public class DrawScore : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI scoreText;
        #endregion
        private void Update()
        {
            scoreText.text = GameManager.Score.ToString();
        }
    }
}