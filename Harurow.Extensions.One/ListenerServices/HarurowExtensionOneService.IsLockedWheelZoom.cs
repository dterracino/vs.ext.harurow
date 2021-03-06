﻿using Microsoft.VisualStudio.Text.Editor;

namespace Harurow.Extensions.One.ListenerServices
{
    partial class HarurowExtensionOneService
    {
        private void AttachIsLockedWheelZoom()
        {
            var id = DefaultWpfViewOptions.EnableMouseWheelZoomId;

            TextView.Options.SetOptionValue(id,
                !Values.IsLockedWheelZoom &&
                TextView.Options.Parent.GetOptionValue(id));
        }
    }
}
