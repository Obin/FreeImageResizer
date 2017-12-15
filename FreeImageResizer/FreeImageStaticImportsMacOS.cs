using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {
        private const string FreeImageLibraryMacOS = "libfreeimage.dylib";

        #region Bitmap management functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Allocate")]
        private static extern FIBITMAP AllocateMacOS(int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AllocateT")]
        private static extern FIBITMAP AllocateTMacOS(FREE_IMAGE_TYPE type, int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AllocateEx")]
        private static extern FIBITMAP AllocateExMacOS(int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AllocateExT")]
        private static extern FIBITMAP AllocateExTMacOS(FREE_IMAGE_TYPE type, int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Clone")]
        private static extern FIBITMAP CloneMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Unload")]
        private static extern void UnloadMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Load")]
        private static extern FIBITMAP LoadMacOS(FREE_IMAGE_FORMAT fif, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_LoadU")]
        private static extern FIBITMAP LoadUMacOS(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags);
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_LoadFromHandle")]
        //private static extern FIBITMAP LoadFromHandleMacOS(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Save")]
        private static extern bool SaveMacOS(FREE_IMAGE_FORMAT fif, FIBITMAP dib, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_SaveU")]
        private static extern bool SaveUMacOS(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags);
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SaveToHandle")]
        //private static extern bool SaveToHandleMacOS(FREE_IMAGE_FORMAT fif, FIBITMAP dib, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_SAVE_FLAGS flags);
        #endregion

        #region Memory I/O streams
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_OpenMemory")]
        private static extern FIMEMORY OpenMemoryMacOS(IntPtr data, uint size_in_bytes);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_OpenMemory")]
        private static extern FIMEMORY OpenMemoryExMacOS(byte[] data, uint size_in_bytes);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_CloseMemory")]
        private static extern void CloseMemoryMacOS(FIMEMORY stream);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_LoadFromMemory")]
        private static extern FIBITMAP LoadFromMemoryMacOS(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SaveToMemory")]
        private static extern bool SaveToMemoryMacOS(FREE_IMAGE_FORMAT fif, FIBITMAP dib, FIMEMORY stream, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_TellMemory")]
        private static extern int TellMemoryMacOS(FIMEMORY stream);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SeekMemory")]
        private static extern bool SeekMemoryMacOS(FIMEMORY stream, int offset, System.IO.SeekOrigin origin);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AcquireMemory")]
        private static extern bool AcquireMemoryMacOS(FIMEMORY stream, ref IntPtr data, ref uint size_in_bytes);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ReadMemory")]
        private static extern uint ReadMemoryMacOS(byte[] buffer, uint size, uint count, FIMEMORY stream);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_WriteMemory")]
        private static extern uint WriteMemoryMacOS(byte[] buffer, uint size, uint count, FIMEMORY stream);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_LoadMultiBitmapFromMemory")]
        private static extern FIMULTIBITMAP LoadMultiBitmapFromMemoryMacOS(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags);
        #endregion

        #region Plugin functions
        //[DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_RegisterLocalPlugin")]
        //private static extern FREE_IMAGE_FORMAT RegisterLocalPluginMacOS(InitProc proc_address, string format, string description, string extension, string regexpr);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_RegisterExternalPlugin")]
        private static extern FREE_IMAGE_FORMAT RegisterExternalPluginMacOS(string path, string format, string description, string extension, string regexpr);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFIFCount")]
        private static extern int GetFIFCountMacOS();
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetPluginEnabled")]
        private static extern int SetPluginEnabledMacOS(FREE_IMAGE_FORMAT fif, bool enable);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_IsPluginEnabled")]
        private static extern int IsPluginEnabledMacOS(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFormat")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFormatMacOS(string format);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromMime")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromMimeMacOS(string mime);
        //private static unsafe string GetFormatFromFIFMacOS(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFormatFromFIF_(fif)); }
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFormatFromFIF")]
        //private static unsafe extern byteMacOS* GetFormatFromFIF_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFExtensionListMacOS(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFExtensionList_(fif)); }
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFIFExtensionList")]
        //private static unsafe extern byteMacOS* GetFIFExtensionList_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFDescriptionMacOS(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFDescription_(fif)); }
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFIFDescription")]
        //private static unsafe extern byteMacOS* GetFIFDescription_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFRegExprMacOS(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFRegExpr_(fif)); }
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFIFRegExpr")]
        //private static unsafe extern byteMacOS* GetFIFRegExpr_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFMimeTypeMacOS(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFMimeType_(fif)); }
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFIFMimeType")]
        //private static unsafe extern byteMacOS* GetFIFMimeType_(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFilename")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameMacOS([MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFIFFromFilenameU")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameUMacOS(string filename);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FIFSupportsReading")]
        private static extern bool FIFSupportsReadingMacOS(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FIFSupportsWriting")]
        private static extern bool FIFSupportsWritingMacOS(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FIFSupportsExportBPP")]
        private static extern bool FIFSupportsExportBPPMacOS(FREE_IMAGE_FORMAT fif, int bpp);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FIFSupportsExportType")]
        private static extern bool FIFSupportsExportTypeMacOS(FREE_IMAGE_FORMAT fif, FREE_IMAGE_TYPE type);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FIFSupportsICCProfiles")]
        private static extern bool FIFSupportsICCProfilesMacOS(FREE_IMAGE_FORMAT fif);
        #endregion

        #region Multipage functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_OpenMultiBitmap")]
        private static extern FIMULTIBITMAP OpenMultiBitmapMacOS(FREE_IMAGE_FORMAT fif, string filename, bool create_new, bool read_only, bool keep_cache_in_memory, FREE_IMAGE_LOAD_FLAGS flags);
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_OpenMultiBitmapFromHandle")]
        //private static extern FIMULTIBITMAP OpenMultiBitmapFromHandleMacOS(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_CloseMultiBitmap")]
        private static extern bool CloseMultiBitmap_MacOS(FIMULTIBITMAP bitmap, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetPageCount")]
        private static extern int GetPageCountMacOS(FIMULTIBITMAP bitmap);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AppendPage")]
        private static extern void AppendPageMacOS(FIMULTIBITMAP bitmap, FIBITMAP data);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_InsertPage")]
        private static extern void InsertPageMacOS(FIMULTIBITMAP bitmap, int page, FIBITMAP data);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_DeletePage")]
        private static extern void DeletePageMacOS(FIMULTIBITMAP bitmap, int page);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_LockPage")]
        private static extern FIBITMAP LockPageMacOS(FIMULTIBITMAP bitmap, int page);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_UnlockPage")]
        private static extern void UnlockPageMacOS(FIMULTIBITMAP bitmap, FIBITMAP data, bool changed);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_MovePage")]
        private static extern bool MovePageMacOS(FIMULTIBITMAP bitmap, int target, int source);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetLockedPageNumbers")]
        private static extern bool GetLockedPageNumbersMacOS(FIMULTIBITMAP bitmap, int[] pages, ref int count);
        #endregion

        #region Filetype functions
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFileType")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeMacOS([MarshalAs(UnmanagedType.LPStr)] string filename, int size);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFileTypeU")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeUMacOS(string filename, int size);
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFileTypeFromHandle")]
        //private static extern FREE_IMAGE_FORMAT GetFileTypeFromHandleMacOS(ref FreeImageIO io, fi_handle handle, int size);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetFileTypeFromMemory")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeFromMemoryMacOS(FIMEMORY stream, int size);
        #endregion

        #region Helper functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_IsLittleEndian")]
        private static extern bool IsLittleEndianMacOS();
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_LookupX11Color")]
        private static extern bool LookupX11ColorMacOS(string szColor, out byte nRed, out byte nGreen, out byte nBlue);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_LookupSVGColor")]
        private static extern bool LookupSVGColorMacOS(string szColor, out byte nRed, out byte nGreen, out byte nBlue);
        #endregion

        #region Pixel access functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetBits")]
        private static extern IntPtr GetBitsMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetScanLine")]
        private static extern IntPtr GetScanLineMacOS(FIBITMAP dib, int scanline);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetPixelIndex")]
        private static extern bool GetPixelIndexMacOS(FIBITMAP dib, uint x, uint y, out byte value);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetPixelColor")]
        private static extern bool GetPixelColorMacOS(FIBITMAP dib, uint x, uint y, out RGBQUAD value);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetPixelIndex")]
        private static extern bool SetPixelIndexMacOS(FIBITMAP dib, uint x, uint y, ref byte value);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetPixelColor")]
        private static extern bool SetPixelColorMacOS(FIBITMAP dib, uint x, uint y, ref RGBQUAD value);
        #endregion

        #region Bitmap information functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetImageType")]
        private static extern FREE_IMAGE_TYPE GetImageTypeMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetColorsUsed")]
        private static extern uint GetColorsUsedMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetBPP")]
        private static extern uint GetBPPMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetWidth")]
        private static extern uint GetWidthMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetHeight")]
        private static extern uint GetHeightMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetLine")]
        private static extern uint GetLineMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetPitch")]
        private static extern uint GetPitchMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetDIBSize")]
        private static extern uint GetDIBSizeMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetPalette")]
        private static extern IntPtr GetPaletteMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetDotsPerMeterX")]
        private static extern uint GetDotsPerMeterXMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetDotsPerMeterY")]
        private static extern uint GetDotsPerMeterYMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetDotsPerMeterX")]
        private static extern void SetDotsPerMeterXMacOS(FIBITMAP dib, uint res);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetDotsPerMeterY")]
        private static extern void SetDotsPerMeterYMacOS(FIBITMAP dib, uint res);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetInfoHeader")]
        private static extern IntPtr GetInfoHeaderMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetInfo")]
        private static extern IntPtr GetInfoMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetColorType")]
        private static extern FREE_IMAGE_COLOR_TYPE GetColorTypeMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetRedMask")]
        private static extern uint GetRedMaskMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetGreenMask")]
        private static extern uint GetGreenMaskMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetBlueMask")]
        private static extern uint GetBlueMaskMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTransparencyCount")]
        private static extern uint GetTransparencyCountMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTransparencyTable")]
        private static extern IntPtr GetTransparencyTableMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTransparent")]
        private static extern void SetTransparentMacOS(FIBITMAP dib, bool enabled);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTransparencyTable")]
        private static extern void SetTransparencyTableMacOS(FIBITMAP dib, byte[] table, int count);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_IsTransparent")]
        private static extern bool IsTransparentMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_HasBackgroundColor")]
        private static extern bool HasBackgroundColorMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetBackgroundColor")]
        private static extern bool GetBackgroundColorMacOS(FIBITMAP dib, out RGBQUAD bkcolor);
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetBackgroundColor")]
        //private static unsafe extern bool SetBackgroundColorMacOS(FIBITMAP dib, ref RGBQUAD bkcolor);
        //[DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetBackgroundColor")]
        //private static unsafe extern bool SetBackgroundColorMacOS(FIBITMAP dib, RGBQUAD[] bkcolor);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTransparentIndex")]
        private static extern void SetTransparentIndexMacOS(FIBITMAP dib, int index);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTransparentIndex")]
        private static extern int GetTransparentIndexMacOS(FIBITMAP dib);
        #endregion

        #region ICC profile functions
        //private static FIICCPROFILE GetICCProfileExMacOS(FIBITMAP dib) { unsafe { return *(FIICCPROFILE*)FreeImage.GetICCProfile(dib); } }
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetICCProfile")]
        private static extern IntPtr GetICCProfileMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_CreateICCProfile")]
        private static extern IntPtr CreateICCProfileMacOS(FIBITMAP dib, byte[] data, int size);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_DestroyICCProfile")]
        private static extern void DestroyICCProfileMacOS(FIBITMAP dib);
        #endregion

        #region Conversion functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertTo4Bits")]
        private static extern FIBITMAP ConvertTo4BitsMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertTo8Bits")]
        private static extern FIBITMAP ConvertTo8BitsMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertToGreyscale")]
        private static extern FIBITMAP ConvertToGreyscaleMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertTo16Bits555")]
        private static extern FIBITMAP ConvertTo16Bits555MacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertTo16Bits565")]
        private static extern FIBITMAP ConvertTo16Bits565MacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertTo24Bits")]
        private static extern FIBITMAP ConvertTo24BitsMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertTo32Bits")]
        private static extern FIBITMAP ConvertTo32BitsMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ColorQuantize")]
        private static extern FIBITMAP ColorQuantizeMacOS(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ColorQuantizeEx")]
        private static extern FIBITMAP ColorQuantizeExMacOS(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize, int PaletteSize, int ReserveSize, RGBQUAD[] ReservePalette);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Threshold")]
        private static extern FIBITMAP ThresholdMacOS(FIBITMAP dib, byte t);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Dither")]
        private static extern FIBITMAP DitherMacOS(FIBITMAP dib, FREE_IMAGE_DITHER algorithm);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertFromRawBits")]
        private static extern FIBITMAP ConvertFromRawBitsMacOS(IntPtr bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertFromRawBits")]
        private static extern FIBITMAP ConvertFromRawBitsMacOS(byte[] bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertToRawBits")]
        private static extern void ConvertToRawBitsMacOS(IntPtr bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertToRawBits")]
        private static extern void ConvertToRawBitsMacOS(byte[] bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertToRGBF")]
        private static extern FIBITMAP ConvertToRGBFMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertToStandardType")]
        private static extern FIBITMAP ConvertToStandardTypeMacOS(FIBITMAP src, bool scale_linear);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ConvertToType")]
        private static extern FIBITMAP ConvertToTypeMacOS(FIBITMAP src, FREE_IMAGE_TYPE dst_type, bool scale_linear);
        #endregion

        #region Tone mapping operators
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ToneMapping")]
        private static extern FIBITMAP ToneMappingMacOS(FIBITMAP dib, FREE_IMAGE_TMO tmo, double first_param, double second_param);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_TmoDrago03")]
        private static extern FIBITMAP TmoDrago03MacOS(FIBITMAP src, double gamma, double exposure);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_TmoReinhard05")]
        private static extern FIBITMAP TmoReinhard05MacOS(FIBITMAP src, double intensity, double contrast);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_TmoFattal02")]
        private static extern FIBITMAP TmoFattal02MacOS(FIBITMAP src, double color_saturation, double attenuation);
        #endregion

        #region Compression functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ZLibCompress")]
        private static extern uint ZLibCompressMacOS(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ZLibUncompress")]
        private static extern uint ZLibUncompressMacOS(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ZLibGZip")]
        private static extern uint ZLibGZipMacOS(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ZLibGUnzip")]
        private static extern uint ZLibGUnzipMacOS(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ZLibCRC32")]
        private static extern uint ZLibCRC32MacOS(uint crc, byte[] source, uint source_size);
        #endregion

        #region Tag creation and destruction
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_CreateTag")]
        private static extern FITAG CreateTagMacOS();
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_DeleteTag")]
        private static extern void DeleteTagMacOS(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_CloneTag")]
        private static extern FITAG CloneTagMacOS(FITAG tag);
        #endregion

        #region Tag accessors
        //private static unsafe string GetTagKeyMacOS(FITAG tag) { return PtrToStr(GetTagKey_(tag)); }
        //[DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagKey")]
        //private static unsafe extern byteMacOS* GetTagKey_(FITAG tag);
        //private static unsafe string GetTagDescriptionMacOS(FITAG tag) { return PtrToStr(GetTagDescription_(tag)); }
        //[DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagDescription")]
        //private static unsafe extern byteMacOS* GetTagDescription_(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTagID")]
        private static extern ushort GetTagIDMacOS(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTagType")]
        private static extern FREE_IMAGE_MDTYPE GetTagTypeMacOS(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTagCount")]
        private static extern uint GetTagCountMacOS(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTagLength")]
        private static extern uint GetTagLengthMacOS(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetTagValue")]
        private static extern IntPtr GetTagValueMacOS(FITAG tag);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetTagKey")]
        private static extern bool SetTagKeyMacOS(FITAG tag, string key);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetTagDescription")]
        private static extern bool SetTagDescriptionMacOS(FITAG tag, string description);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTagID")]
        private static extern bool SetTagIDMacOS(FITAG tag, ushort id);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTagType")]
        private static extern bool SetTagTypeMacOS(FITAG tag, FREE_IMAGE_MDTYPE type);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTagCount")]
        private static extern bool SetTagCountMacOS(FITAG tag, uint count);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTagLength")]
        private static extern bool SetTagLengthMacOS(FITAG tag, uint length);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetTagValue")]
        private static extern bool SetTagValueMacOS(FITAG tag, byte[] value);
        #endregion

        #region Metadata iterator
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FindFirstMetadata")]
        private static extern FIMETADATA FindFirstMetadataMacOS(FREE_IMAGE_MDMODEL model, FIBITMAP dib, out FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FindNextMetadata")]
        private static extern bool FindNextMetadataMacOS(FIMETADATA mdhandle, out FITAG tag);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FindCloseMetadata")]
        private static extern void FindCloseMetadata_MacOS(FIMETADATA mdhandle);
        #endregion

        #region Metadata setter and getter
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetMetadata")]
        private static extern bool GetMetadataMacOS(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, out FITAG tag);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetMetadata")]
        private static extern bool SetMetadataMacOS(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, FITAG tag);
        #endregion

        #region Metadata helper functions
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetMetadataCount")]
        private static extern uint GetMetadataCountMacOS(FREE_IMAGE_MDMODEL model, FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_CloneMetadata")]
        private static extern bool CloneMetadataMacOS(FIBITMAP dst, FIBITMAP src);
        //private static unsafe string TagToStringMacOS(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make) { return PtrToStr(TagToString_(model, tag, Make)); }
        //[DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_TagToString")]
        //private static unsafe extern byteMacOS* TagToString_(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make);
        #endregion

        #region Rotation and flipping
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_RotateClassic")]
        [Obsolete("RotateClassic is deprecated (use Rotate instead).")]
        private static extern FIBITMAP RotateClassicMacOS(FIBITMAP dib, double angle);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Rotate")]
        private static extern FIBITMAP RotateMacOS(FIBITMAP dib, double angle, IntPtr backgroundColor);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_RotateEx")]
        private static extern FIBITMAP RotateExMacOS(FIBITMAP dib, double angle, double x_shift, double y_shift, double x_origin, double y_origin, bool use_mask);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FlipHorizontal")]
        private static extern bool FlipHorizontalMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FlipVertical")]
        private static extern bool FlipVerticalMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_JPEGTransform")]
        private static extern bool JPEGTransformMacOS(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_JPEGTransformU")]
        private static extern bool JPEGTransformUMacOS(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);
        #endregion

        #region Upsampling / downsampling
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Rescale")]
        private static extern FIBITMAP RescaleMacOS(FIBITMAP dib, int dst_width, int dst_height, FREE_IMAGE_FILTER filter);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_MakeThumbnail")]
        private static extern FIBITMAP MakeThumbnailMacOS(FIBITMAP dib, int max_pixel_size, bool convert);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_EnlargeCanvas")]
        private static extern FIBITMAP EnlargeCanvasMacOS(FIBITMAP dib, int left, int top, int right, int bottom, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options);
        #endregion

        #region Color manipulation
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AdjustCurve")]
        private static extern bool AdjustCurveMacOS(FIBITMAP dib, byte[] lookUpTable, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AdjustGamma")]
        private static extern bool AdjustGammaMacOS(FIBITMAP dib, double gamma);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AdjustBrightness")]
        private static extern bool AdjustBrightnessMacOS(FIBITMAP dib, double percentage);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AdjustContrast")]
        private static extern bool AdjustContrastMacOS(FIBITMAP dib, double percentage);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Invert")]
        private static extern bool InvertMacOS(FIBITMAP dib);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetHistogram")]
        private static extern bool GetHistogramMacOS(FIBITMAP dib, int[] histo, FREE_IMAGE_COLOR_CHANNEL channel);
        #endregion

        #region Channel processing
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetChannel")]
        private static extern FIBITMAP GetChannelMacOS(FIBITMAP dib, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetChannel")]
        private static extern bool SetChannelMacOS(FIBITMAP dib, FIBITMAP dib8, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetComplexChannel")]
        private static extern FIBITMAP GetComplexChannelMacOS(FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SetComplexChannel")]
        private static extern bool SetComplexChannelMacOS(FIBITMAP dst, FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel);
        #endregion

        #region Copy / Paste / Composite routines
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Copy")]
        private static extern FIBITMAP CopyMacOS(FIBITMAP dib, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Paste")]
        private static extern bool PasteMacOS(FIBITMAP dst, FIBITMAP src, int left, int top, int alpha);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Composite")]
        private static extern FIBITMAP CompositeMacOS(FIBITMAP fg, bool useFileBkg, ref RGBQUAD appBkColor, FIBITMAP bg);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_Composite")]
        private static extern FIBITMAP CompositeMacOS(FIBITMAP fg, bool useFileBkg, RGBQUAD[] appBkColor, FIBITMAP bg);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_JPEGCrop")]
        private static extern bool JPEGCropMacOS(string src_file, string dst_file, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryMacOS, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_JPEGCropU")]
        private static extern bool JPEGCropUMacOS(string src_file, string dst_file, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_PreMultiplyWithAlpha")]
        private static extern bool PreMultiplyWithAlphaMacOS(FIBITMAP dib);
        #endregion

        #region Miscellaneous algorithms
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_MultigridPoissonSolver")]
        private static extern FIBITMAP MultigridPoissonSolverMacOS(FIBITMAP Laplacian, int ncycle);
        #endregion

        #region Colors
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_GetAdjustColorsLookupTable")]
        private static extern int GetAdjustColorsLookupTableMacOS(byte[] lookUpTable, double brightness, double contrast, double gamma, bool invert);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_AdjustColors")]
        private static extern bool AdjustColorsMacOS(FIBITMAP dib, double brightness, double contrast, double gamma, bool invert);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ApplyColorMapping")]
        private static extern uint ApplyColorMappingMacOS(FIBITMAP dib, RGBQUAD[] srccolors, RGBQUAD[] dstcolors, uint count, bool ignore_alpha, bool swap);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SwapColors")]
        private static extern uint SwapColorsMacOS(FIBITMAP dib, ref RGBQUAD color_a, ref RGBQUAD color_b, bool ignore_alpha);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_ApplyPaletteIndexMapping")]
        private static extern uint ApplyPaletteIndexMappingMacOS(FIBITMAP dib, byte[] srcindices, byte[] dstindices, uint count, bool swap);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_SwapPaletteIndices")]
        private static extern uint SwapPaletteIndicesMacOS(FIBITMAP dib, ref byte index_a, ref byte index_b);
        [DllImport(FreeImageLibraryMacOS, EntryPoint = "FreeImage_FillBackground")]
        private static extern bool FillBackgroundMacOS(FIBITMAP dib, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options);
        #endregion
    }
}
