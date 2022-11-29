
using UnityEngine;

namespace Assets.Scripts.Util
{
	public class HotKeys : MonoBehaviour
    {
		public static readonly KeyCode ActivateKey = KeyCode.KeypadEnter;
        public static readonly KeyCode NextKey = KeyCode.KeypadPlus;
        public static readonly KeyCode PreviousKey = KeyCode.KeypadMinus;
        public static readonly KeyCode HideLaserKey = KeyCode.L;
        public static readonly KeyCode DisplayMarkerKey = KeyCode.M;
        public static readonly KeyCode DisplayTrajectoryKey = KeyCode.T;
        public static readonly KeyCode ToggleFullScreenKey = KeyCode.F;
		
        [SerializeField] private bool EscapeQuitsApplication;
        private void Update()
        {
            if (!EscapeQuitsApplication) return;
            if (!Input.GetKeyUp(KeyCode.Escape)) return;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
