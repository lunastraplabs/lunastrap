﻿namespace Bloxstrap.UI.ViewModels.Installer
{
    public class WelcomeViewModel : NotifyPropertyChangedViewModel
    {
        // formatting is done here instead of in xaml, it's just a bit easier
        public string MainText => String.Format(
            Strings.Installer_Welcome_MainText,
            "[github.com/lunastraplabs/lunastrap](https://github.com/lunastraplabs/lunastrap)",
            "(no page yet)"
        );

        public string VersionNotice { get; private set; } = "";

        public bool CanContinue { get; set; } = false;

        public event EventHandler? CanContinueEvent;

        // called by codebehind on page load
        public async void DoChecks()
        {
            var releaseInfo = await App.GetLatestRelease();

            if (releaseInfo is not null)
            {
                if (Utilities.CompareVersions(App.Version, releaseInfo.TagName) == VersionComparison.LessThan)
                {
                    VersionNotice = String.Format(Strings.Installer_Welcome_UpdateNotice, App.Version, releaseInfo.TagName.Replace("v", ""));
                    OnPropertyChanged(nameof(VersionNotice));
                }
            }

            CanContinue = true;
            OnPropertyChanged(nameof(CanContinue));

            CanContinueEvent?.Invoke(this, new EventArgs());
        }
    }
}
