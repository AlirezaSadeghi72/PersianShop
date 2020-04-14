using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Atiran.UI.WindowsForms
{
    public static class FontManager
    {
        [DllImport(@"gdi32.dll")]
        static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static FontFamily IRNazanin { get; set; }
        public static PrivateFontCollection FontCollection = new PrivateFontCollection();

        private static string[] nameFont = { "AtiranFont", "AtiranFont_Bold", "AtiranFont_Light", "AtiranFont_Medium", "AtiranFont_UltraLight" };

        public static void InstallFontForProgram()
        {
            string startupPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

            AddFontFromResource(Resources.AtiranFont_Number);
            try
            {
                File.Copy($@"{startupPath}\Font\AtiranFont_Number.ttf", Path.Combine(@"C:\Windows", "Fonts","AtiranFont_Number.ttf"), true);

                RegistryKey fontkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");

                fontkey.SetValue("AtiranFont Number", "AtiranFont_Number.ttf");
                fontkey.Close();

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

            AddFontFromResource(Resources.AtiranFont);
            AddFontFromResource(Resources.AtiranFont_Bold);
            AddFontFromResource(Resources.AtiranFont_Light);
            AddFontFromResource(Resources.AtiranFont_Medium);
            AddFontFromResource(Resources.AtiranFont_UltraLight);

            foreach (var name in nameFont)
            {
                try
                {
                    File.Copy($@"{startupPath}\Font\"+name+".ttf",
                        Path.Combine(@"C:\Windows", "Fonts" , name + ".ttf"), true);

                    RegistryKey fontkey =
                        Microsoft.Win32.Registry.LocalMachine.CreateSubKey(
                            @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");

                    fontkey.SetValue(name, name + ".ttf");
                    fontkey.Close();
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }

        }
        /// <summary>
        /// اعداد فيكس شده ايران سنز فا نام
        /// </summary>
        /// <param name="size"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Font GetDefaultNumberFont(float size = 9.5f, FontStyle style = FontStyle.Regular)
        {
            return new Font("AtiranFont Number", size, style);
        }
        /// <summary>
        ///  همان فونت ايران سنز فا نام است
        /// </summary>
        /// <param name="size"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Font GetDefaultTextFont(float size = 9.5f, FontStyle style = FontStyle.Regular)
        {
            //var font = FontCollection.Families.First(f => f.Name == "AtiranFont Medium");
            return new Font("AtiranFont", size, style);
        }

        //public static Font GetDefaultTextFont()
        //{
        //    return new Font("IRANSans(FaNum)",9.5f, FontStyle.Regular);
        //}

        static bool AddFontFromResource(byte[] fontArray)
        {
            try
            {
                // getfontArray Length
                var dataLength = fontArray.Length;

                // allocate memory & copy byte[] array
                var ptrData = Marshal.AllocCoTaskMem(dataLength);
                Marshal.Copy(fontArray, 0, ptrData, dataLength);

                uint cFonts = 0;
                AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

                // pass font to private font collection
                FontCollection.AddMemoryFont(ptrData, dataLength);

                // free the unsafe memory
                Marshal.FreeCoTaskMem(ptrData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Font GetFont(string fontfamily, float size, FontStyle style)
        {
            return new Font(fontfamily, size, style);
        }
    }
}
