using Robust.Shared.Network;
using Robust.Shared.Serialization;

namespace Content.Shared.SS220.MindExtension.Events;


[Serializable, NetSerializable]
public sealed class MindExtEntityMessage(NetEntity mindExtEnt) : EntityEventArgs
{
    public NetEntity MindExtensionEntity = mindExtEnt;
}
