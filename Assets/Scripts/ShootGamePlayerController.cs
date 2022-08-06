using UnityEngine;
using UIFramework;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class ShootGamePlayerController : MonoBehaviour
    {
        public RectTransform DotPosition;
        public DartsMove Dart;
        public Text scoreText;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 开始执行射线检测
                RaycastHit2D[] hits = Physics2D.RaycastAll(DotPosition.anchoredPosition, Vector2.zero);
                Ray ray = new Ray(Camera.main.transform.position,
                    DotPosition.position - Camera.main.transform.position);
                RaycastHit2D[] hit2s = Physics2D.GetRayIntersectionAll(ray);
                Debug.Log(hit2s.Length);
                Dart.speed = 0;
                switch (hit2s.Length)
                {
                    case 2:
                        Debug.Log("1 point");
                        scoreText.text="1".ToString();
                        break;
                    case 3:
                        Debug.Log("2 point");
                        scoreText.text = "2".ToString();
                        break;
                    case 4:
                        Debug.Log("3 point");
                        scoreText.text = "3".ToString();
                        break;
                    case 5:
                        Debug.Log("4 point");
                        scoreText.text = "4".ToString();
                        break;
                    case 6:
                        Debug.Log("5 point");
                        scoreText.text = "5".ToString();
                        break;
                    case 7:
                        Debug.Log("6 point");
                        scoreText.text = "6".ToString();
                        break;
                    case 8:
                        Debug.Log("7 point");
                        scoreText.text = "7".ToString();
                        break;
                    case 9:
                        Debug.Log("8 point");
                        scoreText.text = "8".ToString();
                        break;
                    case 10:
                        Debug.Log("9 point");
                        scoreText.text = "9".ToString();
                        break;
                    case 11:
                        Debug.Log("10 point");
                        scoreText.text = "10".ToString();
                        break;
                    default:
                        break;
                }
                UIManager.Instance.PopPanel();
            }
        }
    }
}