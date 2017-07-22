﻿
namespace GMap.NET.MapProviders
{
   using System;

   /// <summary>
   /// BingHybridMap provider
   /// </summary>
   public class BingHybridMapProvider : BingMapProviderBase
   {
      public static readonly BingHybridMapProvider Instance;

      BingHybridMapProvider()
      {
      }

      static BingHybridMapProvider()
      {
         Instance = new BingHybridMapProvider();
      }

      #region GMapProvider Members

      readonly Guid id = new Guid("94E2FCB4-CAAC-45EA-A1F9-8147C4B14970");
      public override Guid Id
      {
         get
         {
            return id;
         }
      }

      readonly string name = "BingHybridMap";
      public override string Name
      {
         get
         {
            return name;
         }
      }

      public override PureImage GetTileImage(GPoint pos, int zoom)
      {
         string url = MakeTileImageUrl(pos, zoom, Language);

         return GetTileImageUsingHttp(url);
      }

      #endregion

      string MakeTileImageUrl(GPoint pos, int zoom, string language)
      {
         string key = TileXYToQuadKey(pos.X, pos.Y, zoom);
         return string.Format(UrlFormat, GetServerNum(pos, 4), key, Version, language, (!string.IsNullOrEmpty(ClientKey) ? "&key=" + ClientKey : string.Empty));
      }

      static readonly string UrlFormat = "http://ecn.t{0}.tiles.virtualearth.net/tiles/h{1}.jpeg?g={2}&mkt={3}{4}";
   }
}
