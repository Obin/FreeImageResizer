using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {
        private const string FreeImageLibraryWindows = "FreeImage.dll";

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_LoadU")]
        private static extern FIBITMAP LoadUWindows(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags);

        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Rescale")]
        private static extern FIBITMAP RescaleWindows(FIBITMAP dib, uint dst_width, uint dst_height, FREE_IMAGE_FILTER filter);

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_SaveU")]
        private static extern bool SaveUWindows(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags);

        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Unload")]
        private static extern void UnloadWindows(FIBITMAP dib);

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Load")]
        private static extern FIBITMAP LoadWindows(FREE_IMAGE_FORMAT fif, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_LOAD_FLAGS flags);

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Save")]
        private static extern bool SaveWindows(FREE_IMAGE_FORMAT fif, FIBITMAP dib, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_SAVE_FLAGS flags);

        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetWidth")]
        private static extern uint GetWidthWindows(FIBITMAP dib);

        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetHeight")]
        private static extern uint GetHeightWindows(FIBITMAP dib);

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFileType")]
        public static extern FREE_IMAGE_FORMAT GetFileTypeWindows([MarshalAs(UnmanagedType.LPStr)] string filename, int size);

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFIFFromFilename")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameWindows([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FIFSupportsReading")]
        private static extern bool FIFSupportsReadingWindows(FREE_IMAGE_FORMAT fif);

        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromMime")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromMimeWindows(string mime);

    }
}
