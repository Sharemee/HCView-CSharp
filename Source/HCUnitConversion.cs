using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HC.Win32;

namespace HC.View
{
    public static class HCUnitConversion
    {
        public static float
            PixelsPerMMX = 3.7f,
            PixelsPerMMY = 3.7f,
            FontSizeScale = 0.75f;

        public static int
            PixelsPerInchX = 96,
            PixelsPerInchY = 96;

        public static void Initialization()
        {
            IntPtr vDC = (IntPtr)GDI.CreateCompatibleDC(IntPtr.Zero);
            try
            {
                PixelsPerInchX = GDI.GetDeviceCaps(vDC, GDI.LOGPIXELSX);  // 每英寸水平逻辑像素数，1英寸dpi数
                PixelsPerInchY = GDI.GetDeviceCaps(vDC, GDI.LOGPIXELSY);  // 每英寸水平逻辑像素数，1英寸dpi数
            }
            finally
            {
                GDI.DeleteDC(vDC);
            }

            FontSizeScale = 72.0f / PixelsPerInchX;

            // 1英寸25.4毫米   FPixelsPerInchX
            PixelsPerMMX = PixelsPerInchX / 25.4f;  // 1毫米对应像素 = 1英寸dpi数 / 1英寸对应毫米
            PixelsPerMMY = PixelsPerInchY / 25.4f;  // 1毫米对应像素 = 1英寸dpi数 / 1英寸对应毫米
        }

        public static uint TwipToPixel(float aValue, float aDpi)
        {
            return (uint)Math.Round(aValue * aDpi / 1440);
        }

        public static uint PixelToTwip(uint aValue, uint aDpi)
        {
            return (uint)Math.Round((float)(aValue * 1440 / aDpi));
        }

        public static float TwipToMillimeter(float aValue)
        {
            return (float)(aValue * 25.4 / 1440);
        }

        public static float MillimeterToTwip(float aValue)
        {
            return (float)(aValue * 1440 / 25.4);
        }

        /// <summary> 水平像素转为毫米 </summary>
        public static float PixXToMillimeter(int value)
        {
            return value / PixelsPerMMX;
        }

        /// <summary> 毫米转为水平像素 </summary>
        public static int MillimeterToPixX(float value)
        {
            return (int)Math.Round(value * PixelsPerMMX);
        }

        /// <summary> 垂直像素转为毫米 </summary>
        public static float PixYToMillimeter(int value)
        {
            return value / PixelsPerMMY;
        }

        /// <summary> 毫米转为垂直像素 </summary>
        public static int MillimeterToPixY(float value)
        {
            return (int)Math.Round(value * PixelsPerMMY);
        }

        /// <summary>
        /// 磅转像素，1磅=1/72英寸
        /// </summary>
        /// <param name="aPt"></param>
        /// <param name="aDpi"></param>
        /// <returns></returns>
        public static int PtToPixel(float aPt, int aDpi)
        {
            return (int)Math.Round(aPt * aDpi / 72);
        }

        /// <summary>
        /// 像素转磅
        /// </summary>
        public static float PixelToPt(int aPix, int aDpi)
        {
            return aPix / aDpi * 72f;
        }

        public static float TwipToPt(float value)
        {
            return value / 1440 * 72;
        }
    }
}
