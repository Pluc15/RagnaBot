using System;
using System.Collections.Generic;

namespace RagnaBot.Data
{
    public class MvpInfo
    {
        public static readonly List<MvpInfo> Mvps = new()
        {
            new MvpInfo
            {
                Id = "1511_moc_pryd06",
                MvpKeys = new[]
                {
                    "amon",
                    "amonra"
                },
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
                MvpKeys = new[]
                {
                    "bapho",
                    "baphomet"
                },
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
                MvpKeys = new[]
                {
                    "bio3"
                },
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
                MvpKeys = new[]
                {
                    "dl",
                    "darklord"
                },
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
                MvpKeys = new[]
                {
                    "detale",
                    "detardeurus"
                },
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
                MvpKeys = new[]
                {
                    "doppel",
                    "dopple",
                    "doppelganger"
                },
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
                MvpKeys = new[]
                {
                    "drac",
                    "dracula"
                },
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
                MvpKeys = new[]
                {
                    "drake"
                },
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
                MvpKeys = new[]
                {
                    "eddga"
                },
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
                MvpKeys = new[]
                {
                    "bio2",
                    "ygnizem",
                    "egnigem",
                    "egnigem cenia"
                },
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
                MvpKeys = new[]
                {
                    "esl",
                    "evil snake lord"
                },
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
                MvpKeys = new[]
                {
                    "garm",
                    "hati"
                },
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
                MvpKeys = new[]
                {
                    "gtb",
                    "goldenthiefbug"
                },
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
                MvpKeys = new[]
                {
                    "kiel"
                },
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
                MvpKeys = new[]
                {
                    "lt",
                    "tanee",
                    "lady tanee"
                },
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
                MvpKeys = new[]
                {
                    "lod",
                    "lordofdead",
                    "lordofthedead",
                    "lordofdeath"
                },
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
                MvpKeys = new[]
                {
                    "maya"
                },
                MvpName = "Maya",
                Map = "anthell02",
                RespawnDuration = TimeSpan.FromMinutes(120),
                RespawnVariance = TimeSpan.FromMinutes(10),
                RespawnReminder = TimeSpan.FromMinutes(5),
                RagnarokId = 1147
            },
            new MvpInfo
            {
                Id = "1059_mjolnir_04",
                MvpKeys = new[]
                {
                    "missy",
                    "mistress"
                },
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
                MvpKeys = new[]
                {
                    "moony",
                    "moonlight",
                    "moonlightflower"
                },
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
                MvpKeys = new[]
                {
                    "oh2",
                    "orchero2",
                },
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
                MvpKeys = new[]
                {
                    "oh",
                    "orchero"
                },
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
                MvpKeys = new[]
                {
                    "ol",
                    "orclord"
                },
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
                MvpKeys = new[]
                {
                    "osi",
                    "osiris"
                },
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
                MvpKeys = new[]
                {
                    "phara",
                    "pharaoh"
                },
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
                MvpKeys = new[]
                {
                    "phree1",
                    "phreeo1",
                    "phreeoni1",
                    "phree15",
                    "phreeo15",
                    "phreeoni15"
                },
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
                MvpKeys = new[]
                {
                    "phree2",
                    "phreeo2",
                    "phreeoni2",
                    "phree17",
                    "phreeo17",
                    "phreeoni17"
                },
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
                MvpKeys = new[]
                {
                    "rsx",
                    "rsx-0806"
                },
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
                MvpKeys = new[]
                {
                    "samurai",
                    "incantation samurai"
                },
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
                MvpKeys = new[]
                {
                    "sk",
                    "stormy",
                    "stormyknight"
                },
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
                MvpKeys = new[]
                {
                    "tao",
                    "taogunka"
                },
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
                MvpKeys = new[]
                {
                    "tt",
                    "thana",
                    "thanatos"
                },
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
                MvpKeys = new[]
                {
                    "turt",
                    "turtle",
                    "turtlegeneral"
                },
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
                MvpKeys = new[]
                {
                    "vr",
                    "valkyrierandgris",
                    "randgris",
                },
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
                MvpKeys = new[]
                {
                    "vesp",
                    "vesper"
                },
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
                MvpKeys = new[]
                {
                    "wl",
                    "whitelady",
                    "bacso",
                    "Bacsojin"
                },
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
                MvpKeys = new[]
                {
                    "angyporing",
                    "angelingporing"
                },
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
                MvpKeys = new[]
                {
                    "angyjuno",
                    "angyyuno",
                    "angelingjuno",
                    "angelingyuno"
                },
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
                MvpKeys = new[]
                {
                    "angyxmas",
                    "angelingxmas"
                },
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
                MvpKeys = new[]
                {
                    "deviporing",
                    "devilingporing"
                },
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
                MvpKeys = new[]
                {
                    "devijuno",
                    "deviyuno",
                    "devilingjuno",
                    "devilingyuno"
                },
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
                MvpKeys = new[]
                {
                    "df",
                    "dragonfly"
                },
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
                MvpKeys = new[]
                {
                    "grporing",
                    "ghostringporing"
                },
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
                MvpKeys = new[]
                {
                    "grmaze",
                    "ghostringmaze"
                },
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
                MvpKeys = new[]
                {
                    "grsunken",
                    "ghostringsunken"
                },
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
                MvpKeys = new[]
                {
                    "gryphon1"
                },
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
                MvpKeys = new[]
                {
                    "gryphon2"
                },
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
                MvpKeys = new[]
                {
                    "mp",
                    "mayap",
                    "mayapurple"
                },
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
                MvpKeys = new[]
                {
                    "mpgd1",
                    "mayapgd1",
                    "mayapurplegd1"
                },
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
                MvpKeys = new[]
                {
                    "mpgd2",
                    "mayapgd2",
                    "mayapurplegd2"
                },
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
                MvpKeys = new[]
                {
                    "mpgd3",
                    "mayapgd3",
                    "mayapurplegd3"
                },
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
                MvpKeys = new[]
                {
                    "valkf2",
                    "valkyrief2"
                },
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
                MvpKeys = new[]
                {
                    "valk1",
                    "valkyrie1"
                },
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
                MvpKeys = new[]
                {
                    "valk2",
                    "valkyrie2"
                },
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
                MvpKeys = new[]
                {
                    "zea",
                    "zealotus"
                },
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
                MvpKeys = new[]
                {
                    "hydro1",
                    "hydrolancer1"
                },
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
                MvpKeys = new[]
                {
                    "hydro2",
                    "hydrolancer2"
                },
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
                MvpKeys = new[]
                {
                    "hydro3",
                    "hydrolancer3"
                },
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
                MvpKeys = new[]
                {
                    "odium1",
                    "panda1"
                },
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
                MvpKeys = new[]
                {
                    "odium2",
                    "panda2"
                },
                MvpName = "Odium 2",
                Map = "tha_t08",
                RespawnDuration = TimeSpan.FromMinutes(30),
                RespawnVariance = TimeSpan.FromMinutes(20),
                RespawnReminder = TimeSpan.FromMinutes(5),
                RagnarokId = 1704
            }
        };

        public bool IsHighEnd { get; set; } = false;

        public string Id { get; set; }

        public string[] MvpKeys { get; set; }

        public string MvpName { get; set; }

        public string Map { get; set; }

        public int RagnarokId { get; set; }

        public TimeSpan RespawnDuration { get; set; }

        public TimeSpan RespawnVariance { get; set; }

        public TimeSpan RespawnReminder { get; set; }
    }
}