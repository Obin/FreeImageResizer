using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {
        private const string FreeImageLibraryMacOS = "libfreeimage.dylib";

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_LoadU")]
        private static extern FIBITMAP LoadUMacOS(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags);

        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Rescale")]
        private static extern FIBITMAP RescaleMacOS(FIBITMAP dib, uint dst_width, uint dst_height, FREE_IMAGE_FILTER filter);

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_SaveU")]
        private static extern bool SaveUMacOS(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags);

        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Unload")]
        private static extern void UnloadMacOS(FIBITMAP dib);

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Load")]
        private static extern FIBITMAP LoadMacOS(FREE_IMAGE_FORMAT fif, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_LOAD_FLAGS flags);

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Save")]
        private static extern bool SaveMacOS(FREE_IMAGE_FORMAT fif, FIBITMAP dib, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_SAVE_FLAGS flags);

        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetWidth")]
        private static extern uint GetWidthMacOS(FIBITMAP dib);

        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetHeight")]
        private static extern uint GetHeightMacOS(FIBITMAP dib);

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFileType")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeMacOS([MarshalAs(UnmanagedType.LPStr)] string filename, int size);

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFIFFromFilename")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameMacOS([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FIFSupportsReading")]
        private static extern bool FIFSupportsReadingMacOS(FREE_IMAGE_FORMAT fif);

        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromMime")]
        public static extern FREE_IMAGE_FORMAT GetFIFFromMimeMacOS(string mime);
    }
}
