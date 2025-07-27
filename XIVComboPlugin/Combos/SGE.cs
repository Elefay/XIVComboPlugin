using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class SGE
{
    public const byte JobID = 40;

    public const uint
        Dosis = 24283,
        Dosis2 = 24306,
        Dosis3 = 24312,
        Kardia = 24285,
        Egeiro = 24287,
        Phlegma = 24289,
        Soteria = 24294,
        Druochole = 24296,
        Kerachole = 24298,
        Ixochole = 24299,
        Zoe = 24300,
        Taurochole = 24303,
        Toxikon = 24304,
        Phlegma2 = 24307,
        Rhizomata = 24309,
        Phlegma3 = 24313,
        Pneuma = 24318,
        Psyche = 37033;

    public static class Buffs
    {
        public const ushort
            Kardion = 2604,
            Eukrasia = 2606;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const ushort
            Egeiro = 12,
            Soteria = 35,
            Kerachole = 50,
            Ixochole = 52,
            Zoe = 56,
            Taurochole = 62,
            Toxicon = 66,
            Rhizomata = 74,
            Pneuma = 90,
            Psyche = 92;
    }
}

internal class SageKerachole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Kerachole && IsEnabled(CustomComboPreset.SageKeracholeCombo))
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (level >= SGE.Levels.Rhizomata && gauge.Addersgall == 0)
                return SGE.Rhizomata;

            if (level >= SGE.Levels.Kerachole && IsCooldownUsable(SGE.Kerachole))
                return SGE.Kerachole;

            if (level >= SGE.Levels.Ixochole && IsCooldownUsable(SGE.Ixochole))
                return SGE.Ixochole;

            return SGE.Kerachole;
        }

        return actionID;
    }
}

internal class SageTaurochole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Taurochole && IsEnabled(CustomComboPreset.SageTaurocholeCombo))
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (level >= SGE.Levels.Rhizomata && gauge.Addersgall == 0)
                return SGE.Rhizomata;

            if (level >= SGE.Levels.Taurochole && IsCooldownUsable(SGE.Taurochole))
                return SGE.Taurochole;

            return SGE.Druochole;
        }

        return actionID;
    }
}

internal class SageDosis : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == SGE.Dosis || actionID == SGE.Dosis2 || actionID == SGE.Dosis3) &&
            IsEnabled(CustomComboPreset.SageDosisCombo))
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (level >= SGE.Levels.Toxicon && gauge.Addersting > 0 && IsMoving && !HasEffect(SGE.Buffs.Eukrasia))
                return OriginalHook(SGE.Toxikon);

            return OriginalHook(SGE.Dosis);
        }

        return actionID;
    }
}

internal class SageEgeiro : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Egeiro && IsEnabled(CustomComboPreset.SageEgeiroCombo))
        {
            if (CanUseAction(ADV.Swiftcast) && IsCooldownUsable(ADV.Swiftcast))
                return ADV.Swiftcast;

            if (level >= SGE.Levels.Egeiro)
                return SGE.Egeiro;

            if (CanUseAction(ADV.Swiftcast))
                return ADV.Swiftcast;

            return SGE.Egeiro;
        }

        return actionID;
    }
}

internal class SageKardia : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Kardia && IsEnabled(CustomComboPreset.SageKardiaCombo))
        {
            if (level >= SGE.Levels.Soteria && HasEffect(SGE.Buffs.Kardion) && IsCooldownUsable(SGE.Soteria))
                return SGE.Soteria;

            return SGE.Kardia;
        }

        return actionID;
    }
}

internal class SagePhlegma : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == SGE.Phlegma || actionID == SGE.Phlegma2 || actionID == SGE.Phlegma3) &&
            IsEnabled(CustomComboPreset.SagePhlegmaCombo))
        {
            if (level >= SGE.Levels.Psyche && IsCooldownUsable(SGE.Psyche))
                return SGE.Psyche;

            return OriginalHook(SGE.Phlegma);
        }

        return actionID;
    }
}

internal class SagePneuma : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Pneuma && IsEnabled(CustomComboPreset.SagePneumaCombo))
        {
            if (level >= SGE.Levels.Zoe && IsCooldownUsable(SGE.Zoe))
                return SGE.Zoe;

            if (level >= SGE.Levels.Pneuma)
                return SGE.Pneuma;

            return SGE.Zoe;
        }

        return actionID;
    }
}
