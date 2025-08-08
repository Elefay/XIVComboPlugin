using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class RDM
{
    public const byte JobID = 35;

    public const uint
        Jolt = 7503,
        Riposte = 7504,
        Verthunder = 7505,
        Veraero = 7507,
        Scatter = 7509,
        Verfire = 7510,
        Verstone = 7511,
        Zwerchhau = 7512,
        Redoublement = 7516,
        Fleche = 7517,
        ContreSixte = 7519,
        Verraise = 7523,
        Verflare = 7525,
        Verholy = 7526,
        Verthunder2 = 16524,
        Veraero2 = 16525,
        Reprise = 16529,
        Scorch = 16530,
        Verthunder3 = 25855,
        Veraero3 = 25856;

    public static class Buffs
    {
        public const ushort
            VerfireReady = 1234,
            VerstoneReady = 1235,
            Acceleration = 1238,
            Dualcast = 1249,
            GrandImpactReady = 3877;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Verthunder = 4,
            Veraero = 10,
            Verthunder2 = 18,
            Veraero2 = 22,
            Verfire = 26,
            Verstone = 30,
            Zwerchhau = 35,
            Fleche = 45,
            Redoublement = 50,
            Verraise = 64,
            Verflare = 68,
            Verholy = 70,
            Reprise = 76,
            Scorch = 80,
            Resolution = 90,
            GrandImpact = 96;
    }
}

internal class RedMageVerthunder : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == RDM.Verthunder || actionID == RDM.Verthunder3) && IsEnabled(CustomComboPreset.RedMageVerthunderCombo))
        {
            var BuffVerfireReady = FindEffect(RDM.Buffs.VerfireReady);
            var Gauge = GetJobGauge<RDMGauge>();

            if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                return OriginalHook(RDM.Jolt);

            if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                return OriginalHook(RDM.Jolt);

            if (level >= RDM.Levels.Verflare && Gauge.ManaStacks == 3)
                return OriginalHook(RDM.Verthunder);

            if (level >= RDM.Levels.GrandImpact && HasEffect(RDM.Buffs.GrandImpactReady))
                return OriginalHook(RDM.Jolt);

            if (level >= RDM.Levels.Verthunder && (
                HasEffect(RDM.Buffs.Acceleration) ||
                HasEffect(RDM.Buffs.Dualcast) ||
                HasEffect(ADV.Buffs.Swiftcast)
            ))
                return OriginalHook(RDM.Verthunder);

            if (level >= RDM.Levels.Reprise && IsMoving && Gauge.BlackMana >= 5 && Gauge.WhiteMana >= 5)
                return OriginalHook(RDM.Reprise);

            if (level >= RDM.Levels.Verfire && BuffVerfireReady?.RemainingTime >= 2.5)
                return RDM.Verfire;

            return OriginalHook(RDM.Jolt);
        }

        return actionID;
    }
}

internal class RedMageVeraero : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == RDM.Veraero || actionID == RDM.Veraero3) && IsEnabled(CustomComboPreset.RedMageVeraeroCombo))
        {
            var BuffVerstoneReady = FindEffect(RDM.Buffs.VerstoneReady);
            var Gauge = GetJobGauge<RDMGauge>();

            if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                return OriginalHook(RDM.Jolt);

            if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                return OriginalHook(RDM.Jolt);

            if (level >= RDM.Levels.Verholy && Gauge.ManaStacks == 3)
                return OriginalHook(RDM.Veraero);

            if (level >= RDM.Levels.GrandImpact && HasEffect(RDM.Buffs.GrandImpactReady))
                return OriginalHook(RDM.Jolt);

            if (level >= RDM.Levels.Veraero && (
                HasEffect(RDM.Buffs.Acceleration) ||
                HasEffect(RDM.Buffs.Dualcast) ||
                HasEffect(ADV.Buffs.Swiftcast)
            ))
                return OriginalHook(RDM.Veraero);

            if (level >= RDM.Levels.Reprise && IsMoving && Gauge.BlackMana >= 5 && Gauge.WhiteMana >= 5)
                return OriginalHook(RDM.Reprise);

            if (level >= RDM.Levels.Verstone && BuffVerstoneReady?.RemainingTime >= 2.5)
                return RDM.Verstone;

            return OriginalHook(RDM.Jolt);
        }

        return actionID;
    }
}

internal class RedMageRedoublement : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Redoublement && IsEnabled(CustomComboPreset.RedMageRedoublementCombo))
        {
            if (level >= RDM.Levels.Redoublement && lastComboMove == RDM.Zwerchhau)
                return OriginalHook(RDM.Redoublement);

            if (level >= RDM.Levels.Zwerchhau && lastComboMove == RDM.Riposte)
                return OriginalHook(RDM.Zwerchhau);

            return OriginalHook(RDM.Riposte);
        }

        return actionID;
    }
}

internal class RedMageVerthunder2 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Verthunder2 && IsEnabled(CustomComboPreset.RedMageVerthunder2Combo))
        {
            var Gauge = GetJobGauge<RDMGauge>();

            if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                return OriginalHook(RDM.Scatter);

            if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                return OriginalHook(RDM.Scatter);

            if (level >= RDM.Levels.Verflare && Gauge.ManaStacks == 3)
                return OriginalHook(RDM.Verthunder2);

            if (level >= RDM.Levels.GrandImpact && HasEffect(RDM.Buffs.GrandImpactReady))
                return OriginalHook(RDM.Scatter);

            if (HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Dualcast) || HasEffect(ADV.Buffs.Swiftcast))
                return OriginalHook(RDM.Scatter);

            if (level >= RDM.Levels.Reprise && IsMoving && Gauge.BlackMana >= 5 && Gauge.WhiteMana >= 5)
                return OriginalHook(RDM.Reprise);

            if (level >= RDM.Levels.Verthunder2)
                return OriginalHook(RDM.Verthunder2);

            return OriginalHook(RDM.Scatter);
        }

        return actionID;
    }
}

internal class RedMageVeraero2 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Veraero2 && IsEnabled(CustomComboPreset.RedMageVeraero2Combo))
        {
            var Gauge = GetJobGauge<RDMGauge>();

            if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                return OriginalHook(RDM.Scatter);

            if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                return OriginalHook(RDM.Scatter);

            if (level >= RDM.Levels.Verholy && Gauge.ManaStacks == 3)
                return OriginalHook(RDM.Veraero2);

            if (level >= RDM.Levels.GrandImpact && HasEffect(RDM.Buffs.GrandImpactReady))
                return OriginalHook(RDM.Scatter);

            if (HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Dualcast) || HasEffect(ADV.Buffs.Swiftcast))
                return OriginalHook(RDM.Scatter);

            if (level >= RDM.Levels.Reprise && IsMoving && Gauge.BlackMana >= 5 && Gauge.WhiteMana >= 5)
                return OriginalHook(RDM.Reprise);

            if (level >= RDM.Levels.Veraero2)
                return OriginalHook(RDM.Veraero2);

            return OriginalHook(RDM.Scatter);
        }

        return actionID;
    }
}

internal class RedMageFleche : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Fleche && IsEnabled(CustomComboPreset.RedMageFlecheCombo))
        {
            if (level >= RDM.Levels.Fleche && IsCooldownUsable(RDM.Fleche))
                return RDM.Fleche;

            if (level >= RDM.Levels.Fleche && IsCooldownUsable(RDM.ContreSixte))
                return RDM.ContreSixte;

            return RDM.Fleche;
        }

        return actionID;
    }
}

internal class RedMageVerraise : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Verraise && IsEnabled(CustomComboPreset.RedMageVerraiseCombo))
        {
            if (CanUseAction(ADV.Swiftcast) && IsCooldownUsable(ADV.Swiftcast) && !HasEffect(RDM.Buffs.Dualcast))
                return ADV.Swiftcast;

            if (level >= RDM.Levels.Verraise)
                return RDM.Verraise;

            if (CanUseAction(ADV.Swiftcast))
                return ADV.Swiftcast;

            return RDM.Verraise;
        }

        return actionID;
    }
}
