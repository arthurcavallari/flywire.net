﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
namespace Flywire_WinForm
{

    public static class Settings
    {
        public static char slash = System.IO.Path.DirectorySeparatorChar;
        public static string StartUpDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string AutoMediaPath { get { return StartUpDirectory + slash + @"AutoMedia" + slash + "MUSIC" + slash; } }
        public static string ShowMediaPath { get { return StartUpDirectory + slash + @"ShowMedia" + slash; } }
        public static string StationMediaPath { get { return StartUpDirectory + slash + @"StationMedia" + slash; } }
        public static string ScheduledMediaPath { get { return StartUpDirectory + slash + @"ScheduledMedia" + slash; } }
        public static string SchedulePath { get { return StartUpDirectory + slash + @"Schedule" + slash; } }
        public static string LogPath { get { return StartUpDirectory + slash + @"Log" + slash; } }
        //public static string PluginsPath { get { return StartUpDirectory + @"\AutoMedia\Plugins\"; } }

        public static string[] IgnoredFiles
        {
            get
            {
                return new string[]
                {
                    "Thumbs.db"
                };
            }
        }
        public static string[] AcceptedFiles 
        { 
            get 
            { 
                
                return new string[] { 
                    ".mp2", 
                    ".mp3", 
                    ".wav", 
                    ".fla", 
                    ".flac", 
                    ".aac", 
                    ".ogg",
                    ".wma",
                    //".m4a",
                    ".mod",
                    ".it",
                    ".xm",
                    ".s3d",
                    ".s3m"
                    //".acc"
                }; 
            }
        } // end AcceptedFiles

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        public static void checkPaths()
        {
            if (!Directory.Exists(Settings.AutoMediaPath)) Directory.CreateDirectory(Settings.AutoMediaPath);
            if (!Directory.Exists(Settings.ShowMediaPath)) Directory.CreateDirectory(Settings.ShowMediaPath);
            if (!Directory.Exists(Settings.StationMediaPath)) Directory.CreateDirectory(Settings.StationMediaPath);
            if (!Directory.Exists(Settings.ScheduledMediaPath)) Directory.CreateDirectory(Settings.ScheduledMediaPath);
            if (!Directory.Exists(Settings.SchedulePath)) Directory.CreateDirectory(Settings.SchedulePath);
            if (!Directory.Exists(Settings.LogPath)) Directory.CreateDirectory(Settings.LogPath);
        }
    }
}
