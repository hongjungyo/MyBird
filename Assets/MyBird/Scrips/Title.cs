using TMPro;
using UnityEngine;
namespace MyBird
{
    public class Title : MonoBehaviour
    {
        #region Variable
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        //치트키
        private bool ischeat = false;
        #endregion

        private void Update()
        {
            //치트키
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetSaveData();
            }
        }

        public void Play()
        {
            fader.FadeTo(loadToScene);
        }
        //치트키
        private void ResetSaveData()
        {
            if (ischeat == false)
                return;

            PlayerPrefs.DeleteAll();
        }
    }
}