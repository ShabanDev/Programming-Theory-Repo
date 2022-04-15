using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class MainMenuManager : MonoBehaviour
    {
        public UIDocument mainMenuDocument;

        private void Start() {
            Button startButton = mainMenuDocument.rootVisualElement.Q<Button>();
            Debug.Log(startButton.text);
            startButton.clicked += OnStartClick;
        }

        private void OnStartClick(){
            SceneManager.LoadScene(1);
        }
    }
}
