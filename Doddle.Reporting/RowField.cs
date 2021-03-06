﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doddle.Reporting
{
    public class RowField
    {
        /// <summary>
        /// Gets the name of the field
        /// </summary>
        public string Name { get; private set; }

        public Type DataType { get; internal set; }

        public string DataFormatString { get; set; }
        
        public string HeaderText { get; private set; }

        public bool Hidden { get; private set; }

        public ReportStyle DataStyle { get; private set; }
        public ReportStyle HeaderStyle { get; private set; }
        public ReportStyle FooterStyle { get; private set; }

        public bool ShowTotals { get; private set; }
        public RowField(ReportField field)
        {
            Hidden = field.Hidden;
            Name = field.Name;
            DataType = field.DataType;
            DataFormatString = field.DataFormatString;
            HeaderText = field.HeaderText;
            DataStyle = field.DataStyle.Copy();
            FooterStyle = field.FooterStyle;
            HeaderStyle = field.HeaderStyle;
            ShowTotals = field.ShowTotals;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public override bool Equals(object obj)
        {
            RowField field = obj as RowField;
            if (field == null)
                return false;

            return field.ToString().Equals(this.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}