namespace XIVCombo.Combos;

internal static class BRD
{
    public const byte ClassID = 5;
    public const byte JobID = 23;

    public const uint
        HeavyShot = 97,
        StraightShot = 98,
        VenomousBite = 100,
        RagingStrikes = 101,
        QuickNock = 106,
        Barrage = 107,
        RepellingShot = 112,
        Bloodletter = 110,
        Windbite = 113,
        RainOfDeath = 117,
        BattleVoice = 118,
        EmpyrealArrow = 3558,
        IronJaws = 3560,
        Sidewinder = 3562,
        CausticBite = 7406,
        Stormbite = 7407,
        BurstShot = 16495,
        Ladonsbite = 25783,
        RadiantFinale = 25785,
        WideVolley = 36974,
        HeartbreakShot = 36975,
        ResonantArrow = 36976,
        RadiantEncore = 36977;

    public static class Buffs
    {
        public const ushort
            Barrage = 128,
            HawksEye = 3861,
            ResonantArrowReady = 3862,
            RadiantEncoreReady = 3863;
    }

    public static class Debuffs
    {
        public const ushort
            VenomousBite = 124,
            Windbite = 129,
            CausticBite = 1200,
            Stormbite = 1201;
    }

    public static class Levels
    {
        public const byte
            StraightShot = 2,
            RagingStrikes = 4,
            VenomousBite = 6,
            Bloodletter = 12,
            WideVolley = 25,
            Windbite = 30,
            Barrage = 38,
            RainOfDeath = 45,
            BattleVoice = 50,
            EmpyrealArrow = 54,
            IronJaws = 56,
            Sidewinder = 60,
            BiteMastery = 64,
            RadiantFinale = 90,
            ResonantArrow = 96,
            RadiantEncore = 100;
    }
}

internal class BardHeavyShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == BRD.HeavyShot || actionID == BRD.BurstShot) && IsEnabled(CustomComboPreset.BardHeavyShotCombo))
        {
            if (level >= BRD.Levels.StraightShot && (HasEffect(BRD.Buffs.HawksEye) || HasEffect(BRD.Buffs.Barrage)))
                return OriginalHook(BRD.StraightShot);

            return OriginalHook(BRD.HeavyShot);
        }

        return actionID;
    }
}

internal class BardBloodletter : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == BRD.Bloodletter || actionID == BRD.HeartbreakShot) && IsEnabled(CustomComboPreset.BardBloodletterCombo))
        {
            if (level >= BRD.Levels.EmpyrealArrow && IsCooldownUsable(BRD.EmpyrealArrow))
                return BRD.EmpyrealArrow;

            if (level >= BRD.Levels.Bloodletter &&
                GetRemainingCharges(OriginalHook(BRD.Bloodletter)) == GetMaxCharges(OriginalHook(BRD.Bloodletter))
            )
                return OriginalHook(BRD.Bloodletter);

            if (level >= BRD.Levels.Sidewinder && IsCooldownUsable(BRD.Sidewinder))
                return BRD.Sidewinder;

            return OriginalHook(BRD.Bloodletter);
        }

        return actionID;
    }
}

internal class BardIronJaws : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.IronJaws && IsEnabled(CustomComboPreset.BardIronJawsCombo))
        {
            if (level >= BRD.Levels.BiteMastery)
            {
                if (!TargetHasEffect(BRD.Debuffs.Stormbite))
                    return BRD.Stormbite;

                if (!TargetHasEffect(BRD.Debuffs.CausticBite))
                    return BRD.CausticBite;
            }
            else
            {
                var DebuffVenomousBite = FindTargetEffect(BRD.Debuffs.VenomousBite);
                var DebuffWindbite = FindTargetEffect(BRD.Debuffs.Windbite);

                if (level >= BRD.Levels.Windbite && DebuffWindbite is null)
                    return BRD.Windbite;

                if (level >= BRD.Levels.VenomousBite && DebuffVenomousBite is null)
                    return BRD.VenomousBite;

                if (level >= BRD.Levels.IronJaws)
                    return BRD.IronJaws;

                if (level >= BRD.Levels.Windbite && DebuffWindbite?.RemainingTime < DebuffVenomousBite?.RemainingTime)
                    return BRD.Windbite;

                if (level >= BRD.Levels.VenomousBite)
                    return BRD.VenomousBite;
            }

            return BRD.IronJaws;
        }

        return actionID;
    }
}

internal class BardQuickNock : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == BRD.QuickNock || actionID == BRD.Ladonsbite) && IsEnabled(CustomComboPreset.BardQuickNockCombo))
        {
            if (level >= BRD.Levels.WideVolley && (HasEffect(BRD.Buffs.HawksEye) || HasEffect(BRD.Buffs.Barrage)))
                return OriginalHook(BRD.WideVolley);

            return OriginalHook(BRD.QuickNock);
        }

        return actionID;
    }
}

internal class BardRainOfDeath : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.RainOfDeath && IsEnabled(CustomComboPreset.BardRainOfDeathCombo))
        {
            if (level >= BRD.Levels.EmpyrealArrow && IsCooldownUsable(BRD.EmpyrealArrow))
                return BRD.EmpyrealArrow;

            if (level >= BRD.Levels.RainOfDeath &&
                GetRemainingCharges(BRD.RainOfDeath) == GetMaxCharges(BRD.RainOfDeath)
            )
                return BRD.RainOfDeath;

            if (level >= BRD.Levels.Sidewinder && IsCooldownUsable(BRD.Sidewinder))
                return BRD.Sidewinder;

            return BRD.RainOfDeath;
        }

        return actionID;
    }
}

internal class BardBattleVoice : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.BattleVoice && IsEnabled(CustomComboPreset.BardBattleVoiceCombo))
        {
            if (level >= BRD.Levels.RadiantEncore && HasEffect(BRD.Buffs.RadiantEncoreReady))
                return OriginalHook(BRD.RadiantFinale);

            if (level >= BRD.Levels.BattleVoice && IsCooldownUsable(BRD.BattleVoice))
                return BRD.BattleVoice;

            if (level >= BRD.Levels.RadiantFinale && IsCooldownUsable(BRD.RadiantFinale))
                return OriginalHook(BRD.RadiantFinale);

            return BRD.BattleVoice;
        }

        return actionID;
    }
}

internal class BardRagingStrikes : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.RagingStrikes && IsEnabled(CustomComboPreset.BardRagingStrikesCombo))
        {
            if (level >= BRD.Levels.ResonantArrow && HasEffect(BRD.Buffs.ResonantArrowReady))
                return OriginalHook(BRD.Barrage);

            if (level >= BRD.Levels.RagingStrikes && IsCooldownUsable(BRD.RagingStrikes))
                return BRD.RagingStrikes;

            if (level >= BRD.Levels.Barrage && IsCooldownUsable(BRD.Barrage))
                return OriginalHook(BRD.Barrage);

            return BRD.RagingStrikes;
        }

        return actionID;
    }
}

internal class BardPeloton : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == ADV.Peloton && IsEnabled(CustomComboPreset.BardPelotonCombo))
        {
            if (InCombat())
                return BRD.RepellingShot;

            return ADV.Peloton;
        }

        return actionID;
    }
}
