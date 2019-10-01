using UnityEngine;
using System.Collections;

namespace PixelCrushers.DialogueSystem.VisualNovelFramework
{

    /// <summary>
    /// Manages the current background image.
    /// </summary>
    public class BackgroundManager : MonoBehaviour
    {

        public UnityEngine.UI.Image background;
        public string backgroundVariable = "Background";
        public string backgroundFadeDurationVariable = "BackgroundFadeDuration";

        [Tooltip("Seconds to wait after fading to black before fading in again. If zero, no fade. If non-zero, will use Dialogue Manager's Scene Transition Manager to fade.")]
        public float fadeDuration = 0;

        private static BackgroundManager m_instance = null;

        private void Awake()
        {
            m_instance = this;
            if (background != null) background = GetComponentInChildren<UnityEngine.UI.Image>();
            Lua.RegisterFunction("BackgroundFadeDuration", this, SymbolExtensions.GetMethodInfo(() => BackgroundFadeDuration((double)0)));
        }

        private void OnDestroy()
        {
            m_instance = null;
        }

        private void Start()
        {
            UpdateBackgroundFromVariable();
        }

        private void OnApplyPersistentData()
        {
            UpdateBackgroundFromVariable();
        }

        public void BackgroundFadeDuration(double duration)
        {
            fadeDuration = (float)duration;
            DialogueLua.SetVariable(backgroundFadeDurationVariable, duration);
        }

        public static void UpdateBackgroundFromVariable()
        {
            if (m_instance == null) return;
            SetBackgroundImage(DialogueLua.GetVariable(m_instance.backgroundVariable).AsString);
            if (DialogueLua.DoesVariableExist(m_instance.backgroundFadeDurationVariable))
            {
                 m_instance.fadeDuration = DialogueLua.GetVariable(m_instance.backgroundFadeDurationVariable).asFloat;
            }
        }

        public static void SetBackgroundImage(string backgroundName)
        {
            if (string.IsNullOrEmpty(backgroundName) || string.Equals(backgroundName, "nil")) return;
            if (DialogueDebug.LogInfo) Debug.Log("Dialogue System: Setting background image to '" + backgroundName + "'.");
            DialogueLua.SetVariable(m_instance.backgroundVariable, backgroundName);
            var image = Resources.Load<Sprite>(backgroundName);
            if (image == null)
            {
                Debug.LogWarning("Dialogue System: Can't load background image '" + backgroundName + "' from a Resources folder. Is the name correct?");
            }
            else
            {
                m_instance.StartCoroutine(m_instance.SetBackgroundImageCoroutine(image));
            }
        }

        private IEnumerator SetBackgroundImageCoroutine(Sprite image)
        {
            if (Mathf.Approximately(0, fadeDuration))
            {
                m_instance.background.sprite = image;
                yield break;
            }
            var sceneTransitionManager = DialogueManager.instance.GetComponentInChildren<StandardSceneTransitionManager>();
            if (sceneTransitionManager == null)
            {
                m_instance.background.sprite = image;
                yield break;
            }
            else
            {
                sceneTransitionManager.leaveSceneTransition.TriggerAnimation();
                yield return new WaitForSeconds(sceneTransitionManager.leaveSceneTransition.animationDuration + fadeDuration);
                m_instance.background.sprite = image;
                sceneTransitionManager.enterSceneTransition.TriggerAnimation();
            }
        }

    }
}