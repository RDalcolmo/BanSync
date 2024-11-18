using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.Gui.ContextMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSync;

public class ContextMenuHandler
{
    public static void Enable()
    {
        Plugin.ContextMenu.OnMenuOpened += OnOpenContextMenu;
    }

    public static void Disable()
    {
        Plugin.ContextMenu.OnMenuOpened -= OnOpenContextMenu;
    }

    public static void OnOpenContextMenu(IMenuOpenedArgs menuOpenedArgs)
    {
        if (menuOpenedArgs.Target is not MenuTargetDefault menuTargetDefault)
        {
            return;
        }

        if (menuTargetDefault.TargetObject is not IPlayerCharacter)
        {
            return;
        }

        if (menuTargetDefault.TargetName == Plugin.ClientState!.LocalPlayer!.Name.ToString())
        {
            return;
        }

        menuOpenedArgs.AddMenuItem(new MenuItem
        {
            PrefixChar = 'B',
            Name = "Add To BanSync",
            OnClicked = OpenBanSyncContextWindow,
        });
    }

    public static void OpenBanSyncContextWindow(IMenuItemClickedArgs args)
    {
        Plugin.BanSyncContextWindow.ToggleBanSyncContextUI(args);
    }
}
