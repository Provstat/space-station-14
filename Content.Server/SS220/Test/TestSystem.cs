// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt

using Content.Server.Chat.Systems;
using Content.Shared.Interaction.Events;
using Content.Shared.Popups;
using Content.Shared.SS220.Test;

namespace Content.Server.SS220.Test;
public sealed class TestSystem : EntitySystem
{
    [Dependency] private ChatSystem _chatSystem = default!;
    [Dependency] private SharedPopupSystem _popup = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TestComponent, UseInHandEvent>(OnUseInHand);
    }

    private void OnUseInHand(Entity<TestComponent> ent, ref UseInHandEvent args)
    {
        if (ent.Comp.WhoUsedEntities.Contains(args.User.Id))
        {
            _popup.PopupEntity(Loc.GetString(ent.Comp.BackingMessage), ent.Owner);
        }
        else
        {
            _chatSystem.TrySendInGameICMessage(ent.Owner, Loc.GetString(ent.Comp.RegularMessage), InGameICChatType.Speak, false);
            ent.Comp.WhoUsedEntities.Add(args.User.Id);
        }
    }
}
