using UnityEngine;
using UnityEngine.UI;
namespace UIFramework
{
    public class Shooter: BasePanel
    {
       
        public Text score;
        
        public void OnClickReturnButton()
        {
            UIManager.Instance.PopPanel();
        }
    }
}
