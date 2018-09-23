﻿using System;
using Harurow.Extensions.One.Adornments.LineBreaks;
using Harurow.Extensions.One.Options;
using Microsoft.VisualStudio.Text.Editor;

namespace Harurow.Extensions.One.ListenerServices
{
    using VisibleLineBreakLineAdornment = Adornments.LineBreaks.VisibleLineBreaks.LineAdornment;
    using WarningLineBreakLineAdornment = Adornments.LineBreaks.WarningLineBreaks.LineAdornment;
    using VisibleLineBreakPainter = Adornments.LineBreaks.VisibleLineBreaks.Painter;
    using WarningLineBreakPainter = Adornments.LineBreaks.WarningLineBreaks.Painter;

    partial class HarurowExtensionOneService
    {
        private TextViewAdornment LineBreaksAdornment { get; set; }

        private void CreateLineBreaksAdornment()
        {
            var layer = TextView.GetAfterSelectionAdornmentLayer();

            #region inner functions

            VisibleLineBreakPainter CreateVisibleLineBreakPainter()
                => new VisibleLineBreakPainter(layer,
                    Resources.VisibleLineBreakBrush, Resources.VisibleLineBreakPen);

            WarningLineBreakPainter CreateWarningLineBreakPainter()
                => new WarningLineBreakPainter(TextView, layer,
                    Resources.LineBreakWarningBrush, Resources.LineBreakWarningPen);


            bool IsEnabled(LineBreakMode mode, bool useVisibleWhitespace)
            {
                switch (mode)
                {
                    case LineBreakMode.True:
                        return true;
                    case LineBreakMode.False:
                        return false;
                    case LineBreakMode.UseVisibleWhiteSpace:
                        return useVisibleWhitespace;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
                }
            }

            #endregion

            var useWhitespace = TextView.Options.GetOptionValue(new UseVisibleWhitespace().Key);

            var visibleLineBreak = IsEnabled(Values.VisibleLineBreakMode, useWhitespace)
                ? new VisibleLineBreakLineAdornment(TextView, CreateVisibleLineBreakPainter())
                : null;

            var warningLineBreak = IsEnabled(Values.LineBreakWarningMode, useWhitespace)
                ? new WarningLineBreakLineAdornment(TextView, CreateWarningLineBreakPainter())
                : null;

            LineBreaksAdornment = new TextViewAdornment(TextView, visibleLineBreak, warningLineBreak);
            LineBreaksAdornment.OnInitialized();
        }
    }
}