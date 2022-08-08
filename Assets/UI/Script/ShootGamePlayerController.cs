using UnityEngine;
using System.Collections.Generic;
using UIFramework;
using UnityEngine.UI;

    public class ShootGamePlayerController : MonoBehaviour
    {
        public RectTransform playerDotPosition;
        public DartsMove playerDart;
        public Text playerScoreText;
        public List<AudioClip> clips;
        public Transform cam;

        public float time;
        public bool isShoot;
        public RectTransform DotPosition;
        public DartsMove Dart;
        public Text scoreText;
        private void Start()
        {
            GameObject.Find("Main Camera").TryGetComponent<Transform>(out cam);
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time < 0&&!isShoot)
            {
                isShoot = true;
                shoot(Dart, scoreText, DotPosition);
            }
            if (Input.GetKeyDown(KeyCode.Space)&&isShoot)
            {
                shoot(playerDart, playerScoreText, playerDotPosition);
                Debug.Log("玩家是否获胜" + CompareScore());
            }
        }
        void shoot(DartsMove Dart, Text scoreText, RectTransform DotPosition)
        {
            AudioSource.PlayClipAtPoint(clips[0], cam.position);
            AudioSource.PlayClipAtPoint(clips[1], cam.position);
            // 开始执行射线检测
            RaycastHit2D[] hits = Physics2D.RaycastAll(playerDotPosition.anchoredPosition, Vector2.zero);
            Ray ray = new Ray(Camera.main.transform.position,
                DotPosition.position - Camera.main.transform.position);
            RaycastHit2D[] hit2s = Physics2D.GetRayIntersectionAll(ray);
            Debug.Log(hit2s.Length);
            Dart.speed = 0;
            switch (hit2s.Length)
            {
                case 2:
                    Debug.Log("1 point");
                    scoreText.text = "1".ToString();
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
        }
        public bool CompareScore()
        {
            int score = 0;
            int playerScore = 0;
            int.TryParse(playerScoreText.text, out playerScore);
            int.TryParse(scoreText.text, out score);
            if (score > playerScore)
            {
                return false;
            }else
            {
                return true;
            }
        }
    }
