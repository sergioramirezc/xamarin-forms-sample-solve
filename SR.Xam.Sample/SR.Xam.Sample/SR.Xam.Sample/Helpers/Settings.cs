// Helpers/Settings.cs
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SR.Xam.Sample.Models.User;

namespace SR.Xam.Sample.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private const string UsersKey = "users_key";
        private static readonly string SettingsDefault = string.Empty;
        private static readonly string usersDefault = JsonConvert.SerializeObject(new UserListModel() { Users = new System.Collections.Generic.List<UserModel>() });

        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }


        public static UserListModel UserList
        {
            get
            {
                string value = AppSettings.GetValueOrDefault(UsersKey, usersDefault);
                return JsonConvert.DeserializeObject<UserListModel>(value);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UsersKey, JsonConvert.SerializeObject(value));
            }
        }

    }
}