﻿using BepInEx.Configuration;
using System.Collections.Generic;

namespace MoxoPixel.MenuOverhaul.Utils
{
    public class Settings
    {
        private const string GeneralSectionTitle = "1. General";

        public static ConfigFile Config;

        public static ConfigEntry<bool> EnableBackground;
        public static ConfigEntry<bool> EnableTopGlow;
        public static ConfigEntry<bool> EnableExtraShadows;

        public static List<ConfigEntryBase> ConfigEntries = new List<ConfigEntryBase>();

        public static void Init(ConfigFile Config)
        {
            ConfigEntries.Add(EnableBackground = Config.Bind(
                GeneralSectionTitle,
                "Enable Background",
                true,
                new ConfigDescription(
                    "Enable or disable the background in the main menu",
                    null,
                    new ConfigurationManagerAttributes { })));

            ConfigEntries.Add(EnableTopGlow = Config.Bind(
                GeneralSectionTitle,
                "Enable Top Glow",
                true,
                new ConfigDescription(
                    "Enable or disable the blue/yellow top glow in the main menu",
                    null,
                    new ConfigurationManagerAttributes { })));

            ConfigEntries.Add(EnableExtraShadows = Config.Bind(
                GeneralSectionTitle,
                "Enable Extra Shadows",
                false,
                new ConfigDescription(
                    "Enable or disable more shadows to make the player in menu more detailed (restart required)",
                    null,
                    new ConfigurationManagerAttributes { })));

            RecalcOrder();
        }

        private static void RecalcOrder()
        {
            // Set the Order field for all settings, to avoid unnecessary changes when adding new settings
            int settingOrder = ConfigEntries.Count;
            foreach (var entry in ConfigEntries)
            {
                ConfigurationManagerAttributes attributes = entry.Description.Tags[0] as ConfigurationManagerAttributes;
                if (attributes != null)
                {
                    attributes.Order = settingOrder;
                }

                settingOrder--;
            }
        }

        public enum EAlignment
        {
            Right = 0,
            Left = 1,
        }
    }
}