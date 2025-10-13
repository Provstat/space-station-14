// © SS220, An EULA/CLA with a hosting restriction, full text: https://raw.githubusercontent.com/SerbiaStrong-220/space-station-14/master/CLA.txt

namespace Content.Shared.SS220.Test;

[RegisterComponent]
public sealed partial class TestComponent : Component
{
    [DataField]
    public LocId RegularMessage = "test-regular-message";

    [DataField]
    public LocId BackingMessage = "test-backing-message";

    [DataField]
    public List<int> WhoUsedEntities = new List<int>();
}
