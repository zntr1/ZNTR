﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace ZNTR_Urgot.Modes
{
    public sealed class Ignite : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Config.KillstealMenu["UseIgnite"].Cast<CheckBox>().CurrentValue;
        }

        public override void Execute()
        {
            var igniteslot = Player.Instance.GetSpellSlotFromName("summonerdot");

            if (igniteslot != SpellSlot.Unknown && Player.CanUseSpell(igniteslot) == SpellState.Ready)
            {
                var target = TargetSelector.GetTarget(550, DamageType.True);

                if (target != null && Damage.GetIgniteDamage() > target.Health)
                {
                    Player.CastSpell(igniteslot, target);
                }
            }
        }
    }
}
