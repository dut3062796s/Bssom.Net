﻿//using System.Runtime.CompilerServices;
using Bssom.Serializer.Binary;
using Bssom.Serializer.BssMap.KeyResolvers;
using Bssom.Serializer.Internal;
using Bssom.Serializer.BssomBuffer;
namespace Bssom.Serializer.BssMap
{
    internal struct BssMapHeadPackInfo
    {
        public BssMapHead MapHead;
        public long ReadPosition;
        public long MapRouteDataStartPos;


        public static BssMapHeadPackInfo Create(ref BssomReader reader)
        {
            BssMapHeadPackInfo pars = new BssMapHeadPackInfo();
            pars.ReadPosition = reader.Position;
            pars.MapHead = BssMapHead.Read(ref reader);
            pars.MapRouteDataStartPos = reader.Position;
            return pars;
        }

        public int MapHeadSize => (int)(MapRouteDataStartPos - ReadPosition);
        public long DataEndPosition => ReadPosition + BssMapObjMarshal.DefaultMapLengthFieldSize + MapHead.DataLength - 1;
    }
}
