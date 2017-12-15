using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {
        private const string FreeImageLibraryLinux = "libfreeimage-3.17.0.so";

        #region Bitmap management functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Allocate")]
        private static extern FIBITMAP AllocateLinux(int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AllocateT")]
        private static extern FIBITMAP AllocateTLinux(FREE_IMAGE_TYPE type, int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AllocateEx")]
        private static extern FIBITMAP AllocateExLinux(int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AllocateExT")]
        private static extern FIBITMAP AllocateExTLinux(FREE_IMAGE_TYPE type, int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Clone")]
        private static extern FIBITMAP CloneLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Unload")]
        private static extern void UnloadLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Load")]
        private static extern FIBITMAP LoadLinux(FREE_IMAGE_FORMAT fif, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_LoadU")]
        private static extern FIBITMAP LoadULinux(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags);
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_LoadFromHandle")]
        //private static extern FIBITMAP LoadFromHandleLinux(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Save")]
        private static extern bool SaveLinux(FREE_IMAGE_FORMAT fif, FIBITMAP dib, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_SaveU")]
        private static extern bool SaveULinux(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags);
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SaveToHandle")]
        //private static extern bool SaveToHandleLinux(FREE_IMAGE_FORMAT fif, FIBITMAP dib, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_SAVE_FLAGS flags);
        #endregion

        #region Memory I/O streams
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_OpenMemory")]
        private static extern FIMEMORY OpenMemoryLinux(IntPtr data, uint size_in_bytes);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_OpenMemory")]
        private static extern FIMEMORY OpenMemoryExLinux(byte[] data, uint size_in_bytes);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_CloseMemory")]
        private static extern void CloseMemoryLinux(FIMEMORY stream);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_LoadFromMemory")]
        private static extern FIBITMAP LoadFromMemoryLinux(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SaveToMemory")]
        private static extern bool SaveToMemoryLinux(FREE_IMAGE_FORMAT fif, FIBITMAP dib, FIMEMORY stream, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_TellMemory")]
        private static extern int TellMemoryLinux(FIMEMORY stream);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SeekMemory")]
        private static extern bool SeekMemoryLinux(FIMEMORY stream, int offset, System.IO.SeekOrigin origin);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AcquireMemory")]
        private static extern bool AcquireMemoryLinux(FIMEMORY stream, ref IntPtr data, ref uint size_in_bytes);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ReadMemory")]
        private static extern uint ReadMemoryLinux(byte[] buffer, uint size, uint count, FIMEMORY stream);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_WriteMemory")]
        private static extern uint WriteMemoryLinux(byte[] buffer, uint size, uint count, FIMEMORY stream);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_LoadMultiBitmapFromMemory")]
        private static extern FIMULTIBITMAP LoadMultiBitmapFromMemoryLinux(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags);
        #endregion

        #region Plugin functions
        //[DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_RegisterLocalPlugin")]
        //private static extern FREE_IMAGE_FORMAT RegisterLocalPluginLinux(InitProc proc_address, string format, string description, string extension, string regexpr);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_RegisterExternalPlugin")]
        private static extern FREE_IMAGE_FORMAT RegisterExternalPluginLinux(string path, string format, string description, string extension, string regexpr);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFIFCount")]
        private static extern int GetFIFCountLinux();
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetPluginEnabled")]
        private static extern int SetPluginEnabledLinux(FREE_IMAGE_FORMAT fif, bool enable);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_IsPluginEnabled")]
        private static extern int IsPluginEnabledLinux(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFormat")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFormatLinux(string format);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromMime")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromMimeLinux(string mime);
        //private static unsafe string GetFormatFromFIFLinux(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFormatFromFIF_(fif)); }
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFormatFromFIF")]
        //private static unsafe extern byteLinux* GetFormatFromFIF_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFExtensionListLinux(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFExtensionList_(fif)); }
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFIFExtensionList")]
        //private static unsafe extern byteLinux* GetFIFExtensionList_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFDescriptionLinux(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFDescription_(fif)); }
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFIFDescription")]
        //private static unsafe extern byteLinux* GetFIFDescription_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFRegExprLinux(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFRegExpr_(fif)); }
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFIFRegExpr")]
        //private static unsafe extern byteLinux* GetFIFRegExpr_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFMimeTypeLinux(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFMimeType_(fif)); }
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFIFMimeType")]
        //private static unsafe extern byteLinux* GetFIFMimeType_(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFilename")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameLinux([MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFIFFromFilenameU")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameULinux(string filename);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FIFSupportsReading")]
        private static extern bool FIFSupportsReadingLinux(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FIFSupportsWriting")]
        private static extern bool FIFSupportsWritingLinux(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FIFSupportsExportBPP")]
        private static extern bool FIFSupportsExportBPPLinux(FREE_IMAGE_FORMAT fif, int bpp);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FIFSupportsExportType")]
        private static extern bool FIFSupportsExportTypeLinux(FREE_IMAGE_FORMAT fif, FREE_IMAGE_TYPE type);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FIFSupportsICCProfiles")]
        private static extern bool FIFSupportsICCProfilesLinux(FREE_IMAGE_FORMAT fif);
        #endregion

        #region Multipage functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_OpenMultiBitmap")]
        private static extern FIMULTIBITMAP OpenMultiBitmapLinux(FREE_IMAGE_FORMAT fif, string filename, bool create_new, bool read_only, bool keep_cache_in_memory, FREE_IMAGE_LOAD_FLAGS flags);
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_OpenMultiBitmapFromHandle")]
        //private static extern FIMULTIBITMAP OpenMultiBitmapFromHandleLinux(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_CloseMultiBitmap")]
        private static extern bool CloseMultiBitmap_Linux(FIMULTIBITMAP bitmap, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetPageCount")]
        private static extern int GetPageCountLinux(FIMULTIBITMAP bitmap);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AppendPage")]
        private static extern void AppendPageLinux(FIMULTIBITMAP bitmap, FIBITMAP data);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_InsertPage")]
        private static extern void InsertPageLinux(FIMULTIBITMAP bitmap, int page, FIBITMAP data);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_DeletePage")]
        private static extern void DeletePageLinux(FIMULTIBITMAP bitmap, int page);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_LockPage")]
        private static extern FIBITMAP LockPageLinux(FIMULTIBITMAP bitmap, int page);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_UnlockPage")]
        private static extern void UnlockPageLinux(FIMULTIBITMAP bitmap, FIBITMAP data, bool changed);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_MovePage")]
        private static extern bool MovePageLinux(FIMULTIBITMAP bitmap, int target, int source);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetLockedPageNumbers")]
        private static extern bool GetLockedPageNumbersLinux(FIMULTIBITMAP bitmap, int[] pages, ref int count);
        #endregion

        #region Filetype functions
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFileType")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeLinux([MarshalAs(UnmanagedType.LPStr)] string filename, int size);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFileTypeU")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeULinux(string filename, int size);
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFileTypeFromHandle")]
        //private static extern FREE_IMAGE_FORMAT GetFileTypeFromHandleLinux(ref FreeImageIO io, fi_handle handle, int size);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetFileTypeFromMemory")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeFromMemoryLinux(FIMEMORY stream, int size);
        #endregion

        #region Helper functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_IsLittleEndian")]
        private static extern bool IsLittleEndianLinux();
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_LookupX11Color")]
        private static extern bool LookupX11ColorLinux(string szColor, out byte nRed, out byte nGreen, out byte nBlue);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_LookupSVGColor")]
        private static extern bool LookupSVGColorLinux(string szColor, out byte nRed, out byte nGreen, out byte nBlue);
        #endregion

        #region Pixel access functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetBits")]
        private static extern IntPtr GetBitsLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetScanLine")]
        private static extern IntPtr GetScanLineLinux(FIBITMAP dib, int scanline);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetPixelIndex")]
        private static extern bool GetPixelIndexLinux(FIBITMAP dib, uint x, uint y, out byte value);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetPixelColor")]
        private static extern bool GetPixelColorLinux(FIBITMAP dib, uint x, uint y, out RGBQUAD value);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetPixelIndex")]
        private static extern bool SetPixelIndexLinux(FIBITMAP dib, uint x, uint y, ref byte value);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetPixelColor")]
        private static extern bool SetPixelColorLinux(FIBITMAP dib, uint x, uint y, ref RGBQUAD value);
        #endregion

        #region Bitmap information functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetImageType")]
        private static extern FREE_IMAGE_TYPE GetImageTypeLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetColorsUsed")]
        private static extern uint GetColorsUsedLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetBPP")]
        private static extern uint GetBPPLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetWidth")]
        private static extern uint GetWidthLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetHeight")]
        private static extern uint GetHeightLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetLine")]
        private static extern uint GetLineLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetPitch")]
        private static extern uint GetPitchLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetDIBSize")]
        private static extern uint GetDIBSizeLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetPalette")]
        private static extern IntPtr GetPaletteLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetDotsPerMeterX")]
        private static extern uint GetDotsPerMeterXLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetDotsPerMeterY")]
        private static extern uint GetDotsPerMeterYLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetDotsPerMeterX")]
        private static extern void SetDotsPerMeterXLinux(FIBITMAP dib, uint res);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetDotsPerMeterY")]
        private static extern void SetDotsPerMeterYLinux(FIBITMAP dib, uint res);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetInfoHeader")]
        private static extern IntPtr GetInfoHeaderLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetInfo")]
        private static extern IntPtr GetInfoLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetColorType")]
        private static extern FREE_IMAGE_COLOR_TYPE GetColorTypeLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetRedMask")]
        private static extern uint GetRedMaskLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetGreenMask")]
        private static extern uint GetGreenMaskLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetBlueMask")]
        private static extern uint GetBlueMaskLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTransparencyCount")]
        private static extern uint GetTransparencyCountLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTransparencyTable")]
        private static extern IntPtr GetTransparencyTableLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTransparent")]
        private static extern void SetTransparentLinux(FIBITMAP dib, bool enabled);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTransparencyTable")]
        private static extern void SetTransparencyTableLinux(FIBITMAP dib, byte[] table, int count);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_IsTransparent")]
        private static extern bool IsTransparentLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_HasBackgroundColor")]
        private static extern bool HasBackgroundColorLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetBackgroundColor")]
        private static extern bool GetBackgroundColorLinux(FIBITMAP dib, out RGBQUAD bkcolor);
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetBackgroundColor")]
        //private static unsafe extern bool SetBackgroundColorLinux(FIBITMAP dib, ref RGBQUAD bkcolor);
        //[DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetBackgroundColor")]
        //private static unsafe extern bool SetBackgroundColorLinux(FIBITMAP dib, RGBQUAD[] bkcolor);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTransparentIndex")]
        private static extern void SetTransparentIndexLinux(FIBITMAP dib, int index);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTransparentIndex")]
        private static extern int GetTransparentIndexLinux(FIBITMAP dib);
        #endregion

        #region ICC profile functions
        //private static FIICCPROFILE GetICCProfileExLinux(FIBITMAP dib) { unsafe { return *(FIICCPROFILE*)FreeImage.GetICCProfile(dib); } }
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetICCProfile")]
        private static extern IntPtr GetICCProfileLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_CreateICCProfile")]
        private static extern IntPtr CreateICCProfileLinux(FIBITMAP dib, byte[] data, int size);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_DestroyICCProfile")]
        private static extern void DestroyICCProfileLinux(FIBITMAP dib);
        #endregion

        #region Conversion functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertTo4Bits")]
        private static extern FIBITMAP ConvertTo4BitsLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertTo8Bits")]
        private static extern FIBITMAP ConvertTo8BitsLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertToGreyscale")]
        private static extern FIBITMAP ConvertToGreyscaleLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertTo16Bits555")]
        private static extern FIBITMAP ConvertTo16Bits555Linux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertTo16Bits565")]
        private static extern FIBITMAP ConvertTo16Bits565Linux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertTo24Bits")]
        private static extern FIBITMAP ConvertTo24BitsLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertTo32Bits")]
        private static extern FIBITMAP ConvertTo32BitsLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ColorQuantize")]
        private static extern FIBITMAP ColorQuantizeLinux(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ColorQuantizeEx")]
        private static extern FIBITMAP ColorQuantizeExLinux(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize, int PaletteSize, int ReserveSize, RGBQUAD[] ReservePalette);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Threshold")]
        private static extern FIBITMAP ThresholdLinux(FIBITMAP dib, byte t);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Dither")]
        private static extern FIBITMAP DitherLinux(FIBITMAP dib, FREE_IMAGE_DITHER algorithm);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertFromRawBits")]
        private static extern FIBITMAP ConvertFromRawBitsLinux(IntPtr bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertFromRawBits")]
        private static extern FIBITMAP ConvertFromRawBitsLinux(byte[] bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertToRawBits")]
        private static extern void ConvertToRawBitsLinux(IntPtr bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertToRawBits")]
        private static extern void ConvertToRawBitsLinux(byte[] bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertToRGBF")]
        private static extern FIBITMAP ConvertToRGBFLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertToStandardType")]
        private static extern FIBITMAP ConvertToStandardTypeLinux(FIBITMAP src, bool scale_linear);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ConvertToType")]
        private static extern FIBITMAP ConvertToTypeLinux(FIBITMAP src, FREE_IMAGE_TYPE dst_type, bool scale_linear);
        #endregion

        #region Tone mapping operators
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ToneMapping")]
        private static extern FIBITMAP ToneMappingLinux(FIBITMAP dib, FREE_IMAGE_TMO tmo, double first_param, double second_param);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_TmoDrago03")]
        private static extern FIBITMAP TmoDrago03Linux(FIBITMAP src, double gamma, double exposure);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_TmoReinhard05")]
        private static extern FIBITMAP TmoReinhard05Linux(FIBITMAP src, double intensity, double contrast);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_TmoFattal02")]
        private static extern FIBITMAP TmoFattal02Linux(FIBITMAP src, double color_saturation, double attenuation);
        #endregion

        #region Compression functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ZLibCompress")]
        private static extern uint ZLibCompressLinux(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ZLibUncompress")]
        private static extern uint ZLibUncompressLinux(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ZLibGZip")]
        private static extern uint ZLibGZipLinux(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ZLibGUnzip")]
        private static extern uint ZLibGUnzipLinux(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ZLibCRC32")]
        private static extern uint ZLibCRC32Linux(uint crc, byte[] source, uint source_size);
        #endregion

        #region Tag creation and destruction
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_CreateTag")]
        private static extern FITAG CreateTagLinux();
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_DeleteTag")]
        private static extern void DeleteTagLinux(FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_CloneTag")]
        private static extern FITAG CloneTagLinux(FITAG tag);
        #endregion

        #region Tag accessors
        //private static unsafe string GetTagKeyLinux(FITAG tag) { return PtrToStr(GetTagKey_(tag)); }
        //[DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagKey")]
        //private static unsafe extern byteLinux* GetTagKey_(FITAG tag);
        //private static unsafe string GetTagDescriptionLinux(FITAG tag) { return PtrToStr(GetTagDescription_(tag)); }
        //[DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagDescription")]
        //private static unsafe extern byteLinux* GetTagDescription_(FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTagID")]
        private static extern ushort GetTagIDLinux(FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTagType")]
        private static extern FREE_IMAGE_MDTYPE GetTagTypeLinux(FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTagCount")]
        private static extern uint GetTagCountLinux(FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTagLength")]
        private static extern uint GetTagLengthLinux(FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetTagValue")]
        private static extern IntPtr GetTagValueLinux(FITAG tag);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetTagKey")]
        private static extern bool SetTagKeyLinux(FITAG tag, string key);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetTagDescription")]
        private static extern bool SetTagDescriptionLinux(FITAG tag, string description);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTagID")]
        private static extern bool SetTagIDLinux(FITAG tag, ushort id);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTagType")]
        private static extern bool SetTagTypeLinux(FITAG tag, FREE_IMAGE_MDTYPE type);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTagCount")]
        private static extern bool SetTagCountLinux(FITAG tag, uint count);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTagLength")]
        private static extern bool SetTagLengthLinux(FITAG tag, uint length);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetTagValue")]
        private static extern bool SetTagValueLinux(FITAG tag, byte[] value);
        #endregion

        #region Metadata iterator
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FindFirstMetadata")]
        private static extern FIMETADATA FindFirstMetadataLinux(FREE_IMAGE_MDMODEL model, FIBITMAP dib, out FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FindNextMetadata")]
        private static extern bool FindNextMetadataLinux(FIMETADATA mdhandle, out FITAG tag);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FindCloseMetadata")]
        private static extern void FindCloseMetadata_Linux(FIMETADATA mdhandle);
        #endregion

        #region Metadata setter and getter
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetMetadata")]
        private static extern bool GetMetadataLinux(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, out FITAG tag);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetMetadata")]
        private static extern bool SetMetadataLinux(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, FITAG tag);
        #endregion

        #region Metadata helper functions
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetMetadataCount")]
        private static extern uint GetMetadataCountLinux(FREE_IMAGE_MDMODEL model, FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_CloneMetadata")]
        private static extern bool CloneMetadataLinux(FIBITMAP dst, FIBITMAP src);
        //private static unsafe string TagToStringLinux(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make) { return PtrToStr(TagToString_(model, tag, Make)); }
        //[DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_TagToString")]
        //private static unsafe extern byteLinux* TagToString_(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make);
        #endregion

        #region Rotation and flipping
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_RotateClassic")]
        [Obsolete("RotateClassic is deprecated (use Rotate instead).")]
        private static extern FIBITMAP RotateClassicLinux(FIBITMAP dib, double angle);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Rotate")]
        private static extern FIBITMAP RotateLinux(FIBITMAP dib, double angle, IntPtr backgroundColor);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_RotateEx")]
        private static extern FIBITMAP RotateExLinux(FIBITMAP dib, double angle, double x_shift, double y_shift, double x_origin, double y_origin, bool use_mask);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FlipHorizontal")]
        private static extern bool FlipHorizontalLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FlipVertical")]
        private static extern bool FlipVerticalLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_JPEGTransform")]
        private static extern bool JPEGTransformLinux(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_JPEGTransformU")]
        private static extern bool JPEGTransformULinux(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);
        #endregion

        #region Upsampling / downsampling
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Rescale")]
        private static extern FIBITMAP RescaleLinux(FIBITMAP dib, int dst_width, int dst_height, FREE_IMAGE_FILTER filter);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_MakeThumbnail")]
        private static extern FIBITMAP MakeThumbnailLinux(FIBITMAP dib, int max_pixel_size, bool convert);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_EnlargeCanvas")]
        private static extern FIBITMAP EnlargeCanvasLinux(FIBITMAP dib, int left, int top, int right, int bottom, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options);
        #endregion

        #region Color manipulation
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AdjustCurve")]
        private static extern bool AdjustCurveLinux(FIBITMAP dib, byte[] lookUpTable, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AdjustGamma")]
        private static extern bool AdjustGammaLinux(FIBITMAP dib, double gamma);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AdjustBrightness")]
        private static extern bool AdjustBrightnessLinux(FIBITMAP dib, double percentage);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AdjustContrast")]
        private static extern bool AdjustContrastLinux(FIBITMAP dib, double percentage);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Invert")]
        private static extern bool InvertLinux(FIBITMAP dib);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetHistogram")]
        private static extern bool GetHistogramLinux(FIBITMAP dib, int[] histo, FREE_IMAGE_COLOR_CHANNEL channel);
        #endregion

        #region Channel processing
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetChannel")]
        private static extern FIBITMAP GetChannelLinux(FIBITMAP dib, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetChannel")]
        private static extern bool SetChannelLinux(FIBITMAP dib, FIBITMAP dib8, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetComplexChannel")]
        private static extern FIBITMAP GetComplexChannelLinux(FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SetComplexChannel")]
        private static extern bool SetComplexChannelLinux(FIBITMAP dst, FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel);
        #endregion

        #region Copy / Paste / Composite routines
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Copy")]
        private static extern FIBITMAP CopyLinux(FIBITMAP dib, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Paste")]
        private static extern bool PasteLinux(FIBITMAP dst, FIBITMAP src, int left, int top, int alpha);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Composite")]
        private static extern FIBITMAP CompositeLinux(FIBITMAP fg, bool useFileBkg, ref RGBQUAD appBkColor, FIBITMAP bg);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_Composite")]
        private static extern FIBITMAP CompositeLinux(FIBITMAP fg, bool useFileBkg, RGBQUAD[] appBkColor, FIBITMAP bg);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_JPEGCrop")]
        private static extern bool JPEGCropLinux(string src_file, string dst_file, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryLinux, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_JPEGCropU")]
        private static extern bool JPEGCropULinux(string src_file, string dst_file, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_PreMultiplyWithAlpha")]
        private static extern bool PreMultiplyWithAlphaLinux(FIBITMAP dib);
        #endregion

        #region Miscellaneous algorithms
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_MultigridPoissonSolver")]
        private static extern FIBITMAP MultigridPoissonSolverLinux(FIBITMAP Laplacian, int ncycle);
        #endregion

        #region Colors
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_GetAdjustColorsLookupTable")]
        private static extern int GetAdjustColorsLookupTableLinux(byte[] lookUpTable, double brightness, double contrast, double gamma, bool invert);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_AdjustColors")]
        private static extern bool AdjustColorsLinux(FIBITMAP dib, double brightness, double contrast, double gamma, bool invert);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ApplyColorMapping")]
        private static extern uint ApplyColorMappingLinux(FIBITMAP dib, RGBQUAD[] srccolors, RGBQUAD[] dstcolors, uint count, bool ignore_alpha, bool swap);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SwapColors")]
        private static extern uint SwapColorsLinux(FIBITMAP dib, ref RGBQUAD color_a, ref RGBQUAD color_b, bool ignore_alpha);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_ApplyPaletteIndexMapping")]
        private static extern uint ApplyPaletteIndexMappingLinux(FIBITMAP dib, byte[] srcindices, byte[] dstindices, uint count, bool swap);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_SwapPaletteIndices")]
        private static extern uint SwapPaletteIndicesLinux(FIBITMAP dib, ref byte index_a, ref byte index_b);
        [DllImport(FreeImageLibraryLinux, EntryPoint = "FreeImage_FillBackground")]
        private static extern bool FillBackgroundLinux(FIBITMAP dib, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options);
        #endregion
    }
}
