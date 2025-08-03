using XIVCombo.Attributes;
using XIVCombo.Combos;

using UTL = XIVCombo.Attributes.IconsComboAttribute;

namespace XIVCombo;

/// <summary>
/// Combo presets.
/// </summary>
public enum CustomComboPreset
{
    // ====================================================================================
    #region MISC

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", ADV.JobID)]
    AdvAny = 0,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", AST.JobID)]
    AstAny = AdvAny + AST.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BLM.JobID)]
    BlmAny = AdvAny + BLM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BRD.JobID)]
    BrdAny = AdvAny + BRD.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DNC.JobID)]
    DncAny = AdvAny + DNC.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOH.JobID)]
    DohAny = AdvAny + DOH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOL.JobID)]
    DolAny = AdvAny + DOL.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRG.JobID)]
    DrgAny = AdvAny + DRG.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRK.JobID)]
    DrkAny = AdvAny + DRK.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", GNB.JobID)]
    GnbAny = AdvAny + GNB.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MCH.JobID)]
    MchAny = AdvAny + MCH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MNK.JobID)]
    MnkAny = AdvAny + MNK.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", NIN.JobID)]
    NinAny = AdvAny + NIN.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PLD.JobID)]
    PldAny = AdvAny + PLD.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PCT.JobID)]
    PctAny = AdvAny + PCT.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RDM.JobID)]
    RdmAny = AdvAny + RDM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RPR.JobID)]
    RprAny = AdvAny + RPR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SAM.JobID)]
    SamAny = AdvAny + SAM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SCH.JobID)]
    SchAny = AdvAny + SCH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SGE.JobID)]
    SgeAny = AdvAny + SGE.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SMN.JobID)]
    SmnAny = AdvAny + SMN.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", VPR.JobID)]
    VprAny = AdvAny + VPR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WAR.JobID)]
    WarAny = AdvAny + WAR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WHM.JobID)]
    WhmAny = AdvAny + WHM.JobID,

    [CustomComboInfo("Disabled", "This should not be used.", ADV.JobID)]
    Disabled = 99999,

    #endregion
    // ====================================================================================
    #region ADV

    #endregion
    // ====================================================================================
    #region ASTROLOGIAN

    #endregion
    // ====================================================================================
    #region BLACK MAGE

    #endregion
    // ====================================================================================
    #region BARD

    [IconsCombo([BRD.StraightShot, UTL.ArrowLeft, BRD.HeavyShot, UTL.Blank, BRD.Buffs.HawksEye, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Heavy Shot into Straight Shot", "Replace Heavy Shot with Straight Shot/Refulgent Arrow when available.", BRD.JobID)]
    BardStraightShotUpgradeFeature = 2302,

    [IconsCombo([BRD.QuickNock, UTL.ArrowLeft, BRD.WideVolley, UTL.Blank, BRD.Buffs.HawksEye, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Quick Nock into Wide Volley/Shadowbite", "Replace Quick Nock with Wide Volley/Shadowbite when available.", BRD.JobID)]
    BardShadowbiteFeature = 2305,

    #endregion
    // ====================================================================================
    #region DANCER

    #endregion
    // ====================================================================================
    #region DARK KNIGHT

    #endregion
    // ====================================================================================
    #region DRAGOON

    #endregion
    // ====================================================================================
    #region GUNBREAKER

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.SolidBarrel, UTL.ArrowLeft, GNB.BrutalShell, UTL.ArrowLeft, GNB.KeenEdge])]
    [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
    GunbreakerSolidBarrelCombo = 3701,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.GnashingFang, UTL.ArrowLeft, GNB.BurstStrike])]
    [CustomComboInfo("Burst Strike to Gnashing Fang", "Replace Burst Strike with Gnashing Fang when off cooldown. Prioritize Continuation.", GNB.JobID)]
    GunbreakerGnashingFangCombo = 3702,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.DemonSlaughter, UTL.ArrowLeft, GNB.DemonSlice])]
    [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
    GunbreakerDemonSlaughterCombo = 3703,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.DoubleDown, UTL.ArrowLeft, GNB.FatedCircle])]
    [CustomComboInfo("Fated Circle to Double Down", "Replace Fated Circle with Double Down when off cooldown. Prioritize Continuation.", GNB.JobID)]
    GunbreakerDoubleDownCombo = 3704,

    [SectionCombo("Cooldown")]
    [IconsCombo([GNB.RoyalGuard, UTL.ArrowLeft, ADV.Provoke])]
    [CustomComboInfo("Provoke to Royal Guard", "Replace Provoke with Royal Guard when inactive.", GNB.JobID)]
    GunbreakerProvokeCombo = 3705,

    [SectionCombo("Cooldown")]
    [IconsCombo([GNB.RoyalGuardRemoval, UTL.ArrowLeft, ADV.Shirk])]
    [CustomComboInfo("Shirk to Release Royal Guard", "Replace Shirk with Release Royal Guard when active.", GNB.JobID)]
    GunbreakerShirkCombo = 3706,

    #endregion
    // ====================================================================================
    #region MACHINIST

    #endregion
    // ====================================================================================
    #region MONK

    #endregion
    // ====================================================================================
    #region NINJA

    [IconsCombo([NIN.Ninjutsu, UTL.ArrowLeft, NIN.FleetingRaiju, UTL.ArrowLeft, NIN.AeolianEdge, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain. Prioritize Ninjutsu and Fleeting Raiju.", NIN.JobID)]
    NinjaAeolianEdgeCombo = 3001,

    [IconsCombo([NIN.Ninjutsu, UTL.ArrowLeft, NIN.ForkedRaiju, UTL.ArrowLeft, NIN.ArmorCrush, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain. Prioritize Ninjutsu and Forked Raiju.", NIN.JobID)]
    NinjaArmorCrushCombo = 3002,

    [IconsCombo([NIN.Ninjutsu, UTL.ArrowLeft, NIN.PhantomKamaitachi, UTL.ArrowLeft, NIN.HakkeMujinsatsu, UTL.ArrowLeft, NIN.DeathBlossom])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain. Prioritize Ninjutsu and Phantom Kamaitachi.", NIN.JobID)]
    NinjaHakkeMujinsatsuCombo = 3003,

    [IconsCombo([NIN.Bunshin, UTL.ArrowLeft, NIN.Bhavacakra])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Bhavacakra to Bunshin", "Replace Bhavacakra with Bunshin when off cooldown.", NIN.JobID)]
    NinjaBhavacakraCombo = 3004,

    [IconsCombo([NIN.Bunshin, UTL.ArrowLeft, NIN.HellfrogMedium])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Hellfrog Medium to Bunshin", "Replace Hellfrog Medium with Bunshin when off cooldown.", NIN.JobID)]
    NinjaHellfrogMediumCombo = 3005,

    [IconsCombo([NIN.Mug, UTL.ArrowLeft, NIN.TenChiJin, UTL.ArrowLeft, NIN.Meisui, UTL.ArrowLeft, NIN.TenriJindo])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Mug to Ten Chi Jin to Meisui", "Replace Mug with Ten Chi Jin and Meisui when on cooldown.", NIN.JobID)]
    NinjaMugCombo = 3006,

    [IconsCombo([NIN.Kassatsu, UTL.ArrowLeft, NIN.TrickAttack, UTL.ArrowLeft, NIN.Assassinate])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Kassatsu to Trick Attack to Assassinate", "Replace Trick Attack with Kassatsu and Assassinate when on cooldown. Prioritize Kassatsu.", NIN.JobID)]
    NinjaTrickAttackCombo = 3007,

    #endregion
    // ====================================================================================
    #region PALADIN

    #endregion
    // ====================================================================================
    #region PICTOMANCER

    #endregion
    // ====================================================================================
    #region REAPER

    #endregion
    // ====================================================================================
    #region RED MAGE
    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Jolt, UTL.Blank, RDM.Buffs.VerstoneReady, RDM.Buffs.VerfireReady, UTL.Cross])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Verstone/Verfire Feature", "Replace Verstone/Verfire with Jolt when no proc is available.", RDM.JobID)]
    RedMageVerprocFeature = 3504,

    [IconsCombo([RDM.Veraero2, RDM.Verthunder2, UTL.ArrowLeft, RDM.Impact, UTL.Blank, RDM.Buffs.Acceleration, ADV.Swiftcast, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("AoE Combo", "Replace Veraero/Verthunder 2 with Impact when various instant-cast effects are active.", RDM.JobID)]
    RedMageAoEFeature = 3501,

    [IconsCombo([RDM.EnchantedRedoublement, RDM.Redoublement, UTL.ArrowLeft, RDM.EnchantedZwerchhau, RDM.Zwerchhau, UTL.ArrowLeft, RDM.EnchantedRiposte, RDM.Riposte])]
    [SectionCombo("Melee features")]
    [CustomComboInfo("Melee Combo", "Replace Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
    RedMageMeleeCombo = 3502,

    #endregion
    // ====================================================================================
    #region SAGE

    [IconsCombo([SGE.Kerachole, UTL.ArrowLeft, SGE.Ixochole, UTL.ArrowLeft, SGE.Rhizomata])]
    [SectionCombo("Addersgall")]
    [CustomComboInfo("Kerachole to Ixochole", "Replace Kerachole with Ixochole when on cooldown and Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageKeracholeCombo = 4001,

    [IconsCombo([SGE.Taurochole, UTL.ArrowLeft, SGE.Druochole, UTL.ArrowLeft, SGE.Rhizomata])]
    [SectionCombo("Addersgall")]
    [CustomComboInfo("Taurochole to Druochole", "Replace Taurochole with Druochole when on cooldown and Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageTaurocholeCombo = 4002,

    [IconsCombo([SGE.Toxikon, UTL.ArrowLeft, SGE.Dosis])]
    [SectionCombo("Addersting")]
    [CustomComboInfo("Dosis to Toxikon", "Replace Dosis with Toxikon when moving and Addersting is not empty.", SGE.JobID)]
    SageDosisCombo = 4003,

    [IconsCombo([SGE.Pepsis, UTL.ArrowLeft, SGE.Diagnosis])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Diagnosis to Pepsis", "Replace Diagnosis with Pepsis when Eukrasian Diagnosis is on target or self.", SGE.JobID)]
    SageDiagnosisCombo = 4004,

    [IconsCombo([SGE.Pepsis, UTL.ArrowLeft, SGE.Prognosis])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Prognosis to Pepsis", "Replace Prognosis with Pepsis when Eukrasian Prognosis is on target or self.", SGE.JobID)]
    SagePrognosisCombo = 4005,

    [IconsCombo([ADV.Swiftcast, UTL.ArrowLeft, SGE.Egeiro])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Egeiro to Swiftcast", "Replace Egeiro with Swiftcast when off cooldown.", SGE.JobID)]
    SageEgeiroCombo = 4006,

    [IconsCombo([SGE.Soteria, UTL.ArrowLeft, SGE.Kardia])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Kardia to Soteria", "Replace Kardia with Soteria when off cooldown and Kardia is applied.", SGE.JobID)]
    SageKardiaCombo = 4007,

    [IconsCombo([SGE.Psyche, UTL.ArrowLeft, SGE.Phlegma])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Phlegma to Psyche", "Replace Phlegma with Psyche when off cooldown.", SGE.JobID)]
    SagePhlegmaCombo = 4008,

    [IconsCombo([SGE.Zoe, UTL.ArrowLeft, SGE.Pneuma])]
    [SectionCombo("Cooldown")]
    [CustomComboInfo("Pneuma to Zoe", "Replace Pneuma with Zoe when off cooldown.", SGE.JobID)]
    SagePneumaCombo = 4009,

    #endregion
    // ====================================================================================
    #region SAMURAI

    #endregion
    // ====================================================================================
    #region SCHOLAR

    #endregion
    // ====================================================================================
    #region SUMMONER

    #endregion
    // ====================================================================================
    #region VIPER

    #endregion
    // ====================================================================================
    #region WARRIOR

    #endregion
    // ====================================================================================
    #region WHITE MAGE

    #endregion
    // ====================================================================================
    #region DOH

    #endregion
    // ====================================================================================
    #region DOL

    [SectionCombo("Miscellaneous")]
    [IconsCombo([DOL.BtnWiseToTheWorld, UTL.ArrowLeft, DOL.AgelessWords])]
    [CustomComboInfo("Ageless Words to Wise to the World", "Replace Ageless Words with Wise to the World when available.", DOL.JobID)]
    DOLAgelessWordsCombo = 51001,

    [SectionCombo("Miscellaneous")]
    [IconsCombo([DOL.MinWiseToTheWorld, UTL.ArrowLeft, DOL.SolidReason])]
    [CustomComboInfo("Solid Reason to Wise to the World", "Replace Solid Reason with Wise to the World when available.", DOL.JobID)]
    DOLSolidReasonCombo = 51002,

    #endregion
    // ====================================================================================
}
