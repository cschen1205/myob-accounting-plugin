﻿using System;
using System.Collections.Generic;

namespace Barcode.Code39
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Diagnostics;

    public class Code39
    {
        #region Static initialization

        static Dictionary<char, Pattern> codes;

        static Code39()
        {
            object[][] chars = new object[][] 
            {
                new object[] {'0', "n n n w w n w n n"},
                new object[] {'1', "w n n w n n n n w"},
                new object[] {'2', "n n w w n n n n w"},
                new object[] {'3', "w n w w n n n n n"},
                new object[] {'4', "n n n w w n n n w"},
                new object[] {'5', "w n n w w n n n n"},
                new object[] {'6', "n n w w w n n n n"},
                new object[] {'7', "n n n w n n w n w"},
                new object[] {'8', "w n n w n n w n n"},
                new object[] {'9', "n n w w n n w n n"},
                new object[] {'A', "w n n n n w n n w"},
                new object[] {'B', "n n w n n w n n w"},
                new object[] {'C', "w n w n n w n n n"},
                new object[] {'D', "n n n n w w n n w"},
                new object[] {'E', "w n n n w w n n n"},
                new object[] {'F', "n n w n w w n n n"},
                new object[] {'G', "n n n n n w w n w"},
                new object[] {'H', "w n n n n w w n n"},
                new object[] {'I', "n n w n n w w n n"},
                new object[] {'J', "n n n n w w w n n"},
                new object[] {'K', "w n n n n n n w w"},
                new object[] {'L', "n n w n n n n w w"},
                new object[] {'M', "w n w n n n n w n"},
                new object[] {'N', "n n n n w n n w w"},
                new object[] {'O', "w n n n w n n w n"},
                new object[] {'P', "n n w n w n n w n"},
                new object[] {'Q', "n n n n n n w w w"},
                new object[] {'R', "w n n n n n w w n"},
                new object[] {'S', "n n w n n n w w n"},
                new object[] {'T', "n n n n w n w w n"},
                new object[] {'U', "w w n n n n n n w"},
                new object[] {'V', "n w w n n n n n w"},
                new object[] {'W', "w w w n n n n n n"},
                new object[] {'X', "n w n n w n n n w"},
                new object[] {'Y', "w w n n w n n n n"},
                new object[] {'Z', "n w w n w n n n n"},
                new object[] {'-', "n w n n n n w n w"},
                new object[] {'.', "w w n n n n w n n"},
                new object[] {' ', "n w w n n n w n n"},
                new object[] {'*', "n w n n w n w n n"},
                new object[] {'$', "n w n w n w n n n"},
                new object[] {'/', "n w n w n n n w n"},
                new object[] {'+', "n w n n n w n w n"},
                new object[] {'%', "n n n w n w n w n"}
            };

            codes = new Dictionary<char, Pattern>();
            foreach (object[] c in chars)
                codes.Add((char)c[0], Pattern.Parse((string)c[1]));
        }

        #endregion

        private static Pen pen = new Pen(Color.Black);
        private static Brush brush = Brushes.Black;

        private string code;
        private Code39Settings settings;

        public Code39(string code)
            : this(code, new Code39Settings())
        {
        }

        public Code39(string code, Code39Settings settings)
        {
            foreach (char c in code)
                if (!codes.ContainsKey(c))
                    throw new ArgumentException("Invalid character encountered in specified code.");

            if (!code.StartsWith("*"))
                code = "*" + code;
            if (!code.EndsWith("*"))
                code = code + "*";

            this.code = code;
            this.settings = settings;
        }

        public Bitmap Paint()
        {
            string code = this.code.Trim('*');

            SizeF sizeCodeText = Graphics.FromImage(new Bitmap(1, 1)).MeasureString(code, settings.Font);

            int w = settings.LeftMargin + settings.RightMargin;
            foreach (char c in this.code)
                w += codes[c].GetWidth(settings) + settings.InterCharacterGap;
            w -= settings.InterCharacterGap;

            int h = settings.TopMargin + settings.BottomMargin + settings.BarCodeHeight;

            if (settings.DrawText)
                h += settings.BarCodeToTextGapHeight + (int)sizeCodeText.Height;

            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);

            int left = settings.LeftMargin;

            foreach (char c in this.code)
                left += codes[c].Paint(settings, g, left) + settings.InterCharacterGap;

            if (settings.DrawText)
            {
                int tX = settings.LeftMargin + (w - settings.LeftMargin - settings.RightMargin - (int)sizeCodeText.Width) / 2;
                if (tX < 0)
                    tX = 0;
                int tY = settings.TopMargin + settings.BarCodeHeight + settings.BarCodeToTextGapHeight;
                g.DrawString(code, settings.Font, brush, tX, tY);
            }

            return bmp;
        }

        private class Pattern
        {
            private bool[] nw = new bool[9];

            public static Pattern Parse(string s)
            {
                Debug.Assert(s != null);

                s = s.Replace(" ", "").ToLower();

                Debug.Assert(s.Length == 9);
                Debug.Assert(s.Replace("n", "").Replace("w", "").Length == 0);

                Pattern p = new Pattern();

                int i = 0;
                foreach (char c in s)
                    p.nw[i++] = c == 'w';

                return p;
            }

            public int GetWidth(Code39Settings settings)
            {
                int width = 0;

                for (int i = 0; i < 9; i++)
                    width += (nw[i] ? settings.WideWidth : settings.NarrowWidth);

                return width;
            }

            public int Paint(Code39Settings settings, Graphics g, int left)
            {
#if DEBUG
                Rectangle gray = new Rectangle(left, 0, GetWidth(settings), settings.BarCodeHeight + settings.TopMargin + settings.BottomMargin);
                g.FillRectangle(Brushes.Gray, gray);
#endif
                int x = left;

                int w = 0;
                for (int i = 0; i < 9; i++)
                {
                    int width = (nw[i] ? settings.WideWidth : settings.NarrowWidth);

                    if (i % 2 == 0)
                    {
                        Rectangle r = new Rectangle(x, settings.TopMargin, width, settings.BarCodeHeight);
                        g.FillRectangle(brush, r);
                    }

                    x += width;
                    w += width;
                }

                return w;
            }
        }
    }
}
