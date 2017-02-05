using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace FolderIconCreator
{
    /// <summary>
    /// Contains various methods to work with the windows operating system.
    /// </summary>
    internal static class WinHelper
    {
        /// <summary>
        /// Extract the associated icon from a file or directory.
        /// </summary>
        /// <param name="path">Path to the file or directory to extract the icon from.
        /// <remarks>Does NOT support environment variables.</remarks></param>
        /// <returns>The extracted icon as <see cref="BitmapSource"/>.</returns>
        public static BitmapSource ExtractAssociatedIcon(string path)
        {
            int i = 0;
            IntPtr hIcon = SafeNativeMethods.ExtractAssociatedIcon(IntPtr.Zero, path, ref i);
            if (hIcon != IntPtr.Zero)
            {
                BitmapSource bms = Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, null);
                SafeNativeMethods.DestroyIcon(hIcon);
                return bms;
            }
            return null;
        }

        /// <summary>
        /// Extract an icon from a file or directory.
        /// </summary>
        /// <param name="path">Path to the file or directory to extract the icon from.
        /// <remarks>Supports environment variables.</remarks></param>
        /// <param name="index">A zero-based index of the icon.</param>
        /// <returns>The extracted icon as <see cref="BitmapSource"/>.</returns>
        public static BitmapSource ExtractIcon(string path, int index)
        {
            IntPtr hIcon = SafeNativeMethods.ExtractIcon(IntPtr.Zero, path, (uint)index);
            if (hIcon != IntPtr.Zero)
            {
                BitmapSource bms = Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, null);
                SafeNativeMethods.DestroyIcon(hIcon);
                return bms;
            }
            return null;
        }
    }
}