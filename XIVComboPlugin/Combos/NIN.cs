namespace XIVCombo.Combos;

internal static class NIN
{
    public const byte ClassID = 29;
    public const byte JobID = 30;

    public const uint
        SpinningEdge = 2240,
        GustSlash = 2242,
        Assassinate = 2246,
        Mug = 2248,
        DeathBlossom = 2254,
        AeolianEdge = 2255,
        TrickAttack = 2258,
        Ninjutsu = 2260,
        Kassatsu = 2264,
        ArmorCrush = 3563,
        HellfrogMedium = 7401,
        Bhavacakra = 7402,
        TenChiJin = 7403,
        HakkeMujinsatsu = 16488,
        Meisui = 16489,
        Bunshin = 16493,
        PhantomKamaitachi = 25774,
        ForkedRaiju = 25777,
        FleetingRaiju = 25778,
        Dokumori = 36957,
        KunaisBane = 36958,
        TenriJindo = 36961;

    public static class Buffs
    {
        public const ushort
            Mudra = 496,
            Hidden = 614,
            RaijuReady = 2690,
            PhantomKamaitachiReady = 2723,
            ShadowWalker = 3848,
            TenriJindoReady = 3851;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            GustSlash = 4,
            Hide = 10,
            Mug = 15,
            TrickAttack = 18,
            AeolianEdge = 26,
            Ninjutsu = 30,
            Assassinate = 40,
            Suiton = 45,
            Kassatsu = 50,
            HakkeMujinsatsu = 52,
            ArmorCrush = 54,
            TenChiJin = 70,
            Meisui = 72,
            Bunshin = 80,
            PhantomKamaitachi = 82,
            Raiju = 90,
            TenriJindo = 100;
    }
}

internal class NinjaAeolianEdge : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.AeolianEdge && IsEnabled(CustomComboPreset.NinjaAeolianEdgeCombo))
        {
            if (level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                return OriginalHook(NIN.Ninjutsu);

            if (level >= NIN.Levels.Raiju && HasEffect(NIN.Buffs.RaijuReady))
                return NIN.FleetingRaiju;

            if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.AeolianEdge)
                return NIN.AeolianEdge;

            if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
                return NIN.GustSlash;

            return NIN.SpinningEdge;
        }

        return actionID;
    }
}

internal class NinjaArmorCrush : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.ArmorCrush && IsEnabled(CustomComboPreset.NinjaArmorCrushCombo))
        {
            if (level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                return OriginalHook(NIN.Ninjutsu);

            if (level >= NIN.Levels.Raiju && HasEffect(NIN.Buffs.RaijuReady))
                return NIN.ForkedRaiju;

            if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.ArmorCrush)
                return NIN.ArmorCrush;

            if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
                return NIN.GustSlash;

            return NIN.SpinningEdge;
        }

        return actionID;
    }
}

internal class NinjaHakkeMujinsatsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.HakkeMujinsatsu && IsEnabled(CustomComboPreset.NinjaHakkeMujinsatsuCombo))
        {
            if (level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                return OriginalHook(NIN.Ninjutsu);

            if (level >= NIN.Levels.PhantomKamaitachi && HasEffect(NIN.Buffs.PhantomKamaitachiReady))
                return NIN.PhantomKamaitachi;

            if (lastComboMove == NIN.DeathBlossom && level >= NIN.Levels.HakkeMujinsatsu)
                return NIN.HakkeMujinsatsu;

            return NIN.DeathBlossom;
        }

        return actionID;
    }
}

internal class NinjaBhavacakra : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.Bhavacakra && IsEnabled(CustomComboPreset.NinjaBhavacakraCombo))
        {
            if (level >= NIN.Levels.Bunshin && IsCooldownUsable(NIN.Bunshin))
                return NIN.Bunshin;

            return NIN.Bhavacakra;
        }

        return actionID;
    }
}

internal class NinjaHellfrogMedium : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.HellfrogMedium && IsEnabled(CustomComboPreset.NinjaHellfrogMediumCombo))
        {
            if (level >= NIN.Levels.Bunshin && IsCooldownUsable(NIN.Bunshin))
                return NIN.Bunshin;

            return NIN.HellfrogMedium;
        }

        return actionID;
    }
}

internal class NinjaMug : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == NIN.Mug || actionID == NIN.Dokumori) && IsEnabled(CustomComboPreset.NinjaMugCombo))
        {
            if (level >= NIN.Levels.Mug && IsCooldownUsable(OriginalHook(NIN.Mug)))
                return OriginalHook(NIN.Mug);

            if (level >= NIN.Levels.TenChiJin && IsCooldownUsable(NIN.TenChiJin))
                return NIN.TenChiJin;

            if (level >= NIN.Levels.Meisui && IsCooldownUsable(NIN.Meisui) && HasEffect(NIN.Buffs.ShadowWalker))
                return NIN.Meisui;

            if (level >= NIN.Levels.TenriJindo && HasEffect(NIN.Buffs.TenriJindoReady))
                return OriginalHook(NIN.TenChiJin);

            if (level >= NIN.Levels.Meisui && IsCooldownUsable(NIN.Meisui))
                return NIN.Meisui;

            return OriginalHook(NIN.Mug);
        }

        return actionID;
    }
}

internal class NinjaTrickAttack : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == NIN.TrickAttack || actionID == NIN.KunaisBane) && IsEnabled(CustomComboPreset.NinjaTrickAttackCombo))
        {
            if (level >= NIN.Levels.Kassatsu && IsCooldownUsable(NIN.Kassatsu))
                return NIN.Kassatsu;

            if (level >= NIN.Levels.TrickAttack && IsCooldownUsable(OriginalHook(NIN.TrickAttack)) &&
                ((level >= NIN.Levels.Hide && HasEffect(NIN.Buffs.Hidden)) ||
                (level >= NIN.Levels.Suiton && HasEffect(NIN.Buffs.ShadowWalker))))
                return OriginalHook(NIN.TrickAttack);

            if (level >= NIN.Levels.Assassinate && IsCooldownUsable(OriginalHook(NIN.Assassinate)))
                return OriginalHook(NIN.Assassinate);

            if (level >= NIN.Levels.TrickAttack && IsCooldownUsable(OriginalHook(NIN.TrickAttack)))
                return OriginalHook(NIN.TrickAttack);

            if (level >= NIN.Levels.Kassatsu)
                return NIN.Kassatsu;

            return OriginalHook(NIN.TrickAttack);
        }

        return actionID;
    }
}
