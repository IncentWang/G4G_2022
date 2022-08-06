using UnityEngine;

namespace UIFramework
{
    public class Shooter: BasePanel
    {
        
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }
    }
}
