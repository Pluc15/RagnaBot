using System;
using System.Collections.Generic;

public class MvpInfoDatabase()
{
    public List<MvpInfo> Data = [
        new MvpInfo
        {
            Id = "1511_moc_pryd06",
            MvpName = "Amon Ra",
            Map = "moc_pryd06",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1511
        },
        new MvpInfo
        {
            Id = "1039_prt_maze03",
            MvpName = "Baphomet",
            Map = "prt_maze03",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1039
        },
        new MvpInfo
        {
            Id = "1646_lhz_dun03",
            MvpName = "Bio3 MVP",
            Map = "lhz_dun03",
            RespawnDuration = TimeSpan.FromMinutes(100),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(15),
            RagnarokId = 1646,
            IsHighEnd = true
        },
        new MvpInfo
        {
            Id = "1272_gl_chyard",
            MvpName = "Dark Lord",
            Map = "gl_chyard",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1272
        },
        new MvpInfo
        {
            Id = "1719_abyss_03",
            MvpName = "Detardeurus",
            Map = "abyss_03",
            RespawnDuration = TimeSpan.FromMinutes(180),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(15),
            RagnarokId = 1719
        },
        new MvpInfo
        {
            Id = "1046_gef_dun02",
            MvpName = "Doppelganger",
            Map = "gef_dun02",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1046
        },
        new MvpInfo
        {
            Id = "1389_gef_dun01",
            MvpName = "Dracula",
            Map = "gef_dun01",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1389
        },
        new MvpInfo
        {
            Id = "1112_treasure02",
            MvpName = "Drake",
            Map = "treasure02",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1112
        },
        new MvpInfo
        {
            Id = "1115_pay_fild11",
            MvpName = "Eddga",
            Map = "pay_fild11",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1115
        },
        new MvpInfo
        {
            Id = "1658_lhz_dun02",
            MvpName = "Egnigem Cenia",
            Map = "lhz_dun02",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1658
        },
        new MvpInfo
        {
            Id = "1418_gon_dun03",
            MvpName = "Evil Snake Lord",
            Map = "gon_dun03",
            RespawnDuration = TimeSpan.FromMinutes(94),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1418
        },
        new MvpInfo
        {
            Id = "1252_xmas_fild01",
            MvpName = "Garm",
            Map = "xmas_fild01",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1252
        },
        new MvpInfo
        {
            Id = "1086_prt_sewb4",
            MvpName = "Golden Thief Bug",
            Map = "prt_sewb4",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1086
        },
        new MvpInfo
        {
            Id = "1734_kh_dun02",
            MvpName = "Kiel D-01",
            Map = "kh_dun02",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(60),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1734
        },
        new MvpInfo
        {
            Id = "1688_ayo_dun02",
            MvpName = "Lady Tanee",
            Map = "ayo_dun02",
            RespawnDuration = TimeSpan.FromMinutes(420),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1688
        },
        new MvpInfo
        {
            Id = "1373_niflheim",
            MvpName = "Lord of the Dead",
            Map = "niflheim",
            RespawnDuration = TimeSpan.FromMinutes(133),
            RespawnVariance = TimeSpan.Zero,
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1373
        },
        new MvpInfo
        {
            Id = "1147_anthell02",
            MvpName = "Maya",
            Map = "anthell02",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1147
        },
        new MvpInfo
        {
            Id = "1147_gld_dun03",
            MvpName = "Maya",
            Map = "gld_dun03",
            RespawnDuration = TimeSpan.FromMinutes(480),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1147
        },
        new MvpInfo
        {
            Id = "1059_mjolnir_04",
            MvpName = "Mistress",
            Map = "mjolnir_04",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1059
        },
        new MvpInfo
        {
            Id = "1150_pay_dun04",
            MvpName = "Moonlight Flower",
            Map = "pay_dun04",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1150
        },
        new MvpInfo
        {
            Id = "1087_gef_fild02",
            MvpName = "Orc Hero",
            Map = "gef_fild02",
            RespawnDuration = TimeSpan.FromMinutes(1440),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1087
        },
        new MvpInfo
        {
            Id = "1087_gef_fild14",
            MvpName = "Orc Hero",
            Map = "gef_fild14",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1087
        },
        new MvpInfo
        {
            Id = "1190_gef_fild10",
            MvpName = "Orc Lord",
            Map = "gef_fild10",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1190
        },
        new MvpInfo
        {
            Id = "1038_moc_pryd04",
            MvpName = "Osiris",
            Map = "moc_pryd04",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1038
        },
        new MvpInfo
        {
            Id = "1157_in_sphinx5",
            MvpName = "Pharaoh",
            Map = "in_sphinx5",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1157
        },
        new MvpInfo
        {
            Id = "1159_moc_fild15",
            MvpName = "Phreeoni",
            Map = "moc_fild15",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1159
        },
        new MvpInfo
        {
            Id = "1159_moc_fild17",
            MvpName = "Phreeoni",
            Map = "moc_fild17",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1159
        },
        new MvpInfo
        {
            Id = "1623_ein_dun02",
            MvpName = "RSX-0806",
            Map = "ein_dun02",
            RespawnDuration = TimeSpan.FromMinutes(125),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1623
        },
        new MvpInfo
        {
            Id = "1542_ama_dun03",
            MvpName = "Incantation Samurai",
            Map = "ama_dun03",
            RespawnDuration = TimeSpan.FromMinutes(91),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1542
        },
        new MvpInfo
        {
            Id = "1251_xmas_dun02",
            MvpName = "Stormy Knight",
            Map = "xmas_dun02",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1251
        },
        new MvpInfo
        {
            Id = "1583_beach_dun",
            MvpName = "Tao Gunka",
            Map = "beach_dun",
            RespawnDuration = TimeSpan.FromMinutes(300),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1583
        },
        new MvpInfo
        {
            Id = "1708_thana_boss",
            MvpName = "Thanatos",
            Map = "thana_boss",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(0),
            RespawnReminder = TimeSpan.FromMinutes(40),
            RagnarokId = 1708,
            IsHighEnd = true
        },
        new MvpInfo
        {
            Id = "1312_tur_dun04",
            MvpName = "Turtle General",
            Map = "tur_dun04",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1312
        },
        new MvpInfo
        {
            Id = "1765_odin_tem03",
            MvpName = "Valkyrie Randgris",
            Map = "odin_tem03",
            RespawnDuration = TimeSpan.FromMinutes(480),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(20),
            RagnarokId = 1765,
            IsHighEnd = true
        },
        new MvpInfo
        {
            Id = "1685_jupe_core",
            MvpName = "Vesper",
            Map = "jupe_core",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(20),
            RagnarokId = 1685
        },
        new MvpInfo
        {
            Id = "1630_lou_dun03",
            MvpName = "White Lady",
            Map = "lou_dun03",
            RespawnDuration = TimeSpan.FromMinutes(116),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1630
        },
        new MvpInfo
        {
            Id = "1096_pay_fild04",
            MvpName = "Angeling",
            Map = "pay_fild04",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1096
        },
        new MvpInfo
        {
            Id = "1096_yuno_fild03",
            MvpName = "Angeling",
            Map = "yuno_fild03",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1096
        },
        new MvpInfo
        {
            Id = "1096_xmas_dun01",
            MvpName = "Angeling",
            Map = "xmas_dun01",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1096
        },
        new MvpInfo
        {
            Id = "1582_pay_fild04",
            MvpName = "Deviling",
            Map = "pay_fild04",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(60),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1582
        },
        new MvpInfo
        {
            Id = "1582_yuno_fild03",
            MvpName = "Deviling",
            Map = "yuno_fild03",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1582
        },
        new MvpInfo
        {
            Id = "1091_moc_fild18",
            MvpName = "Dragon Fly",
            Map = "moc_fild18",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1091
        },
        new MvpInfo
        {
            Id = "1120_pay_fild04",
            MvpName = "Ghostring",
            Map = "pay_fild04",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1120
        },
        new MvpInfo
        {
            Id = "1120_prt_maze03",
            MvpName = "Ghostring",
            Map = "prt_maze03",
            RespawnDuration = TimeSpan.FromMinutes(113),
            RespawnVariance = TimeSpan.FromMinutes(57),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1120
        },
        new MvpInfo
        {
            Id = "1120_treasure02",
            MvpName = "Ghostring",
            Map = "treasure02",
            RespawnDuration = TimeSpan.FromMinutes(33),
            RespawnVariance = TimeSpan.FromMinutes(20),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1120
        },
        new MvpInfo
        {
            Id = "1259_cmd_fild08",
            MvpName = "Gryphon",
            Map = "cmd_fild08",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1259
        },
        new MvpInfo
        {
            Id = "1259_um_fild03",
            MvpName = "Gryphon",
            Map = "um_fild03",
            RespawnDuration = TimeSpan.FromMinutes(58),
            RespawnVariance = TimeSpan.FromMinutes(32),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1259
        },
        new MvpInfo
        {
            Id = "1289_anthell01",
            MvpName = "Maya Purple",
            Map = "anthell01",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(60),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1289
        },
        new MvpInfo
        {
            Id = "1289_gld_dun03_1",
            MvpName = "Maya Purple 1",
            Map = "gld_dun03",
            RespawnDuration = TimeSpan.FromMinutes(20),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1289
        },
        new MvpInfo
        {
            Id = "1289_gld_dun03_2",
            MvpName = "Maya Purple 2",
            Map = "gld_dun03",
            RespawnDuration = TimeSpan.FromMinutes(20),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1289
        },
        new MvpInfo
        {
            Id = "1289_gld_dun03_3",
            MvpName = "Maya Purple 3",
            Map = "gld_dun03",
            RespawnDuration = TimeSpan.FromMinutes(20),
            RespawnVariance = TimeSpan.FromMinutes(10),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1289
        },
        new MvpInfo
        {
            Id = "1765_odin_tem02",
            MvpName = "Valkyrie (f2)",
            Map = "odin_tem02",
            RespawnDuration = TimeSpan.FromMinutes(120),
            RespawnVariance = TimeSpan.FromMinutes(0),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1765
        },
        new MvpInfo
        {
            Id = "1765_odin_tem03_1",
            MvpName = "Valkyrie 1",
            Map = "odin_tem03",
            RespawnDuration = TimeSpan.FromMinutes(30),
            RespawnVariance = TimeSpan.FromMinutes(20),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1765
        },
        new MvpInfo
        {
            Id = "1765_odin_tem03_2",
            MvpName = "Valkyrie 2",
            Map = "odin_tem03",
            RespawnDuration = TimeSpan.FromMinutes(30),
            RespawnVariance = TimeSpan.FromMinutes(20),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1765
        },
        new MvpInfo
        {
            Id = "1200_gl_prison1",
            MvpName = "Zealotus",
            Map = "gl_prison1",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1200
        },
        new MvpInfo
        {
            Id = "1720_abyss_03_1",
            MvpName = "Hydrolancer 1",
            Map = "abyss_03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(40),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1720
        },
        new MvpInfo
        {
            Id = "1720_abyss_03_2",
            MvpName = "Hydrolancer 2",
            Map = "abyss_03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(40),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1720
        },
        new MvpInfo
        {
            Id = "1720_abyss_03_3",
            MvpName = "Hydrolancer 3",
            Map = "abyss_03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(40),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1720
        },
        new MvpInfo
        {
            Id = "1704_tha_t08_1",
            MvpName = "Odium 1",
            Map = "tha_t08",
            RespawnDuration = TimeSpan.FromMinutes(30),
            RespawnVariance = TimeSpan.FromMinutes(20),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1704
        },
        new MvpInfo
        {
            Id = "1704_tha_t08_2",
            MvpName = "Odium 2",
            Map = "tha_t08",
            RespawnDuration = TimeSpan.FromMinutes(30),
            RespawnVariance = TimeSpan.FromMinutes(20),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1704
        },
        new MvpInfo
        {
            Id = "1388_yuno_fild05",
            MvpName = "Archangeling",
            Map = "yuno_fild05",
            RespawnDuration = TimeSpan.FromMinutes(60),
            RespawnVariance = TimeSpan.FromMinutes(3),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1388,
        },
        new MvpInfo
        {
            Id = "1631_lou_dun03_1",
            MvpName = "Chun Yi 1",
            Map = "lou_dun03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1631,
        },
        new MvpInfo
        {
            Id = "1631_lou_dun03_2",
            MvpName = "Chun Yi 2",
            Map = "lou_dun03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1631,
        },
        new MvpInfo
        {
            Id = "1631_lou_dun03_3",
            MvpName = "Chun Yi 3",
            Map = "lou_dun03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1631,
        },
        new MvpInfo
        {
            Id = "1631_lou_dun03_4",
            MvpName = "Chun Yi 4",
            Map = "lou_dun03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1631,
        },
        new MvpInfo
        {
            Id = "1631_lou_dun03_5",
            MvpName = "Chun Yi 5",
            Map = "lou_dun03",
            RespawnDuration = TimeSpan.FromMinutes(50),
            RespawnVariance = TimeSpan.FromMinutes(30),
            RespawnReminder = TimeSpan.FromMinutes(5),
            RagnarokId = 1631,
        }
    ];
}
