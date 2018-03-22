﻿using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Harurow.Extensions.LineBreak.AdornmentLayers
{
    internal sealed class LineBreakAdornmentLayer
    {
        private const string LayerName = "Harurow." + nameof(LineBreakAdornmentLayer);

#pragma warning disable 649, 169

        [Export(typeof(AdornmentLayerDefinition))]
        [Name(LayerName)]
        [Order(After = PredefinedAdornmentLayers.Selection, Before = PredefinedAdornmentLayers.Text)]
        [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
        private AdornmentLayerDefinition AdornmentLayer { get; set; }

#pragma warning restore 649, 169

        public static IAdornmentLayer GetAdornmentLayer(IWpfTextView textView)
            => textView.GetAdornmentLayer(LayerName);
    }
}
