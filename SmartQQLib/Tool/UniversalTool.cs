﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQQLib.Tool
{
    internal class UniversalTool
    {
        /// <summary>  
        /// 获取时间戳  
        /// </summary> 
        internal Int64 GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }
        /// <summary>  
        /// 取得hash值 
        /// </summary> 
        internal String hash(long x, String K)
        {
            int[] N = { 0, 0, 0, 0 };
            char[] k = K.ToCharArray();

            for (int T = 0; T < K.Length; T++)
            {
                N[T % 4] ^= (int)k[T];
            }


            String[] U = { "EC", "OK" };
            long[] V = { 0, 0, 0, 0 };
            V[0] = x >> 24 & 255 ^ (int)U[0].ToCharArray()[0];
            V[1] = x >> 16 & 255 ^ (int)U[0].ToCharArray()[1];
            V[2] = x >> 8 & 255 ^ (int)U[1].ToCharArray()[0];
            V[3] = x & 255 ^ (int)U[1].ToCharArray()[1];


            long[] U1 = { 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int T = 0; T < 8; T++)
            {
                U1[T] = T % 2 == 0 ? N[T >> 1] : V[T >> 1];
            }


            char[] N1 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            String V1 = "";

            for (int T = 0; T < U1.Count(); T++)
            {
                V1 += N1[((U1[T] >> 4) & 15)];
                V1 += N1[(U1[T] & 15)];
            }

            return V1;
        }


        /// <summary>  
        /// 取得bkn值 
        /// </summary> 
        internal int GetBkn(String e)
        {
            char[] E = e.ToCharArray();
            int hash = 5381;
            for (int i = 0, len = e.Length; i < len; ++i)
                hash += (hash << 5) + E[i];
            int t = 2147483647 & hash;
            return t;
        }

        /// <summary>
        /// 获取目录文件夹下的所有子目录
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePattern"></param>
        /// <returns></returns>
        public static List<string> FindSubDirectories(string directory)
        {
            return Directory.GetDirectories(directory, "*", SearchOption.AllDirectories).ToList<string>();
        }


        /// <summary>
        /// 获取目录名称
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return string.Empty;// DirectoryHelper.CreateDirectory(directory);
            }
            return new DirectoryInfo(directory).Name;
        }
    }
}