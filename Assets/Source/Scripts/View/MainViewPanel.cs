using UnityEngine;
using UnityEngine.UIElements;

namespace Source.Scripts.View
{
    public class MainViewPanel : MonoBehaviour
    {
        [SerializeField] private UIDocument  _document;
        
        private VisualElement  _root;
        private Button _nuclearMissileButton;
        
        private void Awake()
        {
                _root = _document.rootVisualElement;
                _nuclearMissileButton =  _root.Q<Button>("NuclearMissileButton");
                DisableNuclearMissileButton();
        }
        
        public void EnableNuclearMissileButton()
        {
            _nuclearMissileButton.style.display = DisplayStyle.Flex;
        }

        public void DisableNuclearMissileButton()
        {
            _nuclearMissileButton.style.display = DisplayStyle.None;
        }
    }
}