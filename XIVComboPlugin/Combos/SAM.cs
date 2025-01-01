using System.Linq;
using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class SAM
{
    public const byte JobID = 34;

    public const uint
        // Single target
        Hakaze = 7477,
        Jinpu = 7478,
        Shifu = 7479,
        Yukikaze = 7480,
        Gekko = 7481,
        Kasha = 7482,
        Gyofu = 36963,
        // AoE
        Fuga = 7483,
        Mangetsu = 7484,
        Oka = 7485,
        Fuko = 25780,
        // Iaijutsu and Tsubame
        Iaijutsu = 7867,
        MidareSetsugekka = 7487,
        TenkaGoken = 7488,
        Higanbana = 7489,
        TsubameGaeshi = 16483,
        KaeshiGoken = 16485,
        KaeshiSetsugekka = 16486,
        TendoGoken = 36965,
        TendoSetsugekka = 36966,
        TendoKaeshiGoken = 36967,
        TendoKaeshiSetsugekka = 36968,
        // Misc
        HissatsuShinten = 7490,
        HissatsuKyuten = 7491,
        HissatsuSenei = 16481,
        HissatsuGuren = 7496,
        Ikishoten = 16482,
        Shoha = 16487,
        OgiNamikiri = 25781,
        KaeshiNamikiri = 25782,
        Zanshin = 36964;

    public static class Buffs
    {
        public const ushort
            MeikyoShisui = 1233,
            EyesOpen = 1252,
            Fugetsu = 1298, // From Jinpu and Mangetsu
            Fuka = 1299,    // From Shifu and Oka
            OgiNamikiriReady = 2959,
            ZanshinReady = 3855;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Jinpu = 4,
            Enpi = 15,
            Shifu = 18,
            Fuga = 26,
            Gekko = 30,
            Higanbana = 30,
            Mangetsu = 35,
            Kasha = 40,
            TenkaGoken = 40,
            Oka = 45,
            Yukikaze = 50,
            MeikyoShisui = 50,
            MidareSetsugekka = 50,
            HissatsuShinten = 52,
            HissatsuGyoten = 54,
            HissatsuYaten = 56,
            HissatsuKyuten = 64,
            Ikishoten = 68,
            HissatsuGuren = 70,
            HissatsuSenei = 72,
            TsubameGaeshi = 74,
            Shoha = 80,
            Hyosetsu = 86,
            Fuko = 86,
            OgiNamikiri = 90,
            Zanshin = 96,
            Tendo = 100;
    }
}

internal class SamuraiYukikaze : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiYukikazeCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Yukikaze)
            {
                if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Yukikaze;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Yukikaze)
                    return SAM.Yukikaze;

                return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}

internal class SamuraiGekko : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiGekkoCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Gekko)
            {
                if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Gekko;

                if (lastComboMove == SAM.Jinpu && level >= SAM.Levels.Gekko)
                    return SAM.Gekko;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Jinpu)
                    return SAM.Jinpu;

                return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}

internal class SamuraiKasha : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiKashaCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Kasha)
            {
                if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Kasha;

                if (lastComboMove == SAM.Shifu && level >= SAM.Levels.Kasha)
                    return SAM.Kasha;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Shifu)
                    return SAM.Shifu;

                return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}


internal class SamuraiMangetsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiMangetsuCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Mangetsu)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Mangetsu;
            if ((lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko) && level >= SAM.Levels.Mangetsu)
                return SAM.Mangetsu;

            // Fuko/Fuga
            return OriginalHook(SAM.Fuga);
        }

        return actionID;
    }
}

internal class SamuraiOka : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiOkaCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Oka)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Oka;
            if ((lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko) && level >= SAM.Levels.Oka)
                return SAM.Oka;

            // Fuko/Fuga
            return OriginalHook(SAM.Fuga);
        }

        return actionID;
    }
}

internal class SamuraiIaijutsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiIaijutsuTsubameGaeshiFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Iaijutsu)
        {
            if (level >= SAM.Levels.TsubameGaeshi
                && CanUseAction(OriginalHook(SAM.TsubameGaeshi))
                && (OriginalHook(SAM.Iaijutsu) != SAM.Higanbana)
                )
                return OriginalHook(SAM.TsubameGaeshi);
        }

        return actionID;
    }
}
