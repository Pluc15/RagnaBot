using System;

namespace RagnaBot.Data
{
    public static class Seed
    {
        public static void Init(
            Model model
        )
        {
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "amon",
                        "amonra"
                    },
                    MvpName = "Amon Ra",
                    Map = "moc_pryd06",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1511
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "bapho",
                        "baphomet"
                    },
                    MvpName = "Baphomet",
                    Map = "prt_maze03",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1039
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "bio3"
                    },
                    MvpName = "Bio3 MVP",
                    Map = "lhz_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(100),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 100),
                    RespawnReminder = TimeSpan.FromMinutes(15),
                    RagnarokId = 1646
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "dl",
                        "darklord"
                    },
                    MvpName = "Dark Lord",
                    Map = "gl_chyard",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1272
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "detale",
                        "detardeurus"
                    },
                    MvpName = "Detardeurus",
                    Map = "abyss_03",
                    RespawnDuration = TimeSpan.FromMinutes(180),
                    RespawnVariance = TimeSpan.FromMinutes(190 - 180),
                    RespawnReminder = TimeSpan.FromMinutes(15),
                    RagnarokId = 1719
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "doppel",
                        "doppelganger"
                    },
                    MvpName = "Doppelganger",
                    Map = "gef_dun02",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1046
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "drac",
                        "dracula"
                    },
                    MvpName = "Dracula",
                    Map = "gef_dun01",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1389
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "drake"
                    },
                    MvpName = "Drake",
                    Map = "treasure02",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1112
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "eddga"
                    },
                    MvpName = "Eddga",
                    Map = "pay_fild11",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1115
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "bio2",
                        "egnigem",
                        "egnigem cenia"
                    },
                    MvpName = "Egnigem Cenia",
                    Map = "lhz_dun02",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1658
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "esl",
                        "evil snake lord"
                    },
                    MvpName = "Evil Snake Lord",
                    Map = "gon_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(94),
                    RespawnVariance = TimeSpan.FromMinutes(104 - 94),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1418
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "garm"
                    },
                    MvpName = "Garm",
                    Map = "xmas_fild01",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1252
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "gtb",
                        "goldenthiefbug"
                    },
                    MvpName = "Golden Thief Bug",
                    Map = "prt_sewb4",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1086
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "kiel"
                    },
                    MvpName = "Kiel D-01",
                    Map = "kh_dun02",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(180 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1734
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "lt",
                        "tanee",
                        "lady tanee"
                    },
                    MvpName = "Lady Tanee",
                    Map = "ayo_dun02",
                    RespawnDuration = TimeSpan.FromMinutes(420),
                    RespawnVariance = TimeSpan.FromMinutes(430 - 420),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1688
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "lod",
                        "lord of the dead"
                    },
                    MvpName = "Lord of the Dead",
                    Map = "niflheim",
                    RespawnDuration = TimeSpan.FromMinutes(133),
                    RespawnVariance = TimeSpan.Zero,
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1373
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "maya"
                    },
                    MvpName = "Maya",
                    Map = "anthell02",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1147
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "missy",
                        "mistress"
                    },
                    MvpName = "Mistress",
                    Map = "mjolnir_04",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1059
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "moony",
                        "moonlight",
                        "moonlightflower"
                    },
                    MvpName = "Moonlight Flower",
                    Map = "pay_dun04",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1150
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 1,
                    MvpKeys = new[]
                    {
                        "oh2",
                        "orchero2"
                    },
                    MvpName = "Orc Hero",
                    Map = "gef_fild02",
                    RespawnDuration = TimeSpan.FromMinutes(1440),
                    RespawnVariance = TimeSpan.FromMinutes(1450 - 1440),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1087
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "oh",
                        "orchero"
                    },
                    MvpName = "Orc Hero",
                    Map = "gef_fild14",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1087
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "ol",
                        "orclord"
                    },
                    MvpName = "Orc Lord",
                    Map = "gef_fild10",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1190
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
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
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "phara",
                        "pharaoh"
                    },
                    MvpName = "Pharaoh",
                    Map = "in_sphinx5",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1157
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "phree1",
                        "phreeo1",
                        "phreeoni1"
                    },
                    MvpName = "Phreeoni",
                    Map = "moc_fild15",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1159
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "phree2",
                        "phreeo2",
                        "phreeoni2"
                    },
                    MvpName = "Phreeoni",
                    Map = "moc_fild17",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1159
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "rsx",
                        "rsx-0806"
                    },
                    MvpName = "RSX-0806",
                    Map = "ein_dun02",
                    RespawnDuration = TimeSpan.FromMinutes(125),
                    RespawnVariance = TimeSpan.FromMinutes(135 - 125),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1623
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "samurai",
                        "incantation samurai"
                    },
                    MvpName = "Incantation Samurai",
                    Map = "ama_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(91),
                    RespawnVariance = TimeSpan.FromMinutes(101 - 91),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1542
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "stormy",
                        "stormyknight"
                    },
                    MvpName = "Stormy Knight",
                    Map = "xmas_dun02",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1251
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "tao",
                        "taogunka"
                    },
                    MvpName = "Tao Gunka",
                    Map = "beach_dun",
                    RespawnDuration = TimeSpan.FromMinutes(300),
                    RespawnVariance = TimeSpan.FromMinutes(310 - 300),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1583
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "thana",
                        "thanatos"
                    },
                    MvpName = "Thanatos",
                    Map = "thana_boss",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(120 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(40),
                    RagnarokId = 1708
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "turt",
                        "turtle",
                        "turtlegeneral"
                    },
                    MvpName = "Turtle General",
                    Map = "tur_dun04",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(70 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1312
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "vr",
                        "valkyrierandgris"
                    },
                    MvpName = "Valkyrie Randgris",
                    Map = "odin_tem03",
                    RespawnDuration = TimeSpan.FromMinutes(480),
                    RespawnVariance = TimeSpan.FromMinutes(840 - 480),
                    RespawnReminder = TimeSpan.FromMinutes(20),
                    RagnarokId = 1765
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "vesp",
                        "vesper"
                    },
                    MvpName = "Vesper",
                    Map = "jupe_core",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(130 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(20),
                    RagnarokId = 1685
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 2,
                    MvpKeys = new[]
                    {
                        "wl",
                        "whitelady"
                    },
                    MvpName = "White Lady",
                    Map = "lou_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(116),
                    RespawnVariance = TimeSpan.FromMinutes(126 - 116),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1630
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "angyporing",
                        "angelingporing"
                    },
                    MvpName = "Angeling",
                    Map = "pay_fild04",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1096
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
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
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1096
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "angyxmas",
                        "angelingxmas"
                    },
                    MvpName = "Angeling",
                    Map = "xmas_dun01",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1096
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "deviporing",
                        "devilingporing"
                    },
                    MvpName = "Deviling",
                    Map = "pay_fild04",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(180 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1582
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
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
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1582
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "df",
                        "dragonfly"
                    },
                    MvpName = "Dragon Fly",
                    Map = "moc_fild18",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1091
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "grporing",
                        "ghostringporing"
                    },
                    MvpName = "Ghostring",
                    Map = "pay_fild04",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1120
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "grmaze",
                        "ghostringmaze"
                    },
                    MvpName = "Ghostring",
                    Map = "prt_maze03",
                    RespawnDuration = TimeSpan.FromMinutes(113),
                    RespawnVariance = TimeSpan.FromMinutes(170 - 113),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1120
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "grsunken",
                        "ghostringsunken"
                    },
                    MvpName = "Ghostring",
                    Map = "treasure02",
                    RespawnDuration = TimeSpan.FromMinutes(33),
                    RespawnVariance = TimeSpan.FromMinutes(53 - 33),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1120
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "gryphon1"
                    },
                    MvpName = "Gryphon",
                    Map = "cmd_fild08",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1259
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "gryphon2"
                    },
                    MvpName = "Gryphon",
                    Map = "um_fild03",
                    RespawnDuration = TimeSpan.FromMinutes(58),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 58),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1259
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "mayap",
                        "mayapurple"
                    },
                    MvpName = "Maya Purple",
                    Map = "anthell01",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(180 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1289
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "mayapgd1",
                        "mayapurplegd1"
                    },
                    MvpName = "Maya Purple",
                    Map = "gld_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(20),
                    RespawnVariance = TimeSpan.FromMinutes(30 - 20),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1289
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "mayapgd2",
                        "mayapurplegd2"
                    },
                    MvpName = "Maya Purple",
                    Map = "gld_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(20),
                    RespawnVariance = TimeSpan.FromMinutes(30 - 20),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1289
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "mayapgd3",
                        "mayapurplegd3"
                    },
                    MvpName = "Maya Purple",
                    Map = "gld_dun03",
                    RespawnDuration = TimeSpan.FromMinutes(20),
                    RespawnVariance = TimeSpan.FromMinutes(30 - 20),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1289
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "valkf2",
                        "valkyrief2"
                    },
                    MvpName = "Valkyrie",
                    Map = "odin_tem02",
                    RespawnDuration = TimeSpan.FromMinutes(120),
                    RespawnVariance = TimeSpan.FromMinutes(120 - 120),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1765
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "valk1",
                        "valkyrie1"
                    },
                    MvpName = "Valkyrie",
                    Map = "odin_tem03",
                    RespawnDuration = TimeSpan.FromMinutes(30),
                    RespawnVariance = TimeSpan.FromMinutes(50 - 30),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1765
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "valk2",
                        "valkyrie2"
                    },
                    MvpName = "Valkyrie",
                    Map = "odin_tem03",
                    RespawnDuration = TimeSpan.FromMinutes(30),
                    RespawnVariance = TimeSpan.FromMinutes(50 - 30),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1765
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 3,
                    MvpKeys = new[]
                    {
                        "zea",
                        "zealotus"
                    },
                    MvpName = "Zealotus",
                    Map = "gl_prison1",
                    RespawnDuration = TimeSpan.FromMinutes(60),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 60),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1200
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 4,
                    MvpKeys = new[]
                    {
                        "hydro1",
                        "hydrolancer1"
                    },
                    MvpName = "Hydrolancer",
                    Map = "abyss_03",
                    RespawnDuration = TimeSpan.FromMinutes(50),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 50),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1720
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 4,
                    MvpKeys = new[]
                    {
                        "hydro2",
                        "hydrolancer2"
                    },
                    MvpName = "Hydrolancer",
                    Map = "abyss_03",
                    RespawnDuration = TimeSpan.FromMinutes(50),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 50),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1720
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 4,
                    MvpKeys = new[]
                    {
                        "hydro3",
                        "hydrolancer3"
                    },
                    MvpName = "Hydrolancer",
                    Map = "abyss_03",
                    RespawnDuration = TimeSpan.FromMinutes(50),
                    RespawnVariance = TimeSpan.FromMinutes(90 - 50),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1720
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 4,
                    MvpKeys = new[]
                    {
                        "odium1",
                        "panda1"
                    },
                    MvpName = "Odium",
                    Map = "tha_t08",
                    RespawnDuration = TimeSpan.FromMinutes(30),
                    RespawnVariance = TimeSpan.FromMinutes(50 - 30),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1704
                }
            );
            model.Timers.Add(
                new Timer
                {
                    Page = 4,
                    MvpKeys = new[]
                    {
                        "odium2",
                        "panda2"
                    },
                    MvpName = "Odium",
                    Map = "tha_t08",
                    RespawnDuration = TimeSpan.FromMinutes(30),
                    RespawnVariance = TimeSpan.FromMinutes(50 - 30),
                    RespawnReminder = TimeSpan.FromMinutes(5),
                    RagnarokId = 1704
                }
            );
        }
    }
}