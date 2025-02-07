using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Magitek.Utilities.Routines
{
    internal static class Paladin
    {
        public static WeaveWindow GlobalCooldown = new WeaveWindow(ClassJobType.Paladin, Spells.FastBlade);

        public static SpellData RoyalAuthority => Core.Me.ClassLevel < 60
                                                    ? Spells.RageofHalone
                                                    : Spells.RoyalAuthority;

        public static readonly List<uint> Defensives = new List<uint>()
        {
            Auras.HallowedGround,
            Auras.Rampart,
            Auras.Sentinel
        };

        public static int RequiescatStackCount => Core.Me.CharacterAuras.GetAuraStacksById(Auras.Requiescat);

        public static bool ToggleAndSpellCheck(bool Toggle, SpellData Spell)
        {
            if (!Toggle)
                return false;

            if (!ActionManager.HasSpell(Spell.Id))
                return false;

            return true;
        }

        public static bool CanContinueComboAfter(SpellData LastSpellExecuted)
        {
            if (ActionManager.ComboTimeLeft <= 0)
                return false;

            if (ActionManager.LastSpell.Id != LastSpellExecuted.Id)
                return false;

            return true;
        }
    }
}