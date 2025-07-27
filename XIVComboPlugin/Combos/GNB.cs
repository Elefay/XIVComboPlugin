namespace XIVCombo.Combos;

internal static class GNB
{
    public const byte JobID = 37;

    public const uint
        KeenEdge = 16137,
        BrutalShell = 16139,
        DemonSlice = 16141,
        RoyalGuard = 16142,
        SolidBarrel = 16145,
        GnashingFang = 16146,
        DemonSlaughter = 16149,
        Continuation = 16155,
        JugularRip = 16156,
        AbdomenTear = 16157,
        EyeGouge = 16158,
        BurstStrike = 16162,
        FatedCircle = 16163,
        Hypervelocity = 25759,
        DoubleDown = 25760,
        RoyalGuardRemoval = 32068,
        FatedBrand = 36936;
    public static class Buffs
    {
        public const ushort
            RoyalGuard = 1833,
            ReadyToRip = 1842,
            ReadyToTear = 1843,
            ReadyToGouge = 1844,
            ReadyToBlast = 2686,
            ReadyToRaze = 3839;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            BrutalShell = 4,
            RoyalGuard = 10,
            SolidBarrel = 26,
            DemonSlaughter = 40,
            GnashingFang = 60,
            Continuation = 70,
            EnhancedContinuation = 86,
            DoubleDown = 90,
            EnhancedContinuation2 = 96;
    }
}

internal class GunbreakerSolidBarrel : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerSolidBarrelCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.SolidBarrel)
        {
            if (comboTime > 0)
            {
                if (lastComboMove == GNB.BrutalShell && level >= GNB.Levels.SolidBarrel)
                    return GNB.SolidBarrel;

                if (lastComboMove == GNB.KeenEdge && level >= GNB.Levels.BrutalShell)
                    return GNB.BrutalShell;
            }

            return GNB.KeenEdge;
        }

        return actionID;
    }
}

internal class GunbreakerGnashingFang : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerGnashingFangCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.BurstStrike)
        {
            if (level >= GNB.Levels.Continuation)
            {
                if (HasEffect(GNB.Buffs.ReadyToGouge))
                    return GNB.EyeGouge;

                if (HasEffect(GNB.Buffs.ReadyToTear))
                    return GNB.AbdomenTear;

                if (HasEffect(GNB.Buffs.ReadyToRip))
                    return GNB.JugularRip;
            }

            if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToBlast))
                return GNB.Hypervelocity;

            if (level >= GNB.Levels.GnashingFang && (IsCooldownUsable(GNB.GnashingFang) || !IsOriginal(GNB.GnashingFang)))
                return OriginalHook(GNB.GnashingFang);

            return GNB.BurstStrike;
        }

        return actionID;
    }
}

internal class GunbreakerDemonSlaughter : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerDemonSlaughterCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.DemonSlaughter)
        {
            if (comboTime > 0 && lastComboMove == GNB.DemonSlice && level >= GNB.Levels.DemonSlaughter)
                return GNB.DemonSlaughter;

            return GNB.DemonSlice;
        }

        return actionID;
    }
}

internal class GunbreakerDoubleDown : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerDoubleDownCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.FatedCircle)
        {
            if (level >= GNB.Levels.EnhancedContinuation2 && HasEffect(GNB.Buffs.ReadyToRaze))
                return GNB.FatedBrand;

            if (level >= GNB.Levels.DoubleDown && IsCooldownUsable(GNB.DoubleDown))
                return GNB.DoubleDown;

            return GNB.FatedCircle;
        }

        return actionID;
    }
}

internal class GunbreakerProvoke : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.GunbreakerProvokeCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == ADV.Provoke)
        {
            if (level >= GNB.Levels.RoyalGuard && !HasEffect(GNB.Buffs.RoyalGuard))
                return GNB.RoyalGuard;

            return ADV.Provoke;
        }

        return actionID;
    }
}

internal class GunbreakerShirk : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.GunbreakerShirkCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == ADV.Shirk)
        {
            if (level >= GNB.Levels.RoyalGuard && HasEffect(GNB.Buffs.RoyalGuard))
                return GNB.RoyalGuardRemoval;

            return ADV.Shirk;
        }

        return actionID;
    }
}
