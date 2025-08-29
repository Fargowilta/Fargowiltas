using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Fargowiltas.Content.Items.Tiles
{
    public abstract class UnsafeWall : ModItem
    {
        private readonly string name;
        private readonly int createWall;
        private readonly int wall;
        private readonly int tile;

        protected UnsafeWall(string name, int createWall, int wall = -1, int tile = -1)
        {
            this.name = name;
            this.createWall = createWall;
            this.wall = wall;
            this.tile = tile;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault(name);
            // Tooltip.SetDefault("Allows area-specific enemies to spawn");
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.rare = ItemRarityID.White;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = createWall;
        }

        public override void AddRecipes()
        {
            if (wall != -1)
            {
                Recipe.Create(Type)
                    .AddIngredient(wall)
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
            if (tile != -1)
            {
                Recipe.Create(Type, 4)
                    .AddIngredient(tile)
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
        }
    }

    public class UnsafeBlueSlabWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.BlueBrickWall}";
        public UnsafeBlueSlabWall() : base("Unsafe Blue Slab Wall", WallID.BlueDungeonSlabUnsafe) { }
    }

    public class UnsafeBlueTileWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.BlueTiledWall}";
        public UnsafeBlueTileWall() : base("Unsafe Blue Tile Wall", WallID.BlueDungeonTileUnsafe) { }
    }

    public class UnsafeBlueBrickWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.BlueBrickWall}";
        public UnsafeBlueBrickWall() : base("Unsafe Blue Brick Wall", WallID.BlueDungeonUnsafe) { }
    }

    public class UnsafeGreenSlabWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GreenBrickWall}";
        public UnsafeGreenSlabWall() : base("Unsafe Green Slab Wall", WallID.GreenDungeonSlabUnsafe) { }
    }

    public class UnsafeGreenTileWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GreenTiledWall}";
        public UnsafeGreenTileWall() : base("Unsafe Green Tile Wall", WallID.GreenDungeonTileUnsafe) { }
    }

    public class UnsafeGreenBrickWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GreenBrickWall}";
        public UnsafeGreenBrickWall() : base("Unsafe Green Brick Wall", WallID.GreenDungeonUnsafe) { }
    }

    public class UnsafePinkSlabWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.PinkBrickWall}";
        public UnsafePinkSlabWall() : base("Unsafe Pink Slab Wall", WallID.PinkDungeonSlabUnsafe) { }
    }

    public class UnsafePinkTileWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.PinkTiledWall}";
        public UnsafePinkTileWall() : base("Unsafe Pink Tile Wall", WallID.PinkDungeonTileUnsafe) { }
    }

    public class UnsafePinkBrickWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.PinkBrickWall}";
        public UnsafePinkBrickWall() : base("Unsafe Pink Brick Wall", WallID.PinkDungeonUnsafe) { }
    }

    public class UnsafeLihzahrdBrickWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.LihzahrdBrickWall}";
        public UnsafeLihzahrdBrickWall() : base("Unsafe Lihzahrd Brick Wall", WallID.LihzahrdBrickUnsafe, ItemID.LihzahrdBrickWall, ItemID.LihzahrdBrick) { }
    }

    public class UnsafeSpiderWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.SpiderEcho}";
        public UnsafeSpiderWall() : base("Unsafe Spider Wall", WallID.SpiderUnsafe, ItemID.SpiderEcho) { }
    }

    public class UnsafeMarbleWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.MarbleWall}";
        public UnsafeMarbleWall() : base("Unsafe Marble Wall", WallID.MarbleUnsafe, ItemID.MarbleWall, ItemID.Marble) { }
    }

    public class UnsafeGraniteWall : UnsafeWall
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GraniteWall}";
        public UnsafeGraniteWall() : base("Unsafe Granite Wall", WallID.GraniteUnsafe, ItemID.GraniteWall, ItemID.Granite) { }
    }
}