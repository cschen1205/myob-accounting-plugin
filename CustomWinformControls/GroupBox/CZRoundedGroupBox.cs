using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace System.Windows.Forms
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class CZRoundedGroupBox : UserControl
    {
        public enum CaptionStyle
        {
            Default,
            Aqua,
            Office2007
        }
        public static CaptionStyle GroupBoxCaptionStyle = CaptionStyle.Default;
        private System.Drawing.Color _BorderColor = Color.FromArgb(141, 178, 227);
        private float _BorderWidth = 1;
        private System.Drawing.Color _BackgroundColor = Color.White;
        private System.Drawing.Color _BackgroundColorGradient = Color.FromArgb(227, 235, 246);
        private RoundedGroupBoxGradientMode _BackgroundGradientMode = RoundedGroupBoxGradientMode.Vertical;
        private string _Caption = "";
        private Color _CaptionBackColor = Color.FromArgb(194, 217, 240);
        private int _CaptionHeight = 25;
        private bool _CaptionVisible = true;
        private CaptionAlignmentEnum _CaptionAlignment = CaptionAlignmentEnum.Center;
        private int _CornerRadius = 5;
        private RoundedGroupBoxCorners _Corners = RoundedGroupBoxCorners.All;
        private int _DropShadowThickness = 3;
        private bool _DropShadowVisible = true;

        private System.Drawing.Color _ShadowColor = Color.FromArgb(50, Color.Black);
        public enum RoundedGroupBoxGradientMode
        {
            /// <summary>Specifies no gradient mode.</summary>
            None = 4,

            /// <summary>Specifies a gradient from upper right to lower left.</summary>
            BackwardDiagonal = LinearGradientMode.BackwardDiagonal,

            /// <summary>Specifies a gradient from upper left to lower right.</summary>
            ForwardDiagonal = LinearGradientMode.ForwardDiagonal,

            /// <summary>Specifies a gradient from left to right.</summary>
            Horizontal = LinearGradientMode.Horizontal,

            /// <summary>Specifies a gradient from top to bottom.</summary>
            Vertical = LinearGradientMode.Vertical
        }
        [Flags()]
        public enum RoundedGroupBoxCorners
        {
            None = 0,
            NorthWest = 2,
            NorthEast = 4,
            SouthEast = 8,
            SouthWest = 16,
            All = NorthWest | NorthEast | SouthEast | SouthWest,
            North = NorthWest | NorthEast,
            South = SouthEast | SouthWest,
            East = NorthEast | SouthEast,
            West = NorthWest | SouthWest
        }
        public enum CaptionAlignmentEnum
        {
            Left = StringAlignment.Near,
            Right = StringAlignment.Far,
            Center = StringAlignment.Center
        }
        /// <summary>Gets or sets the radius of the corners of the control.</summary>
        [Category("Appearance"), Description("This feature will round the corners of the control.")]
        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                if (value > 25)
                {
                    _CornerRadius = 25;
                }
                else
                {
                    if (value < 1)
                    {
                        _CornerRadius = 1;
                    }
                    else
                    {
                        _CornerRadius = value;
                    }
                }
                Invalidate();
            }
        }
        /// <summary>Turns on or off the control shadowing.</summary>
        [Category("Appearance"), Description("This feature will turn on control shadowing.")]
        public bool DropShadowVisible
        {
            get { return _DropShadowVisible; }
            set
            {
                _DropShadowVisible = value;
                Invalidate();
            }
        }
        /// <summary>Gets or sets the color of the control's border.</summary>
        [Category("Appearance"), Description("This feature will allow you to change the color of the control's border.")]
        public System.Drawing.Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                Invalidate();
            }
        }
        /// <summary>Gets or Sets the control's border size.</summary>
        [Category("Appearance"), Description("This feature will allow you to set the control's border size.")]
        public float BorderWidth
        {
            get { return _BorderWidth; }
            set
            {
                if (value > 5)
                {
                    _BorderWidth = 5;
                }
                else
                {
                    if (value < 1)
                    {
                        _BorderWidth = 1;
                    }
                    else
                    {
                        _BorderWidth = value;
                    }
                }
                Invalidate();
            }
        }
        /// <summary>Gets or sets the size of the shadow border thickness.</summary>
        [Category("Appearance"), Description("This feature will change the size of the shadow border.")]
        public int DropShadowThickness
        {
            get { return _DropShadowThickness; }
            set
            {
                if (value > 10)
                {
                    _DropShadowThickness = 10;
                }
                else
                {
                    if (value < 1)
                    {
                        _DropShadowThickness = 1;
                    }
                    else
                    {
                        _DropShadowThickness = value;
                    }
                }
                Invalidate();
            }
        }
        /// <summary>Gets or sets the background color to use. This color can also be used in combination with BackgroundColorGradient for a gradient paint.</summary>
        [Category("Appearance"), Description("This feature will change the group control color. This color can also be used in combination with BackgroundColorGradient for a gradient paint.")]
        public System.Drawing.Color BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                Invalidate();
            }
        }
        /// <summary>Specifies the second color when using the gradient mode.</summary>
        [Category("Appearance"), Description("This feature can be used in combination with BackgroundColor to create a gradient background.")]
        public System.Drawing.Color BackgroundColorGradient
        {
            get { return _BackgroundColorGradient; }
            set
            {
                _BackgroundColorGradient = value;
                Invalidate();
            }
        }
        /// <summary>Here we hide the borderstyle property from the properties page and intellisence.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }
        /// <summary>This property secifies the type of gradient to use when painting the background.</summary>
        [Category("Appearance"), Description("This feature turns on background gradient painting.")]
        public RoundedGroupBoxGradientMode BackgroundGradientMode
        {
            get { return _BackgroundGradientMode; }
            set
            {
                _BackgroundGradientMode = value;
                Invalidate();
            }
        }
        /// <summary>Specifies teh background color for the caption bar.</summary>
        [Category("Appearance"), Description("This feature will paint the group title background to the specified color if PaintRoundedGroupBox is set to true.")]
        public System.Drawing.Color CaptionBackColor
        {
            get { return _CaptionBackColor; }
            set
            {
                _CaptionBackColor = value;
                Invalidate();
            }
        }
        /// <summary>The text to diplay in the caption bar</summary>
        public string Caption
        {
            get { return _Caption; }
            set
            {
                _Caption = value;
                Invalidate();
            }
        }
        /// <summary>Specifies which corners to apply rounding for</summary>
        public RoundedGroupBoxCorners Corners
        {
            get { return _Corners; }
            set
            {
                _Corners = value;
                Invalidate();
            }
        }
        /// <summary>Turns on or off the Caption Bar</summary>
        public bool CaptionVisible
        {
            get { return _CaptionVisible; }
            set
            {
                _CaptionVisible = value;
                Invalidate();
            }
        }
        /// <summary>Gets or sets the height of the caption bar</summary>
        public int CaptionHeight
        {
            get { return _CaptionHeight; }
            set
            {
                _CaptionHeight = value;
                Invalidate();
            }
        }
        /// <summary>Gets or sets the alignment of the caption text</summary>
        public CaptionAlignmentEnum CaptionAlignment
        {
            get { return _CaptionAlignment; }
            set
            {
                _CaptionAlignment = value;
                Invalidate();
            }
        }

        public CZRoundedGroupBox()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        
        protected override void OnPaint(PaintEventArgs e)
        {
            //we must set the smoothing mode to anti alias or high quality(They are the same) in order to get the
            //nice rounded corders on our control
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //first lets set the rectangles we will be drawing in.  If the drop shadow is visible then we need to 
            //reduce the size of the main rectangle and create a second one that is offset by the shadow thickness.
            Rectangle shadowRec = default(Rectangle);
            Rectangle frameRec = default(Rectangle);
            if (DropShadowVisible)
            {
                shadowRec = Rectangle.FromLTRB(DropShadowThickness, DropShadowThickness, this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom - 1);
                frameRec = Rectangle.FromLTRB(0, 0, this.ClientRectangle.Right - DropShadowThickness - 2, this.ClientRectangle.Bottom - DropShadowThickness - 2);
            }
            else
            {
                frameRec = Rectangle.FromLTRB(this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom - 1);
            }
            //draw the drop shadow using the shadow path rectangle
            if (DropShadowVisible)
            {
                using (GraphicsPath path = RoundRectangle(shadowRec, _CornerRadius, _Corners))
                {
                    using (SolidBrush b = new SolidBrush(_ShadowColor))
                    {
                        e.Graphics.FillPath(b, path);
                    }
                }
            }

            //draw the rest of the control in the main frame path
            using (GraphicsPath path = RoundRectangle(frameRec, _CornerRadius, _Corners))
            {
                //paint the background inside the frame
                if (BackgroundGradientMode == RoundedGroupBoxGradientMode.None)
                {
                    //solid background
                    using (SolidBrush b = new SolidBrush(BackgroundColor))
                    {
                        e.Graphics.FillPath(b, path);
                    }
                }
                else
                {
                    //gradient
                    using (LinearGradientBrush br = new LinearGradientBrush(frameRec, BackgroundColor, BackgroundColorGradient, (LinearGradientMode)BackgroundGradientMode))
                    {
                        e.Graphics.FillPath(br, path);
                    }
                }
                //the caption area needs a new path rectangle but must have the same corner radius for the top corners.
                if (CaptionVisible)
                {
                    if (GroupBoxCaptionStyle==CaptionStyle.Aqua)
                    {
                        Rectangle captionRecLeft = Rectangle.FromLTRB(frameRec.Left-1, frameRec.Top, frameRec.Left+12, frameRec.Top + CaptionHeight);
                        Rectangle captionRec = Rectangle.FromLTRB(frameRec.Left+12, frameRec.Top, frameRec.Right-12, frameRec.Top + CaptionHeight);
                        Rectangle captionRecRight = Rectangle.FromLTRB(frameRec.Right-12, frameRec.Top, frameRec.Right+2, frameRec.Top + CaptionHeight);
                        e.Graphics.DrawImage(global::Properties.Resources.caption_left, captionRecLeft);
                        e.Graphics.DrawImage(global::Properties.Resources.caption, captionRec);
                        e.Graphics.DrawImage(global::Properties.Resources.caption_right, captionRecRight);
                    }
                    else if(GroupBoxCaptionStyle==CaptionStyle.Default)
                    {
                        //draw the caption background
                        Rectangle captionRec = Rectangle.FromLTRB(frameRec.Left, frameRec.Top, frameRec.Right, frameRec.Top + CaptionHeight);
                        using (GraphicsPath capPath = RoundRectangle(captionRec, _CornerRadius, _Corners & RoundedGroupBoxCorners.North))
                        {
                            using (SolidBrush b = new SolidBrush(CaptionBackColor))
                            {
                                e.Graphics.FillPath(b, capPath);
                            }
                        }
                    }
                    else if (GroupBoxCaptionStyle == CaptionStyle.Office2007)
                    {
                        Rectangle captionRecLeft = Rectangle.FromLTRB(frameRec.Left - 1, frameRec.Top, frameRec.Left + 9, frameRec.Top + CaptionHeight);
                        Rectangle captionRec = Rectangle.FromLTRB(frameRec.Left + 9, frameRec.Top, frameRec.Right - 7, frameRec.Top + CaptionHeight);
                        Rectangle captionRecRight = Rectangle.FromLTRB(frameRec.Right - 9, frameRec.Top, frameRec.Right + 2, frameRec.Top + CaptionHeight);
                        e.Graphics.DrawImage(global::Properties.Resources.caption_office_left_2007, captionRecLeft);
                        e.Graphics.DrawImage(global::Properties.Resources.caption_office_2007, captionRec);
                        e.Graphics.DrawImage(global::Properties.Resources.caption_right_office_2007, captionRecRight);
                    }
                    if (!string.IsNullOrEmpty(Caption))
                    {
                        //draw the caption text
                        StringFormat sf = new StringFormat();
                        //sf.Alignment = CaptionAlignment;
                        sf.LineAlignment = StringAlignment.Center;
                        Rectangle capRec = Rectangle.FromLTRB(frameRec.Left + 20, frameRec.Top, frameRec.Right - 20, frameRec.Top + CaptionHeight);
                        using (SolidBrush b = new SolidBrush(ForeColor))
                        {
                            e.Graphics.DrawString(Caption, this.Font, b, capRec, sf);
                        }
                    }
                }
                //draw the border
                using (Pen p = new Pen(BorderColor, BorderWidth))
                {
                    e.Graphics.DrawPath(p, path);
                }
            }
        }
        private GraphicsPath RoundRectangle(Rectangle r, int radius, RoundedGroupBoxCorners corners)
        {
            GraphicsPath path = new GraphicsPath();
            if (r.Width <= 0 | r.Height <= 0)
                return path;

            int d = radius * 2;

            int nw = ((corners & RoundedGroupBoxCorners.NorthWest) == RoundedGroupBoxCorners.NorthWest ? d : 0);
            int ne = ((corners & RoundedGroupBoxCorners.NorthEast) == RoundedGroupBoxCorners.NorthEast ? d : 0);
            int se = ((corners & RoundedGroupBoxCorners.SouthEast) == RoundedGroupBoxCorners.SouthEast ? d : 0);
            int sw = ((corners & RoundedGroupBoxCorners.SouthWest) == RoundedGroupBoxCorners.SouthWest ? d : 0);

            path.AddLine(r.Left + nw, r.Top, r.Right - ne, r.Top);

            if (ne > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Right - ne, r.Top, r.Right, r.Top + ne), -90, 90);
            }

            path.AddLine(r.Right, r.Top + ne, r.Right, r.Bottom - se);

            if (se > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Right - se, r.Bottom - se, r.Right, r.Bottom), 0, 90);
            }

            path.AddLine(r.Right - se, r.Bottom, r.Left + sw, r.Bottom);

            if (sw > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - sw, r.Left + sw, r.Bottom), 90, 90);
            }

            path.AddLine(r.Left, r.Bottom - sw, r.Left, r.Top + nw);

            if (nw > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + nw, r.Top + nw), 180, 90);
            }

            path.CloseFigure();
            return path;
        }
    }
}
