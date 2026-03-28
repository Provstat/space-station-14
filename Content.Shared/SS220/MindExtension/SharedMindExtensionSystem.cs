using Robust.Shared.Network;
using Robust.Shared.Utility;
using System.Diagnostics.CodeAnalysis;

namespace Content.Shared.SS220.MindExtension;

public abstract class SharedMindExtensionSystem : EntitySystem
{
    /// <summary>
    /// Returns the player associated with entity of <see cref="MindExtensionComponent"/>.
    /// If it doesn't exist, it will be created.
    /// </summary>
    public Entity<MindExtensionComponent> GetMindExtension(NetUserId player)
    {
        var mindExts = EntityManager.AllComponents<MindExtensionComponent>();
        var entity = mindExts.FirstOrNull(x => x.Component.Player == player);

        if (entity is not null)
            return entity.Value;

        var newEnt = EntityManager.CreateEntityUninitialized(null);

        AddComp<MindExtensionComponent>(newEnt);
        var comp = Comp<MindExtensionComponent>(newEnt);
        comp.Player = player;

        EntityManager.InitializeEntity(newEnt);

        Dirty(newEnt, comp);
        return new(newEnt, comp);
    }

    public bool TryGetMindExtension(NetUserId player, [NotNullWhen(true)] out Entity<MindExtensionComponent>? entity)
    {
        var mindExts = EntityManager.AllComponents<MindExtensionComponent>();
        entity = mindExts.FirstOrNull(x => x.Component.Player == player);

        return entity is not null;
    }
}
