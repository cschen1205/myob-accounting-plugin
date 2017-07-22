#region Copyright © 2007 Rotem Sapir
/*
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the
 * use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim
 * that you wrote the original software. If you use this software in a product,
 * an acknowledgment in the product documentation is required, as shown here:
 *
 * Portions Copyright © 2007 Rotem Sapir
 *
 * 2. No substantial portion of the source code of this library may be redistributed
 * without the express written permission of the copyright holders, where
 * "substantial" is defined as enough code to be recognizably from this library.
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;

namespace HierarchicalTree
{
    public class TreeBuilder : IDisposable
    {

        #region Private Members

        private Color _FontColor = Color.Black;
        private int _BoxWidth = 120;
        private int _BoxHeight = 60;
        private int _Margin = 20;
        private int _HorizontalSpace = 30;
        private int _VerticalSpace = 30;
        private int _FontSize = 10;
        private int imgWidth = 0;
        private int imgHeight = 0;
        private Graphics gr;
        private Color _LineColor = Color.Black;
        private float _LineWidth = 2;
        private Color _BoxFillColor = Color.White;
        private Color _SelectedBoxFillColor = Color.FromArgb(241,58,45);
        private Color _BGColor = Color.White;
        private TreeData.TreeDataTableDataTable dtTree;
        private XmlDocument nodeTree;
        private XmlNode nodeSelected;
        double PercentageChangeX;// = ActualWidth / imgWidth;
        double PercentageChangeY;// = ActualHeight / imgHeight;

        private int shadowSize = 5;
        private int shadowMargin = 2;
        private string startFromNodeID;
        private ImageFormat imageFormat;

        // static for good perfomance 
      static Image shadowDownRight = new Bitmap(typeof(TreeBuilder), "Images.tshadowdownright.png");
        static Image shadowDownLeft = new Bitmap(typeof(TreeBuilder), "Images.tshadowdownleft.png");
      static Image shadowDown = new Bitmap(typeof(TreeBuilder), "Images.tshadowdown.png");
      static Image shadowRight = new Bitmap(typeof(TreeBuilder), "Images.tshadowright.png");
      static Image shadowTopRight = new Bitmap(typeof(TreeBuilder), "Images.tshadowtopright.png");

        #endregion
        #region Public Properties
        public XmlDocument xmlTree
        {
            get 
            {
                return nodeTree;
            }
        }
        public Color BoxFillColor
        {
            get { return _BoxFillColor; }
            set { _BoxFillColor = value; }
        }
        public int BoxWidth
        {
            get { return _BoxWidth; }
            set { _BoxWidth = value; }
        }
        public int BoxHeight
        {
            get { return _BoxHeight; }
            set { _BoxHeight = value; }
        }
        public int Margin
        {
            get { return _Margin; }
            set { _Margin = value; }
        }
        public int HorizontalSpace
        {
            get { return _HorizontalSpace; }
            set { _HorizontalSpace = value; }
        }
        public int VerticalSpace
        {
            get { return _VerticalSpace; }
            set { _VerticalSpace = value; }
        }
        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }
        public Color LineColor
        {
            get { return _LineColor; }
            set { _LineColor = value; }
        }
        public float LineWidth
        {
            get { return _LineWidth; }
            set { _LineWidth = value; }
        }


        public Color BGColor
        {
            get { return _BGColor; }
            set { _BGColor = value; }
        }

        public Color FontColor
        {
            get { return _FontColor; }
            set { _FontColor = value; }
        }

      public XmlNode SelectedNode
      {
        get { return nodeSelected;  }
        set { nodeSelected = value;  }
      }

        #endregion
        #region Public Methods
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="TreeData"></param>
        public TreeBuilder(TreeData.TreeDataTableDataTable TreeData)
        {
            dtTree = TreeData;
        }

            
        public void Dispose()
        {
            dtTree = null;

            if (gr != null)
            {
                gr.Dispose();
                gr = null;
            }
        }
        /// <summary>
        /// This overloaded method can be used to return the image using it's default calculated size, without resizing
        /// </summary>
        /// <param name="StartFromNodeID"></param>
        /// <param name="ImageType"></param>
        /// <returns></returns>
        public System.IO.Stream GenerateTree(
                                        string StartFromNodeID,
                                        ImageFormat ImageType)
        {
            this.startFromNodeID = StartFromNodeID;
            this.imageFormat = ImageType;
            return GenerateTree(-1, -1, StartFromNodeID, ImageType);
        }
      /// <summary>
      /// Re-paints the tree for the change in selected node
      /// 
      /// </summary>
      public void ReGenerateTree()
      {
        GenerateTree(startFromNodeID, imageFormat);
      }

        /// <summary>
        /// Creates the tree
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="StartFromNodeID"></param>
        /// <param name="ImageType"></param>
        /// <returns></returns>
        public System.IO.Stream GenerateTree(int Width,
                                        int Height,
                                        string StartFromNodeID,
                                        ImageFormat ImageType)
        {
          this.startFromNodeID = StartFromNodeID;
          this.imageFormat = ImageType;
          MemoryStream Result = new MemoryStream();

            

            //reset image size
            imgHeight = 0;
            imgWidth = 0;
            //reset percentage change
            PercentageChangeX = 1.0;
            PercentageChangeY = 1.0;
            //define the image
            nodeTree = null;
            nodeTree = new XmlDocument();
            string rootDescription=string.Empty;
            string rootNote = string.Empty;
            int rootBackColor = 0;
            if(dtTree.Select(string.Format("nodeID='{0}'",StartFromNodeID)).Length>0)
            {
                rootDescription = ((TreeData.TreeDataTableRow) dtTree.Select(string.Format("nodeID='{0}'",StartFromNodeID))[0]).nodeDescription;
                rootNote = ((TreeData.TreeDataTableRow) dtTree.Select(string.Format("nodeID='{0}'",StartFromNodeID))[0]).nodeNote;
                rootBackColor = int.Parse(((TreeData.TreeDataTableRow)dtTree.Select(string.Format("nodeID='{0}'", StartFromNodeID))[0]).nodeBackColor);
            }
           
            XmlNode RootNode = GetXMLNode(StartFromNodeID, rootDescription, rootNote, rootBackColor);
            nodeTree.AppendChild(RootNode);
            BuildTree(RootNode, 0);

            //check for intersection. line below should be remarked if not debugging
            //as it affects performance measurably.
            //OverlapExists();
            Bitmap bmp = new Bitmap(imgWidth, imgHeight);
            gr = Graphics.FromImage(bmp);
            gr.Clear(_BGColor);
            DrawChart(RootNode);

            //if caller does not care about size, use original calculated size
            if (Width < 0)
            {
                Width = imgWidth;
            }
            if (Height < 0)
            {
                Height = imgHeight;
            }

            Bitmap ResizedBMP = new Bitmap(bmp, new Size(Width, Height));
            //after resize, determine the change percentage
            PercentageChangeX =Convert.ToDouble( Width) / imgWidth;
            PercentageChangeY =Convert.ToDouble(  Height) / imgHeight;
            //after resize - change the coordinates of the list, in order return the proper coordinates
            //for each node
            if (PercentageChangeX != 1.0 || PercentageChangeY != 1.0)
            {
                //only resize coordinates if there was a resize
                CalculateImageMapData();
            }
            ResizedBMP.Save(Result, ImageType);
            ResizedBMP.Dispose();
            bmp.Dispose();
            gr.Dispose();
            return Result;


        }
        /// <summary>
        /// the node holds the x,y in attributes
        /// use them to calculate the position
        /// This is public so it can be used by other classes trying to calculate the 
        /// cursor/mouse location
        /// </summary>
        /// <param name="oNode"></param>
        /// <returns></returns>
        public Rectangle getRectangleFromNode(XmlNode oNode)
        {
            if (oNode.Attributes["X"] == null || oNode.Attributes["Y"] == null)
            {
                throw new Exception("Both attributes X,Y must exist for node.");
            }
            int X = Convert.ToInt32(oNode.Attributes["X"].InnerText);
            int Y = Convert.ToInt32(oNode.Attributes["Y"].InnerText);

            Rectangle Result = new Rectangle(X, Y,(int) (_BoxWidth * PercentageChangeX) ,(int)( _BoxHeight * PercentageChangeY) );
            return Result;

        }

        public XmlNode OnClick(int x, int y)
        {
          Rectangle currentRect;
          //determine if the mouse clicked on a box, if so, show the  node description.
          //find the node
          foreach (XmlNode oNode in this.xmlTree.SelectNodes("//Node"))
          {
            //iterate through all nodes until found.
            currentRect = this.getRectangleFromNode(oNode);
            if (x >= currentRect.Left &&
                x <= currentRect.Right &&
                y >= currentRect.Top &&
                y <= currentRect.Bottom)
            {
              SelectedNode = oNode;
              break;
            }


          }
          return SelectedNode;
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// convert the datatable to an XML document
        /// </summary>
        /// <param name="oNode"></param>
        /// <param name="y"></param>
        private void BuildTree(XmlNode oNode, int y)
        {
            XmlNode childNode = null;
            //has children
            foreach (TreeData.TreeDataTableRow  childRow in dtTree.Select(
                string.Format("parentNodeID='{0}'", oNode.Attributes["nodeID"].InnerText)))
            {
                //for each child node call this function again
                childNode = GetXMLNode(childRow.nodeID, childRow.nodeDescription, childRow.nodeNote, int.Parse(childRow.nodeBackColor));
                oNode.AppendChild(childNode);
                BuildTree(childNode, y + 1);

            }
            //build node data
            //after checking for nodes we can add the current node
            int StartX;
            int StartY;
            int[] ResultsArr = new int[] {GetXPosByOwnChildren(oNode),
                                    GetXPosByParentPreviousSibling(oNode),
                                    GetXPosByPreviousSibling(oNode),
                                    _Margin };
            Array.Sort(ResultsArr);
            StartX = ResultsArr[3];
            StartY = (y * (_BoxHeight + _VerticalSpace)) + _Margin;
            int width = _BoxWidth;
            int height = _BoxHeight;
            //update the coordinates of this box into the matrix, for later calculations
            oNode.Attributes["X"].InnerText = StartX.ToString();
            oNode.Attributes["Y"].InnerText = StartY.ToString();
            
            //update the image size
            if (imgWidth < (StartX + width + _Margin))
            {
                imgWidth = StartX + width + _Margin;
            }
            if (imgHeight < (StartY + height + _Margin))
            {
                imgHeight = StartY + height + _Margin;
            }
            




        }

        /************************************************************************************************************************
         * The box position is affected by:
         * 1. The previous sibling (box on the same level)
         * 2. The positions of it's children
         * 3. The position of it's uncle (parents' previous sibling)/ cousins (parents' previous sibling children)
         * What determines the position is the farthest x of all the above. If all/some of the above have no value, the margin 
         * becomes the dtermining factor.
         * **********************************************************************************************************************
        */

        private int GetXPosByPreviousSibling(XmlNode CurrentNode)
        {
            int Result = -1;
            int X = -1;
            XmlNode PrevSibling = CurrentNode.PreviousSibling;
            if (PrevSibling != null)
            {
                if (PrevSibling.HasChildNodes)
                {
                    
                    //Result = Convert.ToInt32(PrevSibling.LastChild.Attributes["X"].InnerText ) + _BoxWidth + _HorizontalSpace;
                    //need to loop through all children for all generations of previous sibling
                    X = Convert.ToInt32(GetMaxXOfDescendants(PrevSibling.LastChild));
                    Result = X + _BoxWidth + _HorizontalSpace;

                }
                else
                {
                    
                    Result = Convert.ToInt32(PrevSibling.Attributes["X"].InnerText ) + _BoxWidth + _HorizontalSpace;
                }
            }
            return Result;
        }

        private int GetXPosByOwnChildren(XmlNode CurrentNode)
        {
            int Result = -1;
            
            if (CurrentNode.HasChildNodes)
            {
                int lastChildX = Convert.ToInt32(CurrentNode.LastChild.Attributes["X"].InnerText);
                int firstChildX = Convert.ToInt32(CurrentNode.FirstChild.Attributes["X"].InnerText);
                Result = (((lastChildX + _BoxWidth) - firstChildX) / 2) - (_BoxWidth / 2) + firstChildX;
                    

            }
            return Result;
        }
        private int GetXPosByParentPreviousSibling(XmlNode CurrentNode)
        {
            int Result = -1;
            int X = -1;
            XmlNode ParentPrevSibling = CurrentNode.ParentNode.PreviousSibling;
            
            if (ParentPrevSibling != null)
            {
                if (ParentPrevSibling.HasChildNodes)
                {
                    
                    //X = Convert.ToInt32(ParentPrevSibling.LastChild.Attributes["X"].InnerText);
                    X = GetMaxXOfDescendants(ParentPrevSibling.LastChild);
                   Result= X + _BoxWidth + _HorizontalSpace;
                }
                else
                {
                    
                    X = Convert.ToInt32(ParentPrevSibling.Attributes["X"].InnerText);
                    Result = X + _BoxWidth + _HorizontalSpace;
                }
            }
            else //ParentPrevSibling == null
            {
                
                if (CurrentNode.ParentNode.Name != "#document")
                {
                    Result = GetXPosByParentPreviousSibling(CurrentNode.ParentNode);
                }
            }
            return Result;
        }
        /// <summary>
        /// Get the maximum x of the lowest child on the current tree of nodes
        /// Recursion does not work here, so we'll use a loop to climb down the tree
        /// Recursion is not a solution because we need to return the value of the last leaf of the tree.
        /// That would require managing a global variable.
        /// </summary>
        /// <param name="CurrentNode"></param>
        /// <returns></returns>
        private int GetMaxXOfDescendants(XmlNode CurrentNode)
        {
            int Result = -1;
            
            while (CurrentNode.HasChildNodes)
            {
               CurrentNode = CurrentNode.LastChild;
               
            }
           
            Result = Convert.ToInt32(CurrentNode.Attributes["X"].InnerText);
            
            return Result;
            //int Result = -1;
            //if (CurrentNode.HasChildNodes)
            //{
            //    GetMaxXOfDescendants(CurrentNode.LastChild);
            //}
            //else
            //{
            //    Result = Convert.ToInt32(CurrentNode.Attributes["X"].InnerText);
            //}
            //return Result;
        }

        /// <summary>
        /// create an xml node based on supplied data
        /// </summary>
        /// <returns></returns>
        private XmlNode GetXMLNode(string nodeID,string nodeDescription,string nodeNote, int nodeBackColor)
        {
            //build the node
            XmlNode resultNode = nodeTree.CreateElement("Node");
            XmlAttribute attNodeID = nodeTree.CreateAttribute("nodeID");
            
            XmlAttribute attNodeDescription = nodeTree.CreateAttribute("nodeDescription");
            XmlAttribute attNodeNote = nodeTree.CreateAttribute("nodeNote");
            XmlAttribute attStartX = nodeTree.CreateAttribute("X");
            XmlAttribute attStartY = nodeTree.CreateAttribute("Y");
            XmlAttribute attBackColor = nodeTree.CreateAttribute("backColor");
            
            //set the values of what we know
            attNodeID.InnerText = nodeID;
            
            attNodeDescription.InnerText=nodeDescription;
            attNodeNote.InnerText=nodeNote;
            attStartX.InnerText = "0";
            attStartY.InnerText = "0";
            attBackColor.InnerText = nodeBackColor.ToString();
            
            resultNode.Attributes.Append(attNodeID);
            
            resultNode.Attributes.Append(attNodeDescription);
            resultNode.Attributes.Append(attNodeNote);
            resultNode.Attributes.Append(attStartX);
            resultNode.Attributes.Append(attStartY);
            resultNode.Attributes.Append(attBackColor);            

            return resultNode;
        }

        private void DrawNodeRect(Rectangle rectangle, XmlNode oNode, string caption)
        {
          Font drawFont = new Font("calibri", _FontSize, FontStyle.Bold);

          SolidBrush drawBrush = new SolidBrush(_FontColor);
          StringFormat drawFormat = new StringFormat();
          drawFormat.Alignment = StringAlignment.Center;
          drawFormat.LineAlignment = StringAlignment.Center;
          // Create tiled brushes for the shadow on the right and at the bottom.
          TextureBrush shadowRightBrush = new TextureBrush(shadowRight, WrapMode.Tile);
          TextureBrush shadowDownBrush = new TextureBrush(shadowDown, WrapMode.Tile);

          // Translate (move) the brushes so the top or left of the image matches the top or left of the
          // area where it's drawed. If you don't understand why this is necessary, comment it out. 
          // Hint: The tiling would start at 0,0 of the control, so the shadows will be offset a little.
          shadowDownBrush.TranslateTransform(0, rectangle.Height - shadowSize);
          shadowRightBrush.TranslateTransform(rectangle.Width - shadowSize, 0);

          // Define the rectangles that will be filled with the brush.
          // (where the shadow is drawn)
          Rectangle shadowDownRectangle = new Rectangle(
              rectangle.X + shadowSize + shadowMargin,                      // X
              rectangle.Y + rectangle.Height - shadowSize,                            // Y
              rectangle.Width - (shadowSize * 2 + shadowMargin),        // width (stretches)
              shadowSize                                      // height
              );

          Rectangle shadowRightRectangle = new Rectangle(
              rectangle.X + rectangle.Width - shadowSize,                             // X
              rectangle.Y + shadowSize + shadowMargin,                      // Y
              shadowSize,                                     // width
              rectangle.Height - (shadowSize * 2 + shadowMargin)        // height (stretches)
              );

          // And draw the shadow on the right and at the bottom.
          gr.FillRectangle(shadowDownBrush, shadowDownRectangle);
          gr.FillRectangle(shadowRightBrush, shadowRightRectangle);

          // Now for the corners, draw the 3 5x5 pixel images.
          gr.DrawImage(shadowTopRight, new Rectangle(rectangle.X + rectangle.Width - shadowSize, rectangle.Y + shadowMargin, shadowSize, shadowSize));
          gr.DrawImage(shadowDownRight, new Rectangle(rectangle.X + rectangle.Width - shadowSize, rectangle.Y + rectangle.Height - shadowSize, shadowSize, shadowSize));
          gr.DrawImage(shadowDownLeft, new Rectangle(rectangle.X + shadowMargin, rectangle.Y + rectangle.Height - shadowSize, shadowSize, shadowSize));

          // Fill the area inside with the color in the PanelColor property.
          // 1 pixel is added to everything to make the rectangle smaller. 
          // This is because the 1 pixel border is actually drawn outside the rectangle.
          Rectangle fullRectangle = new Rectangle(
             rectangle.X,                                              // X
             rectangle.Y,                                              // Y
             rectangle.Width - (shadowSize + 2),                       // Width
             rectangle.Height - (shadowSize + 2)                       // Height
             );
                    
          if (SelectedNode != null && oNode.Attributes["nodeID"].Value == SelectedNode.Attributes["nodeID"].Value)
            gr.FillRectangle(new SolidBrush(_SelectedBoxFillColor), fullRectangle);
          else
            gr.FillRectangle(new SolidBrush(Color.FromArgb(int.Parse(oNode.Attributes["backColor"].InnerText))), fullRectangle);

          // Draw string to screen.
          gr.DrawString(caption, drawFont, drawBrush, fullRectangle, drawFormat);

          // Memory efficiency
          shadowDownBrush.Dispose();
          shadowRightBrush.Dispose();
          drawFont.Dispose();
          drawBrush.Dispose();
          shadowDownBrush = null;
          shadowRightBrush = null;
          drawFont = null;
          drawBrush = null;

        }

        /// <summary>
        /// Draws the actual chart image.
        /// </summary>
        private void DrawChart(XmlNode oNode)
        {
            // Create font and brush.
            Pen boxPen = new Pen(_LineColor, _LineWidth);
            //find children
            
            foreach(XmlNode childNode in oNode.ChildNodes)
            {
                DrawChart(childNode);
            }
            Rectangle currentRectangle = getRectangleFromNode(oNode);
            
            DrawNodeRect(currentRectangle, oNode, oNode.Attributes["nodeDescription"].InnerText);
           
            if (oNode.ParentNode.Name != "#document")
            {
                //all but the top box should have lines growing out of their top
                gr.DrawLine(boxPen, currentRectangle.Left + (_BoxWidth / 2),
                                            currentRectangle.Top,
                                            currentRectangle.Left + (_BoxWidth / 2),
                                            currentRectangle.Top - (_VerticalSpace / 2));
            }
            if (oNode.HasChildNodes)
            {
                //all nodes which have nodes should have lines coming from bottom down
                gr.DrawLine(boxPen, currentRectangle.Left + (_BoxWidth / 2),
                                    currentRectangle.Top + _BoxHeight,
                                    currentRectangle.Left + (_BoxWidth / 2),
                                    currentRectangle.Top + _BoxHeight + (_VerticalSpace / 2));

            }
            if (oNode.PreviousSibling != null)
            {
                //the prev node has the same boss - connect the 2 nodes
                gr.DrawLine(boxPen,getRectangleFromNode( oNode.PreviousSibling).Left + (_BoxWidth / 2) - (_LineWidth / 2),
                                    getRectangleFromNode(oNode.PreviousSibling).Top - (_VerticalSpace / 2),
                                    currentRectangle.Left + (_BoxWidth / 2) + (_LineWidth / 2),
                                    currentRectangle.Top - (_VerticalSpace / 2));


            }

            boxPen.Dispose();
            boxPen = null;

        }
        
        /// <summary>
        /// After resizing the image, all positions of the rectanlges need to be 
        /// recalculated too.
        /// </summary>
        /// <param name="ActualWidth"></param>
        /// <param name="ActualHeight"></param>
        private void CalculateImageMapData()
        {
            
            int X=0;
            int newX=0;
            int Y=0;
            int newY=0;
            foreach(XmlNode oNode in nodeTree.SelectNodes("//Node"))
            {
                //go through all nodes and resize the coordinates
                X=Convert.ToInt32(oNode.Attributes["X"].InnerText);
                Y=Convert.ToInt32(oNode.Attributes["Y"].InnerText);
                newX = (int)(X * PercentageChangeX);
                newY = (int)(Y * PercentageChangeY);
                oNode.Attributes["X"].InnerText = newX.ToString();
                oNode.Attributes["Y"].InnerText = newY.ToString();
            
            }
            
        }
        /// <summary>
        /// used for testing purposes, to see if overlap exists between at least 2 boxes.
        /// </summary>
        /// <returns></returns>
        private bool OverlapExists()
        {
            
            List<Rectangle> listOfRectangles = new List<Rectangle>(); //the list of all objects
            int X;
            int Y;
            Rectangle currentRect;
            foreach (XmlNode oNode in nodeTree.SelectNodes("//Node"))
            {
                //go through all nodes and resize the coordinates
                X = Convert.ToInt32(oNode.Attributes["X"].InnerText);
                Y = Convert.ToInt32(oNode.Attributes["Y"].InnerText);
                currentRect = new Rectangle(X,Y,_BoxWidth,_BoxHeight);
                //before adding the node we check if the space it is supposed to occupy is already occupied.
                foreach (Rectangle rect in listOfRectangles)
                {
                    if (currentRect.IntersectsWith(rect))
                    {
                        //problem
                        return true;
                        
                    }
                    
                
                }
                listOfRectangles.Add(currentRect);
                
            }
            return false;
        }
        

        #endregion

       
    }
}
