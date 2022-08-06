using UnityEngine;
namespace UIFramework
{
    public class GameOver : BasePanel
    {
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }
    }
}
