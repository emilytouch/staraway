using UnityEngine;

namespace PixelCrushers.DialogueSystem
{

    /// <summary>
    /// Add this script to your Visual Novel Framework Dialogue Manager if you want to keep track
    /// of the current conversation and dialogue entry. When you load a game,
    /// it will resume the conversation at that point.
    /// </summary>
    public class RememberCurrentDialogueEntry : ConversationStateSaver
    {

#if !USE_INK // The Ink integration has its own version of this.

        public override void OnApplyPersistentData()
        {
            var menus = FindObjectOfType<PixelCrushers.DialogueSystem.VisualNovelFramework.Menus>();
            if (menus != null) menus.MonitorConversation(false);
            base.OnApplyPersistentData();
        }

        public override void OnConversationStart(Transform actor)
        {
            base.OnConversationStart(actor);
            var menus = FindObjectOfType<PixelCrushers.DialogueSystem.VisualNovelFramework.Menus>();
            if (menus != null) menus.OnConversationStart(actor);
        }

        public override void OnConversationEnd(Transform actor)
        {
            base.OnConversationEnd(actor);
            var menus = FindObjectOfType<PixelCrushers.DialogueSystem.VisualNovelFramework.Menus>();
            if (menus != null) menus.OnConversationEnd(actor);
        }

#endif

    }
}