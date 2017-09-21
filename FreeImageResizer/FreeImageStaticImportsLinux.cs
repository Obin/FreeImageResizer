using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {
        private const string FreeImageLibraryLinux = "libfreeimage-3.17.0.so";

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_LoadU")]
        private static extern FIBITMAP LoadULinux(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags);

        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Rescale")]
        private static extern FIBITMAP RescaleLinux(FIBITMAP dib, uint dst_width, uint dst_height, FREE_IMAGE_FILTER filter);

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_SaveU")]
        private static extern bool SaveULinux(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags);

        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Unload")]
        private static extern void UnloadLinux(FIBITMAP dib);

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Load")]
        private static extern FIBITMAP LoadLinux(FREE_IMAGE_FORMAT fif, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_LOAD_FLAGS flags);

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Save")]
        private static extern bool SaveLinux(FREE_IMAGE_FORMAT fif, FIBITMAP dib, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_SAVE_FLAGS flags);

        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetWidth")]
        private static extern uint GetWidthLinux(FIBITMAP dib);

        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetHeight")]
        private static extern uint GetHeightLinux(FIBITMAP dib);

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFileType")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeLinux([MarshalAs(UnmanagedType.LPStr)] string filename, int size);

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFIFFromFilename")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameLinux([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FIFSupportsReading")]
        private static extern bool FIFSupportsReadingLinux(FREE_IMAGE_FORMAT fif);

        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromMime")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromMimeLinux(string mime);
    }
}
