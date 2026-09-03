using Robust.Shared.Serialization;

namespace Content.Shared.Arcade
{
    [Serializable, NetSerializable]
    public struct BlockGameBlock
    {
        public Vector2i Position;
        public readonly BlockGameBlockColor GameBlockColor;

        public BlockGameBlock(Vector2i position, BlockGameBlockColor gameBlockColor)
        {
            Position = position;
            GameBlockColor = gameBlockColor;
        }

        [Serializable, NetSerializable]
        public enum BlockGameBlockColor
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            LightBlue,
            Purple,
            GhostRed,
            GhostOrange,
            GhostYellow,
            GhostGreen,
            GhostBlue,
            GhostLightBlue,
            GhostPurple,
        }

        public static BlockGameBlockColor ToGhostBlockColor(BlockGameBlockColor inColor)
        {
            return inColor switch
            {
                BlockGameBlockColor.Red => BlockGameBlockColor.GhostRed,
                BlockGameBlockColor.Orange => BlockGameBlockColor.GhostOrange,
                BlockGameBlockColor.Yellow => BlockGameBlockColor.GhostYellow,
                BlockGameBlockColor.Green => BlockGameBlockColor.GhostGreen,
                BlockGameBlockColor.Blue => BlockGameBlockColor.GhostBlue,
                BlockGameBlockColor.LightBlue => BlockGameBlockColor.GhostLightBlue,
                BlockGameBlockColor.Purple => BlockGameBlockColor.GhostPurple,
                _ => inColor
            };
        }

        public static Color ToColor(BlockGameBlockColor inColor)
        {
            return inColor switch
            {
                //SS220-block-game-visuals begin
                BlockGameBlockColor.Red => new(230, 80, 84),
                BlockGameBlockColor.Orange => Color.Orange,
                BlockGameBlockColor.Yellow => new(189, 134, 0),
                BlockGameBlockColor.Green => new(0, 163, 42),
                BlockGameBlockColor.Blue => new(53, 53, 222),
                BlockGameBlockColor.Purple => new(76, 40, 130),
                BlockGameBlockColor.LightBlue => Color.Cyan,
                BlockGameBlockColor.GhostRed => new(230, 80, 84, 85),
                BlockGameBlockColor.GhostOrange => Color.Orange.WithAlpha(0.33f),
                BlockGameBlockColor.GhostYellow => new(189, 134, 0, 85),
                BlockGameBlockColor.GhostGreen => new(0, 163, 42, 85),
                BlockGameBlockColor.GhostBlue => new(53, 53, 222, 85),
                BlockGameBlockColor.GhostPurple => new(76, 40, 130),
                BlockGameBlockColor.GhostLightBlue => Color.Cyan.WithAlpha(0.33f),
                //SS220-block-game-visuals end
                _ => Color.Olive //olive is error
            };
        }
    }

    public static class BlockGameVector2Extensions
    {
        public static BlockGameBlock ToBlockGameBlock(this Vector2i vector2, BlockGameBlock.BlockGameBlockColor gameBlockColor)
        {
            return new(vector2, gameBlockColor);
        }

        public static Vector2i AddToX(this Vector2i vector2, int amount)
        {
            return new(vector2.X + amount, vector2.Y);
        }
        public static Vector2i AddToY(this Vector2i vector2, int amount)
        {
            return new(vector2.X, vector2.Y + amount);
        }

        public static Vector2i Rotate90DegreesAsOffset(this Vector2i vector)
        {
            return new(-vector.Y, vector.X);
        }
    }
}
