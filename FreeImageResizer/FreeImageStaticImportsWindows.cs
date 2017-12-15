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

        #region Bitmap management functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Allocate")]
        private static extern FIBITMAP AllocateWindows(int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AllocateT")]
        private static extern FIBITMAP AllocateTWindows(FREE_IMAGE_TYPE type, int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AllocateEx")]
        private static extern FIBITMAP AllocateExWindows(int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AllocateExT")]
        private static extern FIBITMAP AllocateExTWindows(FREE_IMAGE_TYPE type, int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Clone")]
        private static extern FIBITMAP CloneWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Unload")]
        private static extern void UnloadWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Load")]
        private static extern FIBITMAP LoadWindows(FREE_IMAGE_FORMAT fif, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_LoadU")]
        private static extern FIBITMAP LoadUWindows(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags);
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_LoadFromHandle")]
        //private static extern FIBITMAP LoadFromHandleWindows(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_Save")]
        private static extern bool SaveWindows(FREE_IMAGE_FORMAT fif, FIBITMAP dib, [MarshalAs(UnmanagedType.LPStr)] string filename, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_SaveU")]
        private static extern bool SaveUWindows(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags);
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SaveToHandle")]
        //private static extern bool SaveToHandleWindows(FREE_IMAGE_FORMAT fif, FIBITMAP dib, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_SAVE_FLAGS flags);
        #endregion

        #region Memory I/O streams
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_OpenMemory")]
        private static extern FIMEMORY OpenMemoryWindows(IntPtr data, uint size_in_bytes);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_OpenMemory")]
        private static extern FIMEMORY OpenMemoryExWindows(byte[] data, uint size_in_bytes);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_CloseMemory")]
        private static extern void CloseMemoryWindows(FIMEMORY stream);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_LoadFromMemory")]
        private static extern FIBITMAP LoadFromMemoryWindows(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SaveToMemory")]
        private static extern bool SaveToMemoryWindows(FREE_IMAGE_FORMAT fif, FIBITMAP dib, FIMEMORY stream, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_TellMemory")]
        private static extern int TellMemoryWindows(FIMEMORY stream);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SeekMemory")]
        private static extern bool SeekMemoryWindows(FIMEMORY stream, int offset, System.IO.SeekOrigin origin);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AcquireMemory")]
        private static extern bool AcquireMemoryWindows(FIMEMORY stream, ref IntPtr data, ref uint size_in_bytes);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ReadMemory")]
        private static extern uint ReadMemoryWindows(byte[] buffer, uint size, uint count, FIMEMORY stream);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_WriteMemory")]
        private static extern uint WriteMemoryWindows(byte[] buffer, uint size, uint count, FIMEMORY stream);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_LoadMultiBitmapFromMemory")]
        private static extern FIMULTIBITMAP LoadMultiBitmapFromMemoryWindows(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags);
        #endregion

        #region Plugin functions
        //[DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_RegisterLocalPlugin")]
        //private static extern FREE_IMAGE_FORMAT RegisterLocalPluginWindows(InitProc proc_address, string format, string description, string extension, string regexpr);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_RegisterExternalPlugin")]
        private static extern FREE_IMAGE_FORMAT RegisterExternalPluginWindows(string path, string format, string description, string extension, string regexpr);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFIFCount")]
        private static extern int GetFIFCountWindows();
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetPluginEnabled")]
        private static extern int SetPluginEnabledWindows(FREE_IMAGE_FORMAT fif, bool enable);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_IsPluginEnabled")]
        private static extern int IsPluginEnabledWindows(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFormat")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFormatWindows(string format);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromMime")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromMimeWindows(string mime);
        //private static unsafe string GetFormatFromFIFWindows(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFormatFromFIF_(fif)); }
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFormatFromFIF")]
        //private static unsafe extern byteWindows* GetFormatFromFIF_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFExtensionListWindows(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFExtensionList_(fif)); }
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFIFExtensionList")]
        //private static unsafe extern byteWindows* GetFIFExtensionList_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFDescriptionWindows(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFDescription_(fif)); }
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFIFDescription")]
        //private static unsafe extern byteWindows* GetFIFDescription_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFRegExprWindows(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFRegExpr_(fif)); }
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFIFRegExpr")]
        //private static unsafe extern byteWindows* GetFIFRegExpr_(FREE_IMAGE_FORMAT fif);
        //private static unsafe string GetFIFMimeTypeWindows(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFMimeType_(fif)); }
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFIFMimeType")]
        //private static unsafe extern byteWindows* GetFIFMimeType_(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFIFFromFilename")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameWindows([MarshalAs(UnmanagedType.LPStr)] string filename);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFIFFromFilenameU")]
        private static extern FREE_IMAGE_FORMAT GetFIFFromFilenameUWindows(string filename);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FIFSupportsReading")]
        private static extern bool FIFSupportsReadingWindows(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FIFSupportsWriting")]
        private static extern bool FIFSupportsWritingWindows(FREE_IMAGE_FORMAT fif);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FIFSupportsExportBPP")]
        private static extern bool FIFSupportsExportBPPWindows(FREE_IMAGE_FORMAT fif, int bpp);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FIFSupportsExportType")]
        private static extern bool FIFSupportsExportTypeWindows(FREE_IMAGE_FORMAT fif, FREE_IMAGE_TYPE type);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FIFSupportsICCProfiles")]
        private static extern bool FIFSupportsICCProfilesWindows(FREE_IMAGE_FORMAT fif);
        #endregion

        #region Multipage functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_OpenMultiBitmap")]
        private static extern FIMULTIBITMAP OpenMultiBitmapWindows(FREE_IMAGE_FORMAT fif, string filename, bool create_new, bool read_only, bool keep_cache_in_memory, FREE_IMAGE_LOAD_FLAGS flags);
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_OpenMultiBitmapFromHandle")]
        //private static extern FIMULTIBITMAP OpenMultiBitmapFromHandleWindows(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_CloseMultiBitmap")]
        private static extern bool CloseMultiBitmap_Windows(FIMULTIBITMAP bitmap, FREE_IMAGE_SAVE_FLAGS flags);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetPageCount")]
        private static extern int GetPageCountWindows(FIMULTIBITMAP bitmap);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AppendPage")]
        private static extern void AppendPageWindows(FIMULTIBITMAP bitmap, FIBITMAP data);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_InsertPage")]
        private static extern void InsertPageWindows(FIMULTIBITMAP bitmap, int page, FIBITMAP data);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_DeletePage")]
        private static extern void DeletePageWindows(FIMULTIBITMAP bitmap, int page);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_LockPage")]
        private static extern FIBITMAP LockPageWindows(FIMULTIBITMAP bitmap, int page);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_UnlockPage")]
        private static extern void UnlockPageWindows(FIMULTIBITMAP bitmap, FIBITMAP data, bool changed);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_MovePage")]
        private static extern bool MovePageWindows(FIMULTIBITMAP bitmap, int target, int source);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetLockedPageNumbers")]
        private static extern bool GetLockedPageNumbersWindows(FIMULTIBITMAP bitmap, int[] pages, ref int count);
        #endregion

        #region Filetype functions
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetFileType")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeWindows([MarshalAs(UnmanagedType.LPStr)] string filename, int size);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_GetFileTypeU")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeUWindows(string filename, int size);
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFileTypeFromHandle")]
        //private static extern FREE_IMAGE_FORMAT GetFileTypeFromHandleWindows(ref FreeImageIO io, fi_handle handle, int size);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetFileTypeFromMemory")]
        private static extern FREE_IMAGE_FORMAT GetFileTypeFromMemoryWindows(FIMEMORY stream, int size);
        #endregion

        #region Helper functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_IsLittleEndian")]
        private static extern bool IsLittleEndianWindows();
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_LookupX11Color")]
        private static extern bool LookupX11ColorWindows(string szColor, out byte nRed, out byte nGreen, out byte nBlue);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_LookupSVGColor")]
        private static extern bool LookupSVGColorWindows(string szColor, out byte nRed, out byte nGreen, out byte nBlue);
        #endregion

        #region Pixel access functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetBits")]
        private static extern IntPtr GetBitsWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetScanLine")]
        private static extern IntPtr GetScanLineWindows(FIBITMAP dib, int scanline);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetPixelIndex")]
        private static extern bool GetPixelIndexWindows(FIBITMAP dib, uint x, uint y, out byte value);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetPixelColor")]
        private static extern bool GetPixelColorWindows(FIBITMAP dib, uint x, uint y, out RGBQUAD value);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetPixelIndex")]
        private static extern bool SetPixelIndexWindows(FIBITMAP dib, uint x, uint y, ref byte value);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetPixelColor")]
        private static extern bool SetPixelColorWindows(FIBITMAP dib, uint x, uint y, ref RGBQUAD value);
        #endregion

        #region Bitmap information functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetImageType")]
        private static extern FREE_IMAGE_TYPE GetImageTypeWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetColorsUsed")]
        private static extern uint GetColorsUsedWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetBPP")]
        private static extern uint GetBPPWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetWidth")]
        private static extern uint GetWidthWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetHeight")]
        private static extern uint GetHeightWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetLine")]
        private static extern uint GetLineWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetPitch")]
        private static extern uint GetPitchWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetDIBSize")]
        private static extern uint GetDIBSizeWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetPalette")]
        private static extern IntPtr GetPaletteWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetDotsPerMeterX")]
        private static extern uint GetDotsPerMeterXWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetDotsPerMeterY")]
        private static extern uint GetDotsPerMeterYWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetDotsPerMeterX")]
        private static extern void SetDotsPerMeterXWindows(FIBITMAP dib, uint res);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetDotsPerMeterY")]
        private static extern void SetDotsPerMeterYWindows(FIBITMAP dib, uint res);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetInfoHeader")]
        private static extern IntPtr GetInfoHeaderWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetInfo")]
        private static extern IntPtr GetInfoWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetColorType")]
        private static extern FREE_IMAGE_COLOR_TYPE GetColorTypeWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetRedMask")]
        private static extern uint GetRedMaskWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetGreenMask")]
        private static extern uint GetGreenMaskWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetBlueMask")]
        private static extern uint GetBlueMaskWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTransparencyCount")]
        private static extern uint GetTransparencyCountWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTransparencyTable")]
        private static extern IntPtr GetTransparencyTableWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTransparent")]
        private static extern void SetTransparentWindows(FIBITMAP dib, bool enabled);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTransparencyTable")]
        private static extern void SetTransparencyTableWindows(FIBITMAP dib, byte[] table, int count);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_IsTransparent")]
        private static extern bool IsTransparentWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_HasBackgroundColor")]
        private static extern bool HasBackgroundColorWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetBackgroundColor")]
        private static extern bool GetBackgroundColorWindows(FIBITMAP dib, out RGBQUAD bkcolor);
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetBackgroundColor")]
        //private static unsafe extern bool SetBackgroundColorWindows(FIBITMAP dib, ref RGBQUAD bkcolor);
        //[DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetBackgroundColor")]
        //private static unsafe extern bool SetBackgroundColorWindows(FIBITMAP dib, RGBQUAD[] bkcolor);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTransparentIndex")]
        private static extern void SetTransparentIndexWindows(FIBITMAP dib, int index);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTransparentIndex")]
        private static extern int GetTransparentIndexWindows(FIBITMAP dib);
        #endregion

        #region ICC profile functions
        //private static FIICCPROFILE GetICCProfileExWindows(FIBITMAP dib) { unsafe { return *(FIICCPROFILE*)FreeImage.GetICCProfile(dib); } }
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetICCProfile")]
        private static extern IntPtr GetICCProfileWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_CreateICCProfile")]
        private static extern IntPtr CreateICCProfileWindows(FIBITMAP dib, byte[] data, int size);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_DestroyICCProfile")]
        private static extern void DestroyICCProfileWindows(FIBITMAP dib);
        #endregion

        #region Conversion functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertTo4Bits")]
        private static extern FIBITMAP ConvertTo4BitsWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertTo8Bits")]
        private static extern FIBITMAP ConvertTo8BitsWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertToGreyscale")]
        private static extern FIBITMAP ConvertToGreyscaleWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertTo16Bits555")]
        private static extern FIBITMAP ConvertTo16Bits555Windows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertTo16Bits565")]
        private static extern FIBITMAP ConvertTo16Bits565Windows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertTo24Bits")]
        private static extern FIBITMAP ConvertTo24BitsWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertTo32Bits")]
        private static extern FIBITMAP ConvertTo32BitsWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ColorQuantize")]
        private static extern FIBITMAP ColorQuantizeWindows(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ColorQuantizeEx")]
        private static extern FIBITMAP ColorQuantizeExWindows(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize, int PaletteSize, int ReserveSize, RGBQUAD[] ReservePalette);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Threshold")]
        private static extern FIBITMAP ThresholdWindows(FIBITMAP dib, byte t);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Dither")]
        private static extern FIBITMAP DitherWindows(FIBITMAP dib, FREE_IMAGE_DITHER algorithm);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertFromRawBits")]
        private static extern FIBITMAP ConvertFromRawBitsWindows(IntPtr bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertFromRawBits")]
        private static extern FIBITMAP ConvertFromRawBitsWindows(byte[] bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertToRawBits")]
        private static extern void ConvertToRawBitsWindows(IntPtr bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertToRawBits")]
        private static extern void ConvertToRawBitsWindows(byte[] bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertToRGBF")]
        private static extern FIBITMAP ConvertToRGBFWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertToStandardType")]
        private static extern FIBITMAP ConvertToStandardTypeWindows(FIBITMAP src, bool scale_linear);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ConvertToType")]
        private static extern FIBITMAP ConvertToTypeWindows(FIBITMAP src, FREE_IMAGE_TYPE dst_type, bool scale_linear);
        #endregion

        #region Tone mapping operators
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ToneMapping")]
        private static extern FIBITMAP ToneMappingWindows(FIBITMAP dib, FREE_IMAGE_TMO tmo, double first_param, double second_param);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_TmoDrago03")]
        private static extern FIBITMAP TmoDrago03Windows(FIBITMAP src, double gamma, double exposure);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_TmoReinhard05")]
        private static extern FIBITMAP TmoReinhard05Windows(FIBITMAP src, double intensity, double contrast);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_TmoFattal02")]
        private static extern FIBITMAP TmoFattal02Windows(FIBITMAP src, double color_saturation, double attenuation);
        #endregion

        #region Compression functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ZLibCompress")]
        private static extern uint ZLibCompressWindows(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ZLibUncompress")]
        private static extern uint ZLibUncompressWindows(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ZLibGZip")]
        private static extern uint ZLibGZipWindows(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ZLibGUnzip")]
        private static extern uint ZLibGUnzipWindows(byte[] target, uint target_size, byte[] source, uint source_size);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ZLibCRC32")]
        private static extern uint ZLibCRC32Windows(uint crc, byte[] source, uint source_size);
        #endregion

        #region Tag creation and destruction
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_CreateTag")]
        private static extern FITAG CreateTagWindows();
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_DeleteTag")]
        private static extern void DeleteTagWindows(FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_CloneTag")]
        private static extern FITAG CloneTagWindows(FITAG tag);
        #endregion

        #region Tag accessors
        //private static unsafe string GetTagKeyWindows(FITAG tag) { return PtrToStr(GetTagKey_(tag)); }
        //[DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagKey")]
        //private static unsafe extern byteWindows* GetTagKey_(FITAG tag);
        //private static unsafe string GetTagDescriptionWindows(FITAG tag) { return PtrToStr(GetTagDescription_(tag)); }
        //[DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagDescription")]
        //private static unsafe extern byteWindows* GetTagDescription_(FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTagID")]
        private static extern ushort GetTagIDWindows(FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTagType")]
        private static extern FREE_IMAGE_MDTYPE GetTagTypeWindows(FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTagCount")]
        private static extern uint GetTagCountWindows(FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTagLength")]
        private static extern uint GetTagLengthWindows(FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetTagValue")]
        private static extern IntPtr GetTagValueWindows(FITAG tag);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetTagKey")]
        private static extern bool SetTagKeyWindows(FITAG tag, string key);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetTagDescription")]
        private static extern bool SetTagDescriptionWindows(FITAG tag, string description);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTagID")]
        private static extern bool SetTagIDWindows(FITAG tag, ushort id);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTagType")]
        private static extern bool SetTagTypeWindows(FITAG tag, FREE_IMAGE_MDTYPE type);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTagCount")]
        private static extern bool SetTagCountWindows(FITAG tag, uint count);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTagLength")]
        private static extern bool SetTagLengthWindows(FITAG tag, uint length);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetTagValue")]
        private static extern bool SetTagValueWindows(FITAG tag, byte[] value);
        #endregion

        #region Metadata iterator
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FindFirstMetadata")]
        private static extern FIMETADATA FindFirstMetadataWindows(FREE_IMAGE_MDMODEL model, FIBITMAP dib, out FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FindNextMetadata")]
        private static extern bool FindNextMetadataWindows(FIMETADATA mdhandle, out FITAG tag);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FindCloseMetadata")]
        private static extern void FindCloseMetadata_Windows(FIMETADATA mdhandle);
        #endregion

        #region Metadata setter and getter
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetMetadata")]
        private static extern bool GetMetadataWindows(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, out FITAG tag);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_SetMetadata")]
        private static extern bool SetMetadataWindows(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, FITAG tag);
        #endregion

        #region Metadata helper functions
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetMetadataCount")]
        private static extern uint GetMetadataCountWindows(FREE_IMAGE_MDMODEL model, FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_CloneMetadata")]
        private static extern bool CloneMetadataWindows(FIBITMAP dst, FIBITMAP src);
        //private static unsafe string TagToStringWindows(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make) { return PtrToStr(TagToString_(model, tag, Make)); }
        //[DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_TagToString")]
        //private static unsafe extern byteWindows* TagToString_(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make);
        #endregion

        #region Rotation and flipping
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_RotateClassic")]
        [Obsolete("RotateClassic is deprecated (use Rotate instead).")]
        private static extern FIBITMAP RotateClassicWindows(FIBITMAP dib, double angle);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Rotate")]
        private static extern FIBITMAP RotateWindows(FIBITMAP dib, double angle, IntPtr backgroundColor);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_RotateEx")]
        private static extern FIBITMAP RotateExWindows(FIBITMAP dib, double angle, double x_shift, double y_shift, double x_origin, double y_origin, bool use_mask);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FlipHorizontal")]
        private static extern bool FlipHorizontalWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FlipVertical")]
        private static extern bool FlipVerticalWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_JPEGTransform")]
        private static extern bool JPEGTransformWindows(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_JPEGTransformU")]
        private static extern bool JPEGTransformUWindows(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect);
        #endregion

        #region Upsampling / downsampling
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Rescale")]
        private static extern FIBITMAP RescaleWindows(FIBITMAP dib, int dst_width, int dst_height, FREE_IMAGE_FILTER filter);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_MakeThumbnail")]
        private static extern FIBITMAP MakeThumbnailWindows(FIBITMAP dib, int max_pixel_size, bool convert);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_EnlargeCanvas")]
        private static extern FIBITMAP EnlargeCanvasWindows(FIBITMAP dib, int left, int top, int right, int bottom, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options);
        #endregion

        #region Color manipulation
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AdjustCurve")]
        private static extern bool AdjustCurveWindows(FIBITMAP dib, byte[] lookUpTable, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AdjustGamma")]
        private static extern bool AdjustGammaWindows(FIBITMAP dib, double gamma);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AdjustBrightness")]
        private static extern bool AdjustBrightnessWindows(FIBITMAP dib, double percentage);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AdjustContrast")]
        private static extern bool AdjustContrastWindows(FIBITMAP dib, double percentage);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Invert")]
        private static extern bool InvertWindows(FIBITMAP dib);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetHistogram")]
        private static extern bool GetHistogramWindows(FIBITMAP dib, int[] histo, FREE_IMAGE_COLOR_CHANNEL channel);
        #endregion

        #region Channel processing
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetChannel")]
        private static extern FIBITMAP GetChannelWindows(FIBITMAP dib, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetChannel")]
        private static extern bool SetChannelWindows(FIBITMAP dib, FIBITMAP dib8, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetComplexChannel")]
        private static extern FIBITMAP GetComplexChannelWindows(FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SetComplexChannel")]
        private static extern bool SetComplexChannelWindows(FIBITMAP dst, FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel);
        #endregion

        #region Copy / Paste / Composite routines
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Copy")]
        private static extern FIBITMAP CopyWindows(FIBITMAP dib, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Paste")]
        private static extern bool PasteWindows(FIBITMAP dst, FIBITMAP src, int left, int top, int alpha);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Composite")]
        private static extern FIBITMAP CompositeWindows(FIBITMAP fg, bool useFileBkg, ref RGBQUAD appBkColor, FIBITMAP bg);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_Composite")]
        private static extern FIBITMAP CompositeWindows(FIBITMAP fg, bool useFileBkg, RGBQUAD[] appBkColor, FIBITMAP bg);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_JPEGCrop")]
        private static extern bool JPEGCropWindows(string src_file, string dst_file, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryWindows, CharSet = CharSet.Unicode, EntryPoint = "FreeImage_JPEGCropU")]
        private static extern bool JPEGCropUWindows(string src_file, string dst_file, int left, int top, int right, int bottom);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_PreMultiplyWithAlpha")]
        private static extern bool PreMultiplyWithAlphaWindows(FIBITMAP dib);
        #endregion

        #region Miscellaneous algorithms
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_MultigridPoissonSolver")]
        private static extern FIBITMAP MultigridPoissonSolverWindows(FIBITMAP Laplacian, int ncycle);
        #endregion

        #region Colors
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_GetAdjustColorsLookupTable")]
        private static extern int GetAdjustColorsLookupTableWindows(byte[] lookUpTable, double brightness, double contrast, double gamma, bool invert);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_AdjustColors")]
        private static extern bool AdjustColorsWindows(FIBITMAP dib, double brightness, double contrast, double gamma, bool invert);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ApplyColorMapping")]
        private static extern uint ApplyColorMappingWindows(FIBITMAP dib, RGBQUAD[] srccolors, RGBQUAD[] dstcolors, uint count, bool ignore_alpha, bool swap);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SwapColors")]
        private static extern uint SwapColorsWindows(FIBITMAP dib, ref RGBQUAD color_a, ref RGBQUAD color_b, bool ignore_alpha);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_ApplyPaletteIndexMapping")]
        private static extern uint ApplyPaletteIndexMappingWindows(FIBITMAP dib, byte[] srcindices, byte[] dstindices, uint count, bool swap);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_SwapPaletteIndices")]
        private static extern uint SwapPaletteIndicesWindows(FIBITMAP dib, ref byte index_a, ref byte index_b);
        [DllImport(FreeImageLibraryWindows, EntryPoint = "FreeImage_FillBackground")]
        private static extern bool FillBackgroundWindows(FIBITMAP dib, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options);
        #endregion
    }
}
