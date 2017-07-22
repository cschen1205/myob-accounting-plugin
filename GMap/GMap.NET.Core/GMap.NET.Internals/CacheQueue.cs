﻿
namespace GMap.NET.Internals
{
   using System.IO;
   using System;

   /// <summary>
   /// cache queue item
   /// </summary>
   internal struct CacheItemQueue
   {
      public int Type;
      public GPoint Pos;
      public int Zoom;
      public MemoryStream Img;
      public CacheUsage CacheType;

      public CacheItemQueue(int Type, GPoint Pos, int Zoom, MemoryStream Img, CacheUsage cacheType)
      {
         this.Type = Type;
         this.Pos = Pos;
         this.Zoom = Zoom;
         this.Img = Img;
         this.CacheType = cacheType;
      }

      public override string ToString()
      {
         return Type + " at zoom " + Zoom + ", pos: " + Pos + ", CacheType:" + CacheType;
      }
   }

   internal enum CacheUsage
   {
      First = 0,
      Second = 1,
      Both = First | Second
   }
}
