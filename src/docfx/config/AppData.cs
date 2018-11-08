// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;

namespace Microsoft.Docs.Build
{
    internal static class AppData
    {
        public static readonly string AppDataDir = GetAppDataDir();

        public static string GitRestoreDir => Path.Combine(AppDataDir, "git");

        public static string UrlRestoreDir => Path.Combine(AppDataDir, "url");

        public static string MutexDir => Path.Combine(AppDataDir, "mutex");

        public static string CacheDir => Path.Combine(AppDataDir, "cache");

        public static string GlobalConfigPath => GetGlobalConfigPath();

        /// <summary>
        /// Get the global configuration path, default is under <see cref="AppDataDir"/>
        /// </summary>
        private static string GetGlobalConfigPath()
        {
            var docfxGlobalConfig = Environment.GetEnvironmentVariable("DOCFX_GLOBAL_CONFIG_PATH");
            Config.TryGetConfigPath(AppDataDir, out string configPath, out string configFile);
            return string.IsNullOrEmpty(docfxGlobalConfig) ? configPath : Path.GetFullPath(docfxGlobalConfig);
        }

        /// <summary>
        /// Get the application cache root dir, default is under user proflie dir.
        /// User can set the DOCFX_APPDATA_PATH environment to change the root
        /// </summary>
        private static string GetAppDataDir()
        {
            // TODO: document this environment variable
            var docfxAppData = Environment.GetEnvironmentVariable("DOCFX_APPDATA_PATH");

            return string.IsNullOrEmpty(docfxAppData)
                ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".docfx")
                : Path.GetFullPath(docfxAppData);
        }
    }
}