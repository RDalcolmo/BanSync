using Dalamud.Game.Gui.ContextMenu;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BanSync.Windows;
public class BanSyncContextWindow : Window, IDisposable
{
    private Plugin Plugin;
    private string PlayerName;
    private ulong PlayerId;

    public BanSyncContextWindow(Plugin plugin)
        : base("Add to BanSync", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        Plugin = plugin;

        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(305, 150),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };
    }

    public void ToggleBanSyncContextUI(IMenuItemClickedArgs args)
    {

        if (args.Target is not MenuTargetDefault menuTargetDefault)
        {
            return;
        }

        PlayerName = menuTargetDefault.TargetName;
        PlayerId = menuTargetDefault.TargetObjectId;
        this.Toggle();
    }

    public void Dispose() { }

    public override void Draw()
    {

        ImGui.Text($"Adding '{PlayerName} {PlayerId}' to your BanSync!");
        ImGui.Text($"Reason/Comment:");

        string args = "";
        ImGui.Spacing();
        ImGui.InputText("", ref args, 400);
    }
}
