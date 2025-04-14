using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;
using Fargowiltas;
using Terraria.Audio;
using ReLogic.Content;
using Fargowiltas.Content.UI;

namespace Fargowilta
{
    public class UIManager
    {
        public UserInterface StatSheetUserInterface;
        public UserInterface StatSheetTogglerUserInterface;
        public StatSheetUI StatSheet;
        public StatButton StatButton;
        private GameTime _lastUpdateUIGameTime;

        public Asset<Texture2D> StatsButtonTexture;
        public Asset<Texture2D> StatsButton_MouseOverTexture;

        public void LoadUI()
        {
            if (!Main.dedServ)
            {
                // Load textures
                StatsButtonTexture = (ModContent.Request<Texture2D>("Fargowiltas/Content/UI/Assets/StatsButton", AssetRequestMode.ImmediateLoad));
                StatsButton_MouseOverTexture = (ModContent.Request<Texture2D>("Fargowiltas/Content/UI/Assets/StatsButton_MouseOver", AssetRequestMode.ImmediateLoad));

                // Initialize UserInterfaces
                StatSheetUserInterface = new UserInterface();
                StatSheetTogglerUserInterface = new UserInterface();

                // Activate UIs
                StatSheet = new StatSheetUI();
                StatSheet.Activate();
                StatButton = new StatButton();
                StatButton.Activate();

                StatSheetTogglerUserInterface.SetState(StatButton);
            }
        }

        public void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUIGameTime = gameTime;

            if (!Main.playerInventory)
            {
                CloseStatSheet();
                CloseStatButton();
            }
            else
            {
                OpenStatButton();
            }


            if (StatSheetUserInterface?.CurrentState != null)
                StatSheetUserInterface.Update(gameTime);
            if (StatSheetTogglerUserInterface?.CurrentState != null)
                StatSheetTogglerUserInterface.Update(gameTime);
        }

        public bool IsStatSheetOpen() => StatSheetUserInterface?.CurrentState == null;
        public void CloseStatSheet() => StatSheetUserInterface?.SetState(null);
        //public bool IsTogglerOpen() => TogglerUserInterface.CurrentState == StatSheet;
        public void OpenStatSheet() => StatSheetUserInterface.SetState(StatSheet);
        public void OpenStatButton() => StatSheetTogglerUserInterface.SetState(StatButton);
        public void CloseStatButton() => StatSheetTogglerUserInterface?.SetState(null);

        public void ToggleStatSheet()
        {
            if (IsStatSheetOpen())
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                OpenStatSheet();
            }
            else// if (IsTogglerOpen())
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                CloseStatSheet();
            }
        }

        public void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex((layer) => layer.Name == "Vanilla: Inventory");
            if (index != -1)
            {
                layers.Insert(index - 1, new LegacyGameInterfaceLayer("Fargos: Stat Sheet", delegate
                {
                    if (_lastUpdateUIGameTime != null && StatSheetUserInterface?.CurrentState != null)
                        StatSheetUserInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);
                    return true;
                }, InterfaceScaleType.UI));
            }

            index = layers.FindIndex((layer) => layer.Name == "Vanilla: Mouse Text");
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("Fargos: Stat Sheet Toggler", delegate
                {
                    if (_lastUpdateUIGameTime != null && StatSheetTogglerUserInterface?.CurrentState != null)
                        StatSheetTogglerUserInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);

                    return true;
                }, InterfaceScaleType.UI));
            }
        }
    }
}