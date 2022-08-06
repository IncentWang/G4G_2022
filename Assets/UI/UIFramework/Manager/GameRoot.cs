using UnityEngine;
namespace UIFramework
{
    public class GameRoot : MonoBehaviour
    {

        public Texture2D pointer;

        void Start()
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
            UIManager.Instance.PushPanel(UIPanelType.MainMenu);
        }
    }
}
