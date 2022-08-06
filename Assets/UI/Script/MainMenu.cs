using UnityEngine;
using UnityEngine.SceneManagement;
namespace UIFramework
{
    public class MainMenu : BasePanel
    {


        public override void OnEnter()
        {
            base.OnEnter();
            Cursor.lockState = CursorLockMode.None;
        }

        public void OnClickNewStartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //要pop所有的Panel
            UIManager.Instance.PopAllPanel();
            //初始化字典
            UIManager.Instance.InitializePanelDict();

            //UIManager.Instance.PushPanel(UIPanelType.SystemSettingPanel);
        }

        public void OnClickContinueButton()
        {
            UIManager.Instance.PushPanel(UIPanelType.Load);
            //UIManager.Instance.PushPanel(UIPanelType.StorePanel);
        }

        public void OnClickSettingButton()
        {
            UIManager.Instance.PushPanel(UIPanelType.Setting);
            //UIManager.Instance.PushPanel(UIPanelType.PausePanel);
        }
        public void OnClickQuiteButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
            //UIManager.Instance.PushPanel(UIPanelType.PausePanel);
        }
    }
}