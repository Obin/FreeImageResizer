using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {

        #region Bitmap management functions

        /// <summary>
        /// Creates a new bitmap in memory.
        /// </summary>
        /// <param name="width">Width of the new bitmap.</param>
        /// <param name="height">Height of the new bitmap.</param>
        /// <param name="bpp">Bit depth of the new Bitmap.
        /// Supported pixel depth: 1-, 4-, 8-, 16-, 24-, 32-bit per pixel for standard bitmap</param>
        /// <param name="red_mask">Red part of the color layout.
        /// eg: 0xFF0000</param>
        /// <param name="green_mask">Green part of the color layout.
        /// eg: 0x00FF00</param>
        /// <param name="blue_mask">Blue part of the color layout.
        /// eg: 0x0000FF</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Allocate(int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AllocateWindows(width, height, bpp, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AllocateLinux(width, height, bpp, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AllocateMacOS(width, height, bpp, red_mask, green_mask, blue_mask);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a new bitmap in memory.
        /// </summary>
        /// <param name="type">Type of the image.</param>
        /// <param name="width">Width of the new bitmap.</param>
        /// <param name="height">Height of the new bitmap.</param>
        /// <param name="bpp">Bit depth of the new Bitmap.
        /// Supported pixel depth: 1-, 4-, 8-, 16-, 24-, 32-bit per pixel for standard bitmap</param>
        /// <param name="red_mask">Red part of the color layout.
        /// eg: 0xFF0000</param>
        /// <param name="green_mask">Green part of the color layout.
        /// eg: 0x00FF00</param>
        /// <param name="blue_mask">Blue part of the color layout.
        /// eg: 0x0000FF</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP AllocateT(FREE_IMAGE_TYPE type, int width, int height, int bpp, uint red_mask, uint green_mask, uint blue_mask)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AllocateTWindows(type, width, height, bpp, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AllocateTLinux(type, width, height, bpp, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AllocateTMacOS(type, width, height, bpp, red_mask, green_mask, blue_mask);
            else
                throw new NotSupportedException();
        }

        public static FIBITMAP AllocateEx(int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AllocateExWindows(width, height, bpp, color, options, palette, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AllocateExLinux(width, height, bpp, color, options, palette, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AllocateExMacOS(width, height, bpp, color, options, palette, red_mask, green_mask, blue_mask);
            else
                throw new NotSupportedException();
        }

        public static FIBITMAP AllocateExT(FREE_IMAGE_TYPE type, int width, int height, int bpp, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options, RGBQUAD[] palette, uint red_mask, uint green_mask, uint blue_mask)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AllocateExTWindows(type, width, height, bpp, color, options, palette, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AllocateExTLinux(type, width, height, bpp, color, options, palette, red_mask, green_mask, blue_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AllocateExTMacOS(type, width, height, bpp, color, options, palette, red_mask, green_mask, blue_mask);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Makes an exact reproduction of an existing bitmap, including metadata and attached profile if any.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Clone(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CloneWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CloneLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CloneMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Deletes a previously loaded FIBITMAP from memory.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        public static void Unload(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                UnloadWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                UnloadLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                UnloadMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Decodes a bitmap, allocates memory for it and returns it as a FIBITMAP.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="filename">Name of the file to decode.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Load(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LoadWindows(fif, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LoadLinux(fif, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LoadMacOS(fif, filename, flags);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Decodes a bitmap, allocates memory for it and returns it as a FIBITMAP.
        /// Supports UNICODE filenames.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="filename">Name of the file to decode.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP LoadU(FREE_IMAGE_FORMAT fif, string filename, FREE_IMAGE_LOAD_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LoadUWindows(fif, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LoadULinux(fif, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LoadUMacOS(fif, filename, flags);
            else
                throw new NotSupportedException();
        }


        ///// <summary>
        ///// Loads a bitmap from an arbitrary source.
        ///// </summary>
        ///// <param name="fif">Type of the bitmap.</param>
        ///// <param name="io">A FreeImageIO structure with functionpointers to handle the source.</param>
        ///// <param name="handle">A handle to the source.</param>
        ///// <param name="flags">Flags to enable or disable plugin-features.</param>
        ///// <returns>Handle to a FreeImage bitmap.</returns>
        //public static FIBITMAP LoadFromHandle(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return LoadFromHandleWindows(fif, ref FreeImageIO io, handle, flags);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return LoadFromHandleLinux(fif, ref FreeImageIO io, handle, flags);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return LoadFromHandleMacOS(fif, ref FreeImageIO io, handle, flags);
        //    else
        //        throw new NotSupportedException();
        //}


        /// <summary>
        /// Saves a previosly loaded FIBITMAP to a file.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="filename">Name of the file to save to.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool Save(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SaveWindows(fif, dib, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SaveLinux(fif, dib, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SaveMacOS(fif, dib, filename, flags);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Saves a previosly loaded FIBITMAP to a file.
        /// Supports UNICODE filenames.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="filename">Name of the file to save to.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SaveU(FREE_IMAGE_FORMAT fif, FIBITMAP dib, string filename, FREE_IMAGE_SAVE_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SaveUWindows(fif, dib, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SaveULinux(fif, dib, filename, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SaveUMacOS(fif, dib, filename, flags);
            else
                throw new NotSupportedException();
        }


        ///// <summary>
        ///// Saves a bitmap to an arbitrary source.
        ///// </summary>
        ///// <param name="fif">Type of the bitmap.</param>
        ///// <param name="dib">Handle to a FreeImage bitmap.</param>
        ///// <param name="io">A FreeImageIO structure with functionpointers to handle the source.</param>
        ///// <param name="handle">A handle to the source.</param>
        ///// <param name="flags">Flags to enable or disable plugin-features.</param>
        ///// <returns>Returns true on success, false on failure.</returns>
        //public static bool SaveToHandle(FREE_IMAGE_FORMAT fif, FIBITMAP dib, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_SAVE_FLAGS flags)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return SaveToHandleWindows(fif, dib, ref FreeImageIO io, handle, flags);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return SaveToHandleLinux(fif, dib, ref FreeImageIO io, handle, flags);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return SaveToHandleMacOS(fif, dib, ref FreeImageIO io, handle, flags);
        //    else
        //        throw new NotSupportedException();
        //}


        #endregion

        #region Memory I/O streams

        /// <summary>
        /// Open a memory stream.
        /// </summary>
        /// <param name="data">Pointer to the data in memory.</param>
        /// <param name="size_in_bytes">Length of the data in byte.</param>
        /// <returns>Handle to a memory stream.</returns>
        public static FIMEMORY OpenMemory(IntPtr data, uint size_in_bytes)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return OpenMemoryWindows(data, size_in_bytes);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return OpenMemoryLinux(data, size_in_bytes);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OpenMemoryMacOS(data, size_in_bytes);
            else
                throw new NotSupportedException();
        }


        public static FIMEMORY OpenMemoryEx(byte[] data, uint size_in_bytes)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return OpenMemoryExWindows(data, size_in_bytes);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return OpenMemoryExLinux(data, size_in_bytes);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OpenMemoryExMacOS(data, size_in_bytes);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Close and free a memory stream.
        /// </summary>
        /// <param name="stream">Handle to a memory stream.</param>
        public static void CloseMemory(FIMEMORY stream)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                CloseMemoryWindows(stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                CloseMemoryLinux(stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                CloseMemoryMacOS(stream);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Decodes a bitmap from a stream, allocates memory for it and returns it as a FIBITMAP.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="stream">Handle to a memory stream.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP LoadFromMemory(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LoadFromMemoryWindows(fif, stream, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LoadFromMemoryLinux(fif, stream, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LoadFromMemoryMacOS(fif, stream, flags);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Saves a previosly loaded FIBITMAP to a stream.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="stream">Handle to a memory stream.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SaveToMemory(FREE_IMAGE_FORMAT fif, FIBITMAP dib, FIMEMORY stream, FREE_IMAGE_SAVE_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SaveToMemoryWindows(fif, dib, stream, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SaveToMemoryLinux(fif, dib, stream, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SaveToMemoryMacOS(fif, dib, stream, flags);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Gets the current position of a memory handle.
        /// </summary>
        /// <param name="stream">Handle to a memory stream.</param>
        /// <returns>The current file position if successful, -1 otherwise.</returns>
        public static int TellMemory(FIMEMORY stream)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return TellMemoryWindows(stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return TellMemoryLinux(stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return TellMemoryMacOS(stream);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Moves the memory handle to a specified location.
        /// </summary>
        /// <param name="stream">Handle to a memory stream.</param>
        /// <param name="offset">Number of bytes from origin.</param>
        /// <param name="origin">Initial position.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SeekMemory(FIMEMORY stream, int offset, System.IO.SeekOrigin origin)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SeekMemoryWindows(stream, offset, origin);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SeekMemoryLinux(stream, offset, origin);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SeekMemoryMacOS(stream, offset, origin);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Provides a direct buffer access to a memory stream.
        /// </summary>
        /// <param name="stream">The target memory stream.</param>
        /// <param name="data">Pointer to the data in memory.</param>
        /// <param name="size_in_bytes">Size of the data in bytes.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool AcquireMemory(FIMEMORY stream, ref IntPtr data, ref uint size_in_bytes)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AcquireMemoryWindows(stream, ref data, ref size_in_bytes);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AcquireMemoryLinux(stream, ref data, ref size_in_bytes);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AcquireMemoryMacOS(stream, ref data, ref size_in_bytes);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Reads data from a memory stream.
        /// </summary>
        /// <param name="buffer">The buffer to store the data in.</param>
        /// <param name="size">Size in bytes of the items.</param>
        /// <param name="count">Number of items to read.</param>
        /// <param name="stream">The stream to read from.
        /// The memory pointer associated with stream is increased by the number of bytes actually read.</param>
        /// <returns>The number of full items actually read.
        /// May be less than count on error or stream-end.</returns>
        public static uint ReadMemory(byte[] buffer, uint size, uint count, FIMEMORY stream)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ReadMemoryWindows(buffer, size, count, stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ReadMemoryLinux(buffer, size, count, stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ReadMemoryMacOS(buffer, size, count, stream);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Writes data to a memory stream.
        /// </summary>
        /// <param name="buffer">The buffer to read the data from.</param>
        /// <param name="size">Size in bytes of the items.</param>
        /// <param name="count">Number of items to write.</param>
        /// <param name="stream">The stream to write to.
        /// The memory pointer associated with stream is increased by the number of bytes actually written.</param>
        /// <returns>The number of full items actually written.
        /// May be less than count on error or stream-end.</returns>
        public static uint WriteMemory(byte[] buffer, uint size, uint count, FIMEMORY stream)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return WriteMemoryWindows(buffer, size, count, stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return WriteMemoryLinux(buffer, size, count, stream);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return WriteMemoryMacOS(buffer, size, count, stream);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Open a multi-page bitmap from a memory stream.
        /// </summary>
        /// <param name="fif">Type of the bitmap.</param>
        /// <param name="stream">The stream to decode.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Handle to a FreeImage multi-paged bitmap.</returns>
        public static FIMULTIBITMAP LoadMultiBitmapFromMemory(FREE_IMAGE_FORMAT fif, FIMEMORY stream, FREE_IMAGE_LOAD_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LoadMultiBitmapFromMemoryWindows(fif, stream, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LoadMultiBitmapFromMemoryLinux(fif, stream, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LoadMultiBitmapFromMemoryMacOS(fif, stream, flags);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Plugin functions

        /////// <summary>
        /////// Registers a new plugin to be used in FreeImage.
        /////// </summary>
        /////// <param name="proc_address">Pointer to the function that initialises the plugin.</param>
        /////// <param name="format">A string describing the format of the plugin.</param>
        /////// <param name="description">A string describing the plugin.</param>
        /////// <param name="extension">A string witha comma sperated list of extensions. f.e: "pl,pl2,pl4"</param>
        /////// <param name="regexpr">A regular expression used to identify the bitmap.</param>
        /////// <returns>The format idientifier assigned by FreeImage.</returns>
        //public static FREE_IMAGE_FORMAT RegisterLocalPlugin(InitProc proc_address, string format, string description, string extension, string regexpr)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return RegisterLocalPluginWindows(proc_address, format, description, extension, regexpr);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return RegisterLocalPluginLinux(proc_address, format, description, extension, regexpr);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return RegisterLocalPluginMacOS(proc_address, format, description, extension, regexpr);
        //    else
        //        throw new NotSupportedException();
        //}


        /// <summary>
        /// Registers a new plugin to be used in FreeImage. The plugin is residing in a DLL.
        /// The Init function must be called Init and must use the stdcall calling convention.
        /// </summary>
        /// <param name="path">Complete path to the dll file hosting the plugin.</param>
        /// <param name="format">A string describing the format of the plugin.</param>
        /// <param name="description">A string describing the plugin.</param>
        /// <param name="extension">A string witha comma sperated list of extensions. f.e: "pl,pl2,pl4"</param>
        /// <param name="regexpr">A regular expression used to identify the bitmap.</param>
        /// <returns>The format idientifier assigned by FreeImage.</returns>
        public static FREE_IMAGE_FORMAT RegisterExternalPlugin(string path, string format, string description, string extension, string regexpr)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return RegisterExternalPluginWindows(path, format, description, extension, regexpr);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return RegisterExternalPluginLinux(path, format, description, extension, regexpr);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RegisterExternalPluginMacOS(path, format, description, extension, regexpr);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Retrieves the number of FREE_IMAGE_FORMAT identifiers being currently registered.
        /// </summary>
        /// <returns>The number of registered formats.</returns>
        public static int GetFIFCount()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFIFCountWindows();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFIFCountLinux();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFIFCountMacOS();
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Enables or disables a plugin.
        /// </summary>
        /// <param name="fif">The plugin to enable or disable.</param>
        /// <param name="enable">True: enable the plugin. false: disable the plugin.</param>
        /// <returns>The previous state of the plugin.
        /// 1 - enabled. 0 - disables. -1 plugin does not exist.</returns>
        public static int SetPluginEnabled(FREE_IMAGE_FORMAT fif, bool enable)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetPluginEnabledWindows(fif, enable);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetPluginEnabledLinux(fif, enable);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetPluginEnabledMacOS(fif, enable);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Retrieves the state of a plugin.
        /// </summary>
        /// <param name="fif">The plugin to check.</param>
        /// <returns>1 - enabled. 0 - disables. -1 plugin does not exist.</returns>
        public static int IsPluginEnabled(FREE_IMAGE_FORMAT fif)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return IsPluginEnabledWindows(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return IsPluginEnabledLinux(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return IsPluginEnabledMacOS(fif);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a <see cref="FREE_IMAGE_FORMAT"/> identifier from the format string that was used to register the FIF.
        /// </summary>
        /// <param name="format">The string that was used to register the plugin.</param>
        /// <returns>A <see cref="FREE_IMAGE_FORMAT"/> identifier from the format.</returns>
        public static FREE_IMAGE_FORMAT GetFIFFromFormat(string format)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFIFFromFormatWindows(format);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFIFFromFormatLinux(format);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFIFFromFormatMacOS(format);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a <see cref="FREE_IMAGE_FORMAT"/> identifier from a MIME content type string
        /// (MIME stands for Multipurpose Internet Mail Extension).
        /// </summary>
        /// <param name="mime">A MIME content type.</param>
        /// <returns>A <see cref="FREE_IMAGE_FORMAT"/> identifier from the MIME.</returns>
        public static FREE_IMAGE_FORMAT GetFIFFromMime(string mime)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFIFFromMimeWindows(mime);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFIFFromMimeLinux(mime);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFIFFromMimeMacOS(mime);
            else
                throw new NotSupportedException();
        }


        ///// <summary>
        ///// Returns the string that was used to register a plugin from the system assigned <see cref="FREE_IMAGE_FORMAT"/>.
        ///// </summary>
        ///// <param name="fif">The assigned <see cref="FREE_IMAGE_FORMAT"/>.</param>
        ///// <returns>The string that was used to register the plugin.</returns>
        //public static unsafe string GetFormatFromFIF(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFormatFromFIF_(fif)); }
        //[DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetFormatFromFIF")]
        //private static unsafe extern byte* GetFormatFromFIF_(FREE_IMAGE_FORMAT fif);

        ///// <summary>
        ///// Returns a comma-delimited file extension list describing the bitmap formats the given plugin can read and/or write.
        ///// </summary>
        ///// <param name="fif">The desired <see cref="FREE_IMAGE_FORMAT"/>.</param>
        ///// <returns>A comma-delimited file extension list.</returns>
        //public static unsafe string GetFIFExtensionList(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFExtensionList_(fif)); }
        //[DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetFIFExtensionList")]
        //private static unsafe extern byte* GetFIFExtensionList_(FREE_IMAGE_FORMAT fif);

        ///// <summary>
        ///// Returns a descriptive string that describes the bitmap formats the given plugin can read and/or write.
        ///// </summary>
        ///// <param name="fif">The desired <see cref="FREE_IMAGE_FORMAT"/>.</param>
        ///// <returns>A descriptive string that describes the bitmap formats.</returns>
        //public static unsafe string GetFIFDescription(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFDescription_(fif)); }
        //[DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetFIFDescription")]
        //private static unsafe extern byte* GetFIFDescription_(FREE_IMAGE_FORMAT fif);

        ///// <summary>
        ///// Returns a regular expression string that can be used by a regular expression engine to identify the bitmap.
        ///// FreeImageQt makes use of this function.
        ///// </summary>
        ///// <param name="fif">The desired <see cref="FREE_IMAGE_FORMAT"/>.</param>
        ///// <returns>A regular expression string.</returns>
        //public static unsafe string GetFIFRegExpr(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFRegExpr_(fif)); }
        //[DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetFIFRegExpr")]
        //private static unsafe extern byte* GetFIFRegExpr_(FREE_IMAGE_FORMAT fif);

        ///// <summary>
        ///// Given a <see cref="FREE_IMAGE_FORMAT"/> identifier, returns a MIME content type string (MIME stands for Multipurpose Internet Mail Extension).
        ///// </summary>
        ///// <param name="fif">The desired <see cref="FREE_IMAGE_FORMAT"/>.</param>
        ///// <returns>A MIME content type string.</returns>
        //public static unsafe string GetFIFMimeType(FREE_IMAGE_FORMAT fif) { return PtrToStr(GetFIFMimeType_(fif)); }
        //[DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetFIFMimeType")]
        //private static unsafe extern byte* GetFIFMimeType_(FREE_IMAGE_FORMAT fif);

        /// <summary>
        /// This function takes a filename or a file-extension and returns the plugin that can
        /// read/write files with that extension in the form of a <see cref="FREE_IMAGE_FORMAT"/> identifier.
        /// </summary>
        /// <param name="filename">The filename or -extension.</param>
        /// <returns>The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</returns>
        public static FREE_IMAGE_FORMAT GetFIFFromFilename(string filename)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFIFFromFilenameWindows(filename);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFIFFromFilenameLinux(filename);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFIFFromFilenameMacOS(filename);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// This function takes a filename or a file-extension and returns the plugin that can
        /// read/write files with that extension in the form of a <see cref="FREE_IMAGE_FORMAT"/> identifier.
        /// Supports UNICODE filenames.
        /// </summary>
        /// <param name="filename">The filename or -extension.</param>
        /// <returns>The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</returns>
        public static FREE_IMAGE_FORMAT GetFIFFromFilenameU(string filename)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFIFFromFilenameUWindows(filename);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFIFFromFilenameULinux(filename);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFIFFromFilenameUMacOS(filename);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Checks if a plugin can load bitmaps.
        /// </summary>
        /// <param name="fif">The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</param>
        /// <returns>True if the plugin can load bitmaps, else false.</returns>
        public static bool FIFSupportsReading(FREE_IMAGE_FORMAT fif)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FIFSupportsReadingWindows(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FIFSupportsReadingLinux(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FIFSupportsReadingMacOS(fif);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Checks if a plugin can save bitmaps.
        /// </summary>
        /// <param name="fif">The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</param>
        /// <returns>True if the plugin can save bitmaps, else false.</returns>
        public static bool FIFSupportsWriting(FREE_IMAGE_FORMAT fif)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FIFSupportsWritingWindows(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FIFSupportsWritingLinux(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FIFSupportsWritingMacOS(fif);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Checks if a plugin can save bitmaps in the desired bit depth.
        /// </summary>
        /// <param name="fif">The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</param>
        /// <param name="bpp">The desired bit depth.</param>
        /// <returns>True if the plugin can save bitmaps in the desired bit depth, else false.</returns>
        public static bool FIFSupportsExportBPP(FREE_IMAGE_FORMAT fif, int bpp)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FIFSupportsExportBPPWindows(fif, bpp);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FIFSupportsExportBPPLinux(fif, bpp);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FIFSupportsExportBPPMacOS(fif, bpp);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Checks if a plugin can save a bitmap in the desired data type.
        /// </summary>
        /// <param name="fif">The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</param>
        /// <param name="type">The desired image type.</param>
        /// <returns>True if the plugin can save bitmaps as the desired type, else false.</returns>
        public static bool FIFSupportsExportType(FREE_IMAGE_FORMAT fif, FREE_IMAGE_TYPE type)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FIFSupportsExportTypeWindows(fif, type);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FIFSupportsExportTypeLinux(fif, type);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FIFSupportsExportTypeMacOS(fif, type);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Checks if a plugin can load or save an ICC profile.
        /// </summary>
        /// <param name="fif">The <see cref="FREE_IMAGE_FORMAT"/> of the plugin.</param>
        /// <returns>True if the plugin can load or save an ICC profile, else false.</returns>
        public static bool FIFSupportsICCProfiles(FREE_IMAGE_FORMAT fif)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FIFSupportsICCProfilesWindows(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FIFSupportsICCProfilesLinux(fif);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FIFSupportsICCProfilesMacOS(fif);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Multipage functions

        /// <summary>
        /// Loads a FreeImage multi-paged bitmap.
        /// Load flags can be provided by the flags parameter.
        /// </summary>
        /// <param name="fif">Format of the image.</param>
        /// <param name="filename">The complete name of the file to load.</param>
        /// <param name="create_new">When true a new bitmap is created.</param>
        /// <param name="read_only">When true the bitmap will be loaded read only.</param>
        /// <param name="keep_cache_in_memory">When true performance is increased at the cost of memory.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Handle to a FreeImage multi-paged bitmap.</returns>
        public static FIMULTIBITMAP OpenMultiBitmap(FREE_IMAGE_FORMAT fif, string filename, bool create_new, bool read_only, bool keep_cache_in_memory, FREE_IMAGE_LOAD_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return OpenMultiBitmapWindows(fif, filename, create_new, read_only, keep_cache_in_memory, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return OpenMultiBitmapLinux(fif, filename, create_new, read_only, keep_cache_in_memory, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OpenMultiBitmapMacOS(fif, filename, create_new, read_only, keep_cache_in_memory, flags);
            else
                throw new NotSupportedException();
        }

        /////// <summary>
        /////// Loads a FreeImage multi-pages bitmap from the specified handle
        /////// using the specified functions.
        /////// Load flags can be provided by the flags parameter.
        /////// </summary>
        /////// <param name="fif">Format of the image.</param>
        /////// <param name="io">IO functions used to read from the specified handle.</param>
        /////// <param name="handle">The handle to load the bitmap from.</param>
        /////// <param name="flags">Flags to enable or disable plugin-features.</param>
        /////// <returns>Handle to a FreeImage multi-paged bitmap.</returns>
        //public static FIMULTIBITMAP OpenMultiBitmapFromHandle(FREE_IMAGE_FORMAT fif, ref FreeImageIO io, fi_handle handle, FREE_IMAGE_LOAD_FLAGS flags)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return OpenMultiBitmapFromHandleWindows(fif, ref io, handle, flags);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return OpenMultiBitmapFromHandleLinux(fif, ref io, handle, flags);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return OpenMultiBitmapFromHandleMacOS(fif, ref io, handle, flags);
        //    else
        //        throw new NotSupportedException();
        //}


        /// <summary>
        /// Closes a previously opened multi-page bitmap and, when the bitmap was not opened read-only, applies any changes made to it.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="flags">Flags to enable or disable plugin-features.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool CloseMultiBitmap_(FIMULTIBITMAP bitmap, FREE_IMAGE_SAVE_FLAGS flags)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CloseMultiBitmap_Windows(bitmap, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CloseMultiBitmap_Linux(bitmap, flags);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CloseMultiBitmap_MacOS(bitmap, flags);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the number of pages currently available in the multi-paged bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <returns>Number of pages.</returns>
        public static int GetPageCount(FIMULTIBITMAP bitmap)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetPageCountWindows(bitmap);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetPageCountLinux(bitmap);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetPageCountMacOS(bitmap);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Appends a new page to the end of the bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="data">Handle to a FreeImage bitmap.</param>
        public static void AppendPage(FIMULTIBITMAP bitmap, FIBITMAP data)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                AppendPageWindows(bitmap, data);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                AppendPageLinux(bitmap, data);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                AppendPageMacOS(bitmap, data);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Inserts a new page before the given position in the bitmap.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="page">Page has to be a number smaller than the current number of pages available in the bitmap.</param>
        /// <param name="data">Handle to a FreeImage bitmap.</param>
        public static void InsertPage(FIMULTIBITMAP bitmap, int page, FIBITMAP data)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                InsertPageWindows(bitmap, page, data);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                InsertPageLinux(bitmap, page, data);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                InsertPageMacOS(bitmap, page, data);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Deletes the page on the given position.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="page">Number of the page to delete.</param>
        public static void DeletePage(FIMULTIBITMAP bitmap, int page)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                DeletePageWindows(bitmap, page);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                DeletePageLinux(bitmap, page);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                DeletePageMacOS(bitmap, page);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Locks a page in memory for editing.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="page">Number of the page to lock.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP LockPage(FIMULTIBITMAP bitmap, int page)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LockPageWindows(bitmap, page);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LockPageLinux(bitmap, page);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LockPageMacOS(bitmap, page);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Unlocks a previously locked page and gives it back to the multi-page engine.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="data">Handle to a FreeImage bitmap.</param>
        /// <param name="changed">If true, the page is applied to the multi-page bitmap.</param>
        public static void UnlockPage(FIMULTIBITMAP bitmap, FIBITMAP data, bool changed)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                UnlockPageWindows(bitmap, data, changed);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                UnlockPageLinux(bitmap, data, changed);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                UnlockPageMacOS(bitmap, data, changed);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Moves the source page to the position of the target page.
        /// </summary>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="target">New position of the page.</param>
        /// <param name="source">Old position of the page.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool MovePage(FIMULTIBITMAP bitmap, int target, int source)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return MovePageWindows(bitmap, target, source);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return MovePageLinux(bitmap, target, source);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MovePageMacOS(bitmap, target, source);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns an array of page-numbers that are currently locked in memory.
        /// When the pages parameter is null, the size of the array is returned in the count variable.
        /// </summary>
        /// <example>
        /// <code>
        /// int[] lockedPages = null;
        /// int count = 0;
        /// GetLockedPageNumbers(dib, lockedPages, ref count);
        /// lockedPages = new int[count];
        /// GetLockedPageNumbers(dib, lockedPages, ref count);
        /// </code>
        /// </example>
        /// <param name="bitmap">Handle to a FreeImage multi-paged bitmap.</param>
        /// <param name="pages">The list of locked pages in the multi-pages bitmap.
        /// If set to null, count will contain the number of pages.</param>
        /// <param name="count">If <paramref name="pages"/> is set to null count will contain the number of locked pages.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetLockedPageNumbers(FIMULTIBITMAP bitmap, int[] pages, ref int count)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetLockedPageNumbersWindows(bitmap, pages, ref count);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetLockedPageNumbersLinux(bitmap, pages, ref count);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetLockedPageNumbersMacOS(bitmap, pages, ref count);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Filetype functions

        /// <summary>
        /// Orders FreeImage to analyze the bitmap signature.
        /// </summary>
        /// <param name="filename">Name of the file to analyze.</param>
        /// <param name="size">Reserved parameter - use 0.</param>
        /// <returns>Type of the bitmap.</returns>
        public static FREE_IMAGE_FORMAT GetFileType(string filename, int size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFileTypeWindows(filename, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFileTypeLinux(filename, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFileTypeMacOS(filename, size);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Orders FreeImage to analyze the bitmap signature.
        /// Supports UNICODE filenames.
        /// </summary>
        /// <param name="filename">Name of the file to analyze.</param>
        /// <param name="size">Reserved parameter - use 0.</param>
        /// <returns>Type of the bitmap.</returns>
        public static FREE_IMAGE_FORMAT GetFileTypeU(string filename, int size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFileTypeUWindows(filename, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFileTypeULinux(filename, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFileTypeUMacOS(filename, size);
            else
                throw new NotSupportedException();
        }


        /////// <summary>
        /////// Uses the <see cref="FreeImageIO"/> structure as described in the topic bitmap management functions
        /////// to identify a bitmap type.
        /////// </summary>
        /////// <param name="io">A <see cref="FreeImageIO"/> structure with functionpointers to handle the source.</param>
        /////// <param name="handle">A handle to the source.</param>
        /////// <param name="size">Size in bytes of the source.</param>
        /////// <returns>Type of the bitmap.</returns>
        //public static FREE_IMAGE_FORMAT GetFileTypeFromHandle(ref FreeImageIO io, fi_handle handle, int size)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return GetFileTypeFromHandleWindows(ref io, handle, size);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return GetFileTypeFromHandleLinux(ref io, handle, size);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return GetFileTypeFromHandleMacOS(ref io, handle, size);
        //    else
        //        throw new NotSupportedException();
        //}


        /// <summary>
        /// Uses a memory handle to identify a bitmap type.
        /// </summary>
        /// <param name="stream">Pointer to the stream.</param>
        /// <param name="size">Size in bytes of the source.</param>
        /// <returns>Type of the bitmap.</returns>
        public static FREE_IMAGE_FORMAT GetFileTypeFromMemory(FIMEMORY stream, int size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetFileTypeFromMemoryWindows(stream, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetFileTypeFromMemoryLinux(stream, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetFileTypeFromMemoryMacOS(stream, size);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Helper functions

        /// <summary>
        /// Returns whether the platform is using Little Endian.
        /// </summary>
        /// <returns>Returns true if the platform is using Litte Endian, else false.</returns>
        public static bool IsLittleEndian()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return IsLittleEndianWindows();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return IsLittleEndianLinux();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return IsLittleEndianMacOS();
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a X11 color name into a corresponding RGB value.
        /// </summary>
        /// <param name="szColor">Name of the color to convert.</param>
        /// <param name="nRed">Red component.</param>
        /// <param name="nGreen">Green component.</param>
        /// <param name="nBlue">Blue component.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool LookupX11Color(string szColor, out byte nRed, out byte nGreen, out byte nBlue)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LookupX11ColorWindows(szColor, out nRed, out nGreen, out nBlue);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LookupX11ColorLinux(szColor, out nRed, out nGreen, out nBlue);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LookupX11ColorMacOS(szColor, out nRed, out nGreen, out nBlue);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a SVG color name into a corresponding RGB value.
        /// </summary>
        /// <param name="szColor">Name of the color to convert.</param>
        /// <param name="nRed">Red component.</param>
        /// <param name="nGreen">Green component.</param>
        /// <param name="nBlue">Blue component.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool LookupSVGColor(string szColor, out byte nRed, out byte nGreen, out byte nBlue)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return LookupSVGColorWindows(szColor, out nRed, out nGreen, out nBlue);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return LookupSVGColorLinux(szColor, out nRed, out nGreen, out nBlue);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return LookupSVGColorMacOS(szColor, out nRed, out nGreen, out nBlue);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Pixel access functions

        /// <summary>
        /// Returns a pointer to the data-bits of the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Pointer to the data-bits.</returns>
        public static IntPtr GetBits(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetBitsWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetBitsLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetBitsMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a pointer to the start of the given scanline in the bitmap's data-bits.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="scanline">Number of the scanline.</param>
        /// <returns>Pointer to the scanline.</returns>
        public static IntPtr GetScanLine(FIBITMAP dib, int scanline)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetScanLineWindows(dib, scanline);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetScanLineLinux(dib, scanline);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetScanLineMacOS(dib, scanline);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Get the pixel index of a palettized image at position (x, y), including range check (slow access).
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="x">Pixel position in horizontal direction.</param>
        /// <param name="y">Pixel position in vertical direction.</param>
        /// <param name="value">The pixel index.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetPixelIndex(FIBITMAP dib, uint x, uint y, out byte value)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetPixelIndexWindows(dib, x, y, out value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetPixelIndexLinux(dib, x, y, out value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetPixelIndexMacOS(dib, x, y, out value);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Get the pixel color of a 16-, 24- or 32-bit image at position (x, y), including range check (slow access).
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="x">Pixel position in horizontal direction.</param>
        /// <param name="y">Pixel position in vertical direction.</param>
        /// <param name="value">The pixel color.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetPixelColor(FIBITMAP dib, uint x, uint y, out RGBQUAD value)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetPixelColorWindows(dib, x, y, out value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetPixelColorLinux(dib, x, y, out value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetPixelColorMacOS(dib, x, y, out value);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Set the pixel index of a palettized image at position (x, y), including range check (slow access).
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="x">Pixel position in horizontal direction.</param>
        /// <param name="y">Pixel position in vertical direction.</param>
        /// <param name="value">The new pixel index.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetPixelIndex(FIBITMAP dib, uint x, uint y, ref byte value)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetPixelIndexWindows(dib, x, y, ref value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetPixelIndexLinux(dib, x, y, ref value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetPixelIndexMacOS(dib, x, y, ref value);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Set the pixel color of a 16-, 24- or 32-bit image at position (x, y), including range check (slow access).
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="x">Pixel position in horizontal direction.</param>
        /// <param name="y">Pixel position in vertical direction.</param>
        /// <param name="value">The new pixel color.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetPixelColor(FIBITMAP dib, uint x, uint y, ref RGBQUAD value)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetPixelColorWindows(dib, x, y, ref value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetPixelColorLinux(dib, x, y, ref value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetPixelColorMacOS(dib, x, y, ref value);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Bitmap information functions

        /// <summary>
        /// Retrieves the type of the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Type of the bitmap.</returns>
        public static FREE_IMAGE_TYPE GetImageType(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetImageTypeWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetImageTypeLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetImageTypeMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the number of colors used in a bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Palette-size for palletised bitmaps, and 0 for high-colour bitmaps.</returns>
        public static uint GetColorsUsed(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetColorsUsedWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetColorsUsedLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetColorsUsedMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the size of one pixel in the bitmap in bits.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Size of one pixel in the bitmap in bits.</returns>
        public static uint GetBPP(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetBPPWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetBPPLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetBPPMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the width of the bitmap in pixel units.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>With of the bitmap.</returns>
        public static uint GetWidth(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetWidthWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetWidthLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetWidthMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the height of the bitmap in pixel units.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Height of the bitmap.</returns>
        public static uint GetHeight(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetHeightWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetHeightLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetHeightMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the width of the bitmap in bytes.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>With of the bitmap in bytes.</returns>
        public static uint GetLine(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetLineWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetLineLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetLineMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the width of the bitmap in bytes, rounded to the next 32-bit boundary,
        /// also known as pitch or stride or scan width.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>With of the bitmap in bytes.</returns>
        public static uint GetPitch(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetPitchWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetPitchLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetPitchMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the size of the DIB-element of a FIBITMAP in memory.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Size of the DIB-element</returns>
        public static uint GetDIBSize(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetDIBSizeWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetDIBSizeLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetDIBSizeMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a pointer to the bitmap's palette.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Pointer to the bitmap's palette.</returns>
        public static IntPtr GetPalette(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetPaletteWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetPaletteLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetPaletteMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the horizontal resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The horizontal resolution, in pixels-per-meter.</returns>
        public static uint GetDotsPerMeterX(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetDotsPerMeterXWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetDotsPerMeterXLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetDotsPerMeterXMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The vertical resolution, in pixels-per-meter.</returns>
        public static uint GetDotsPerMeterY(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetDotsPerMeterYWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetDotsPerMeterYLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetDotsPerMeterYMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Set the horizontal resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="res">The new horizontal resolution.</param>
        public static void SetDotsPerMeterX(FIBITMAP dib, uint res)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                SetDotsPerMeterXWindows(dib, res);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                SetDotsPerMeterXLinux(dib, res);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                SetDotsPerMeterXMacOS(dib, res);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Set the vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="res">The new vertical resolution.</param>
        public static void SetDotsPerMeterY(FIBITMAP dib, uint res)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                SetDotsPerMeterYWindows(dib, res);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                SetDotsPerMeterYLinux(dib, res);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                SetDotsPerMeterYMacOS(dib, res);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a pointer to the <see cref="BITMAPINFOHEADER"/> of the DIB-element in a FIBITMAP.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Poiter to the header of the bitmap.</returns>
        public static IntPtr GetInfoHeader(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetInfoHeaderWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetInfoHeaderLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetInfoHeaderMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Alias for FreeImage_GetInfoHeader that returns a pointer to a <see cref="BITMAPINFO"/>
        /// rather than to a <see cref="BITMAPINFOHEADER"/>.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Pointer to the <see cref="BITMAPINFO"/> structure for the bitmap.</returns>
        public static IntPtr GetInfo(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetInfoWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetInfoLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetInfoMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Investigates the color type of the bitmap by reading the bitmap's pixel bits and analysing them.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The color type of the bitmap.</returns>
        public static FREE_IMAGE_COLOR_TYPE GetColorType(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetColorTypeWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetColorTypeLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetColorTypeMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a bit pattern describing the red color component of a pixel in a FreeImage bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The bit pattern for RED.</returns>
        public static uint GetRedMask(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetRedMaskWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetRedMaskLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetRedMaskMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a bit pattern describing the green color component of a pixel in a FreeImage bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The bit pattern for green.</returns>
        public static uint GetGreenMask(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetGreenMaskWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetGreenMaskLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetGreenMaskMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a bit pattern describing the blue color component of a pixel in a FreeImage bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The bit pattern for blue.</returns>
        public static uint GetBlueMask(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetBlueMaskWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetBlueMaskLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetBlueMaskMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the number of transparent colors in a palletised bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>The number of transparent colors in a palletised bitmap.</returns>
        public static uint GetTransparencyCount(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTransparencyCountWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTransparencyCountLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTransparencyCountMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns a pointer to the bitmap's transparency table.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Pointer to the bitmap's transparency table.</returns>
        public static IntPtr GetTransparencyTable(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTransparencyTableWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTransparencyTableLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTransparencyTableMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Tells FreeImage if it should make use of the transparency table
        /// or the alpha channel that may accompany a bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="enabled">True to enable the transparency, false to disable.</param>
        public static void SetTransparent(FIBITMAP dib, bool enabled)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                SetTransparentWindows(dib, enabled);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                SetTransparentLinux(dib, enabled);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                SetTransparentMacOS(dib, enabled);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Set the bitmap's transparency table. Only affects palletised bitmaps.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="table">Pointer to the bitmap's new transparency table.</param>
        /// <param name="count">The number of transparent colors in the new transparency table.</param>
        public static void SetTransparencyTable(FIBITMAP dib, byte[] table, int count)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                SetTransparencyTableWindows(dib, table, count);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                SetTransparencyTableLinux(dib, table, count);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                SetTransparencyTableMacOS(dib, table, count);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns whether the transparency table is enabled.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Returns true when the transparency table is enabled (1-, 4- or 8-bit images)
        /// or when the input dib contains alpha values (32-bit images). Returns false otherwise.</returns>
        public static bool IsTransparent(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return IsTransparentWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return IsTransparentLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return IsTransparentMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns whether the bitmap has a file background color.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Returns true when the image has a file background color, false otherwise.</returns>
        public static bool HasBackgroundColor(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return HasBackgroundColorWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return HasBackgroundColorLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return HasBackgroundColorMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the file background color of an image.
        /// For 8-bit images, the color index in the palette is returned in the
        /// rgbReserved member of the bkcolor parameter.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="bkcolor">The background color.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetBackgroundColor(FIBITMAP dib, out RGBQUAD bkcolor)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetBackgroundColorWindows(dib, out bkcolor);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetBackgroundColorLinux(dib, out bkcolor);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetBackgroundColorMacOS(dib, out bkcolor);
            else
                throw new NotSupportedException();
        }


        /////// <summary>
        /////// Set the file background color of an image.
        /////// When saving an image to PNG, this background color is transparently saved to the PNG file.
        /////// </summary>
        /////// <param name="dib">Handle to a FreeImage bitmap.</param>
        /////// <param name="bkcolor">The new background color.</param>
        /////// <returns>Returns true on success, false on failure.</returns>
        //public static unsafe bool SetBackgroundColor(FIBITMAP dib, ref RGBQUAD bkcolor)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return SetBackgroundColorWindows(dib, ref bkcolor);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return SetBackgroundColorLinux(dib, ref bkcolor);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return SetBackgroundColorMacOS(dib, ref bkcolor);
        //    else
        //        throw new NotSupportedException();
        //}


        /////// <summary>
        /////// Set the file background color of an image.
        /////// When saving an image to PNG, this background color is transparently saved to the PNG file.
        /////// When the bkcolor parameter is null, the background color is removed from the image.
        /////// <para>
        /////// This overloaded version of the function with an array parameter is provided to allow
        /////// passing <c>null</c> in the <paramref name="bkcolor"/> parameter. This is similar to the
        /////// original C/C++ function. Passing <c>null</c> as <paramref name="bkcolor"/> parameter will
        /////// unset the dib's previously set background color.
        /////// </para> 
        /////// </summary>
        /////// <param name="dib">Handle to a FreeImage bitmap.</param>
        /////// <param name="bkcolor">The new background color.
        /////// The first entry in the array is used.</param>
        /////// <returns>Returns true on success, false on failure.</returns>
        /////// <example>
        /////// <code>
        /////// // create a RGBQUAD color
        /////// RGBQUAD color = new RGBQUAD(Color.Green);
        /////// 
        /////// // set the dib's background color (using the other version of the function)
        /////// FreeImage.SetBackgroundColor(dib, ref color);
        /////// 
        /////// // remove it again (this only works due to the array parameter RGBQUAD[])
        /////// FreeImage.SetBackgroundColor(dib, null);
        /////// </code>
        /////// </example>
        //public static unsafe bool SetBackgroundColor(FIBITMAP dib, RGBQUAD[] bkcolor)
        //{
        //    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        //        return SetBackgroundColorWindows(dib, bkcolor);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        //        return SetBackgroundColorLinux(dib, bkcolor);
        //    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        //        return SetBackgroundColorMacOS(dib, bkcolor);
        //    else
        //        throw new NotSupportedException();
        //}


        /// <summary>
        /// Sets the index of the palette entry to be used as transparent color
        /// for the image specified. Does nothing on high color images.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="index">The index of the palette entry to be set as transparent color.</param>
        public static void SetTransparentIndex(FIBITMAP dib, int index)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                SetTransparentIndexWindows(dib, index);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                SetTransparentIndexLinux(dib, index);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                SetTransparentIndexMacOS(dib, index);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the palette entry used as transparent color for the image specified.
        /// Works for palletised images only and returns -1 for high color
        /// images or if the image has no color set to be transparent.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>the index of the palette entry used as transparent color for
        /// the image specified or -1 if there is no transparent color found
        /// (e.g. the image is a high color image).</returns>
        public static int GetTransparentIndex(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTransparentIndexWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTransparentIndexLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTransparentIndexMacOS(dib);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region ICC profile functions

        /////// <summary>
        /////// Retrieves the <see cref="FIICCPROFILE"/> data of the bitmap.
        /////// This function can also be called safely, when the original format does not support profiles.
        /////// </summary>
        /////// <param name="dib">Handle to a FreeImage bitmap.</param>
        /////// <returns>The <see cref="FIICCPROFILE"/> data of the bitmap.</returns>
        //private static FIICCPROFILE GetICCProfileExWindows(FIBITMAP dib) { unsafe { return *(FIICCPROFILE*)FreeImage.GetICCProfile(dib); } }

        /// <summary>
        /// Retrieves a pointer to the <see cref="FIICCPROFILE"/> data of the bitmap.
        /// This function can also be called safely, when the original format does not support profiles.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Pointer to the <see cref="FIICCPROFILE"/> data of the bitmap.</returns>
        public static IntPtr GetICCProfile(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetICCProfileWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetICCProfileLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetICCProfileMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Creates a new <see cref="FIICCPROFILE"/> block from ICC profile data previously read from a file
        /// or built by a color management system. The profile data is attached to the bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="data">Pointer to the new <see cref="FIICCPROFILE"/> data.</param>
        /// <param name="size">Size of the <see cref="FIICCPROFILE"/> data.</param>
        /// <returns>Pointer to the created <see cref="FIICCPROFILE"/> structure.</returns>
        public static IntPtr CreateICCProfile(FIBITMAP dib, byte[] data, int size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CreateICCProfileWindows(dib, data, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CreateICCProfileLinux(dib, data, size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CreateICCProfileMacOS(dib, data, size);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// This function destroys an <see cref="FIICCPROFILE"/> previously created by <see cref="CreateICCProfile(FIBITMAP,byte[],int)"/>.
        /// After this call the bitmap will contain no profile information.
        /// This function should be called to ensure that a stored bitmap will not contain any profile information.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        public static void DestroyICCProfile(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                DestroyICCProfileWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                DestroyICCProfileLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                DestroyICCProfileMacOS(dib);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Conversion functions

        /// <summary>
        /// Converts a bitmap to 4 bits.
        /// If the bitmap was a high-color bitmap (16, 24 or 32-bit) or if it was a
        /// monochrome or greyscale bitmap (1 or 8-bit), the end result will be a
        /// greyscale bitmap, otherwise (1-bit palletised bitmaps) it will be a palletised bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertTo4Bits(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertTo4BitsWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertTo4BitsLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertTo4BitsMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 8 bits. If the bitmap was a high-color bitmap (16, 24 or 32-bit)
        /// or if it was a monochrome or greyscale bitmap (1 or 4-bit), the end result will be a
        /// greyscale bitmap, otherwise (1 or 4-bit palletised bitmaps) it will be a palletised bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertTo8Bits(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertTo8BitsWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertTo8BitsLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertTo8BitsMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to a 8-bit greyscale image with a linear ramp.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertToGreyscale(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertToGreyscaleWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertToGreyscaleLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertToGreyscaleMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 16 bits, where each pixel has a color pattern of
        /// 5 bits red, 5 bits green and 5 bits blue. One bit in each pixel is unused.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertTo16Bits555(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertTo16Bits555Windows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertTo16Bits555Linux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertTo16Bits555MacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 16 bits, where each pixel has a color pattern of
        /// 5 bits red, 6 bits green and 5 bits blue.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertTo16Bits565(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertTo16Bits565Windows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertTo16Bits565Linux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertTo16Bits565MacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 24 bits. A clone of the input bitmap is returned for 24-bit bitmaps.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertTo24Bits(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertTo24BitsWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertTo24BitsLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertTo24BitsMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 32 bits. A clone of the input bitmap is returned for 32-bit bitmaps.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertTo32Bits(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertTo32BitsWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertTo32BitsLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertTo32BitsMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Quantizes a high-color 24-bit bitmap to an 8-bit palette color bitmap.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="quantize">Specifies the color reduction algorithm to be used.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ColorQuantize(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ColorQuantizeWindows(dib, quantize);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ColorQuantizeLinux(dib, quantize);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ColorQuantizeMacOS(dib, quantize);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// ColorQuantizeEx is an extension to the <see cref="ColorQuantize(FIBITMAP, FREE_IMAGE_QUANTIZE)"/> method that
        /// provides additional options used to quantize a 24-bit image to any
        /// number of colors (up to 256), as well as quantize a 24-bit image using a
        /// partial or full provided palette.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="quantize">Specifies the color reduction algorithm to be used.</param>
        /// <param name="PaletteSize">Size of the desired output palette.</param>
        /// <param name="ReserveSize">Size of the provided palette of ReservePalette.</param>
        /// <param name="ReservePalette">The provided palette.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ColorQuantizeEx(FIBITMAP dib, FREE_IMAGE_QUANTIZE quantize, int PaletteSize, int ReserveSize, RGBQUAD[] ReservePalette)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ColorQuantizeExWindows(dib, quantize, PaletteSize, ReserveSize, ReservePalette);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ColorQuantizeExLinux(dib, quantize, PaletteSize, ReserveSize, ReservePalette);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ColorQuantizeExMacOS(dib, quantize, PaletteSize, ReserveSize, ReservePalette);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 1-bit monochrome bitmap using a threshold T between [0..255].
        /// The function first converts the bitmap to a 8-bit greyscale bitmap.
        /// Then, any brightness level that is less than T is set to zero, otherwise to 1.
        /// For 1-bit input bitmaps, the function clones the input bitmap and builds a monochrome palette.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="t">The threshold.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Threshold(FIBITMAP dib, byte t)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ThresholdWindows(dib, t);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ThresholdLinux(dib, t);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ThresholdMacOS(dib, t);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a bitmap to 1-bit monochrome bitmap using a dithering algorithm.
        /// For 1-bit input bitmaps, the function clones the input bitmap and builds a monochrome palette.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="algorithm">The dithering algorithm to use.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Dither(FIBITMAP dib, FREE_IMAGE_DITHER algorithm)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return DitherWindows(dib, algorithm);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return DitherLinux(dib, algorithm);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return DitherMacOS(dib, algorithm);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a raw bitmap to a FreeImage bitmap.
        /// </summary>
        /// <param name="bits">Pointer to the memory block containing the raw bitmap.</param>
        /// <param name="width">The width in pixels of the raw bitmap.</param>
        /// <param name="height">The height in pixels of the raw bitmap.</param>
        /// <param name="pitch">Defines the total width of a scanline in the raw bitmap,
        /// including padding bytes.</param>
        /// <param name="bpp">The bit depth (bits per pixel) of the raw bitmap.</param>
        /// <param name="red_mask">The bit mask describing the bits used to store a single 
        /// pixel's red component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="green_mask">The bit mask describing the bits used to store a single
        /// pixel's green component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="blue_mask">The bit mask describing the bits used to store a single
        /// pixel's blue component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="topdown">If true, the raw bitmap is stored in top-down order (top-left pixel first)
        /// and in bottom-up order (bottom-left pixel first) otherwise.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertFromRawBits(IntPtr bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertFromRawBitsWindows(bits, width, height, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertFromRawBitsLinux(bits, width, height, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertFromRawBitsMacOS(bits, width, height, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Converts a raw bitmap to a FreeImage bitmap.
        /// </summary>
        /// <param name="bits">Array of bytes containing the raw bitmap.</param>
        /// <param name="width">The width in pixels of the raw bitmap.</param>
        /// <param name="height">The height in pixels of the raw bitmap.</param>
        /// <param name="pitch">Defines the total width of a scanline in the raw bitmap,
        /// including padding bytes.</param>
        /// <param name="bpp">The bit depth (bits per pixel) of the raw bitmap.</param>
        /// <param name="red_mask">The bit mask describing the bits used to store a single 
        /// pixel's red component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="green_mask">The bit mask describing the bits used to store a single
        /// pixel's green component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="blue_mask">The bit mask describing the bits used to store a single
        /// pixel's blue component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="topdown">If true, the raw bitmap is stored in top-down order (top-left pixel first)
        /// and in bottom-up order (bottom-left pixel first) otherwise.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertFromRawBits(byte[] bits, int width, int height, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertFromRawBitsWindows(bits, width, height, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertFromRawBitsLinux(bits, width, height, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertFromRawBitsMacOS(bits, width, height, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Converts a FreeImage bitmap to a raw bitmap, that is a raw piece of memory.
        /// </summary>
        /// <param name="bits">Pointer to the memory block receiving the raw bitmap.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="pitch">The desired total width in bytes of a scanline in the raw bitmap,
        /// including any padding bytes.</param>
        /// <param name="bpp">The desired bit depth (bits per pixel) of the raw bitmap.</param>
        /// <param name="red_mask">The desired bit mask describing the bits used to store a single 
        /// pixel's red component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="green_mask">The desired bit mask describing the bits used to store a single
        /// pixel's green component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="blue_mask">The desired bit mask describing the bits used to store a single
        /// pixel's blue component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="topdown">If true, the raw bitmap will be stored in top-down order (top-left pixel first)
        /// and in bottom-up order (bottom-left pixel first) otherwise.</param>
        public static void ConvertToRawBits(IntPtr bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                ConvertToRawBitsWindows(bits, dib, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                ConvertToRawBitsLinux(bits, dib, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                ConvertToRawBitsMacOS(bits, dib, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Converts a FreeImage bitmap to a raw bitmap, that is a raw piece of memory.
        /// </summary>
        /// <param name="bits">Array of bytes receiving the raw bitmap.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="pitch">The desired total width in bytes of a scanline in the raw bitmap,
        /// including any padding bytes.</param>
        /// <param name="bpp">The desired bit depth (bits per pixel) of the raw bitmap.</param>
        /// <param name="red_mask">The desired bit mask describing the bits used to store a single 
        /// pixel's red component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="green_mask">The desired bit mask describing the bits used to store a single
        /// pixel's green component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="blue_mask">The desired bit mask describing the bits used to store a single
        /// pixel's blue component in the raw bitmap. This is only applied to 16-bpp raw bitmaps.</param>
        /// <param name="topdown">If true, the raw bitmap will be stored in top-down order (top-left pixel first)
        /// and in bottom-up order (bottom-left pixel first) otherwise.</param>
        public static void ConvertToRawBits(byte[] bits, FIBITMAP dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                ConvertToRawBitsWindows(bits, dib, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                ConvertToRawBitsLinux(bits, dib, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                ConvertToRawBitsMacOS(bits, dib, pitch, bpp, red_mask, green_mask, blue_mask, topdown);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Converts a 24- or 32-bit RGB(A) standard image or a 48-bit RGB image to a FIT_RGBF type image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertToRGBF(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertToRGBFWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertToRGBFLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertToRGBFMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a non standard image whose color type is FIC_MINISBLACK
        /// to a standard 8-bit greyscale image.
        /// </summary>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="scale_linear">When true the conversion is done by scaling linearly
        /// each pixel value from [min, max] to an integer value between [0..255],
        /// where min and max are the minimum and maximum pixel values in the image.
        /// When false the conversion is done by rounding each pixel value to an integer between [0..255].
        ///
        /// Rounding is done using the following formula:
        ///
        /// dst_pixel = (BYTE) MIN(255, MAX(0, q)) where int q = int(src_pixel + 0.5);</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertToStandardType(FIBITMAP src, bool scale_linear)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertToStandardTypeWindows(src, scale_linear);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertToStandardTypeLinux(src, scale_linear);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertToStandardTypeMacOS(src, scale_linear);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts an image of any type to type dst_type.
        /// </summary>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="dst_type">Destination type.</param>
        /// <param name="scale_linear">True to scale linear, else false.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ConvertToType(FIBITMAP src, FREE_IMAGE_TYPE dst_type, bool scale_linear)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ConvertToTypeWindows(src, dst_type, scale_linear);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ConvertToTypeLinux(src, dst_type, scale_linear);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ConvertToTypeMacOS(src, dst_type, scale_linear);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Tone mapping operators

        /// <summary>
        /// Converts a High Dynamic Range image (48-bit RGB or 96-bit RGBF) to a 24-bit RGB image, suitable for display.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="tmo">The tone mapping operator to be used.</param>
        /// <param name="first_param">Parmeter depending on the used algorithm</param>
        /// <param name="second_param">Parmeter depending on the used algorithm</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP ToneMapping(FIBITMAP dib, FREE_IMAGE_TMO tmo, double first_param, double second_param)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ToneMappingWindows(dib, tmo, first_param, second_param);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ToneMappingLinux(dib, tmo, first_param, second_param);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ToneMappingMacOS(dib, tmo, first_param, second_param);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a High Dynamic Range image to a 24-bit RGB image using a global
        /// operator based on logarithmic compression of luminance values, imitating the human response to light.
        /// </summary>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="gamma">A gamma correction that is applied after the tone mapping.
        /// A value of 1 means no correction.</param>
        /// <param name="exposure">Scale factor allowing to adjust the brightness of the output image.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP TmoDrago03(FIBITMAP src, double gamma, double exposure)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return TmoDrago03Windows(src, gamma, exposure);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return TmoDrago03Linux(src, gamma, exposure);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return TmoDrago03MacOS(src, gamma, exposure);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Converts a High Dynamic Range image to a 24-bit RGB image using a global operator inspired
        /// by photoreceptor physiology of the human visual system.
        /// </summary>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="intensity">Controls the overall image intensity in the range [-8, 8].</param>
        /// <param name="contrast">Controls the overall image contrast in the range [0.3, 1.0[.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP TmoReinhard05(FIBITMAP src, double intensity, double contrast)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return TmoReinhard05Windows(src, intensity, contrast);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return TmoReinhard05Linux(src, intensity, contrast);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return TmoReinhard05MacOS(src, intensity, contrast);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Apply the Gradient Domain High Dynamic Range Compression to a RGBF image and convert to 24-bit RGB.
        /// </summary>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="color_saturation">Color saturation (s parameter in the paper) in [0.4..0.6]</param>
        /// <param name="attenuation">Atenuation factor (beta parameter in the paper) in [0.8..0.9]</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP TmoFattal02(FIBITMAP src, double color_saturation, double attenuation)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return TmoFattal02Windows(src, color_saturation, attenuation);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return TmoFattal02Linux(src, color_saturation, attenuation);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return TmoFattal02MacOS(src, color_saturation, attenuation);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Compression functions

        /// <summary>
        /// Compresses a source buffer into a target buffer, using the ZLib library.
        /// </summary>
        /// <param name="target">Pointer to the target buffer.</param>
        /// <param name="target_size">Size of the target buffer.
        /// Must be at least 0.1% larger than source_size plus 12 bytes.</param>
        /// <param name="source">Pointer to the source buffer.</param>
        /// <param name="source_size">Size of the source buffer.</param>
        /// <returns>The actual size of the compressed buffer, or 0 if an error occurred.</returns>
        public static uint ZLibCompress(byte[] target, uint target_size, byte[] source, uint source_size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ZLibCompressWindows(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ZLibCompressLinux(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ZLibCompressMacOS(target, target_size, source, source_size);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Decompresses a source buffer into a target buffer, using the ZLib library.
        /// </summary>
        /// <param name="target">Pointer to the target buffer.</param>
        /// <param name="target_size">Size of the target buffer.
        /// Must have been saved outlide of zlib.</param>
        /// <param name="source">Pointer to the source buffer.</param>
        /// <param name="source_size">Size of the source buffer.</param>
        /// <returns>The actual size of the uncompressed buffer, or 0 if an error occurred.</returns>
        public static uint ZLibUncompress(byte[] target, uint target_size, byte[] source, uint source_size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ZLibUncompressWindows(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ZLibUncompressLinux(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ZLibUncompressMacOS(target, target_size, source, source_size);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Compresses a source buffer into a target buffer, using the ZLib library.
        /// </summary>
        /// <param name="target">Pointer to the target buffer.</param>
        /// <param name="target_size">Size of the target buffer.
        /// Must be at least 0.1% larger than source_size plus 24 bytes.</param>
        /// <param name="source">Pointer to the source buffer.</param>
        /// <param name="source_size">Size of the source buffer.</param>
        /// <returns>The actual size of the compressed buffer, or 0 if an error occurred.</returns>
        public static uint ZLibGZip(byte[] target, uint target_size, byte[] source, uint source_size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ZLibGZipWindows(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ZLibGZipLinux(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ZLibGZipMacOS(target, target_size, source, source_size);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Decompresses a source buffer into a target buffer, using the ZLib library.
        /// </summary>
        /// <param name="target">Pointer to the target buffer.</param>
        /// <param name="target_size">Size of the target buffer.
        /// Must have been saved outlide of zlib.</param>
        /// <param name="source">Pointer to the source buffer.</param>
        /// <param name="source_size">Size of the source buffer.</param>
        /// <returns>The actual size of the uncompressed buffer, or 0 if an error occurred.</returns>
        public static uint ZLibGUnzip(byte[] target, uint target_size, byte[] source, uint source_size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ZLibGUnzipWindows(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ZLibGUnzipLinux(target, target_size, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ZLibGUnzipMacOS(target, target_size, source, source_size);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Generates a CRC32 checksum.
        /// </summary>
        /// <param name="crc">The CRC32 checksum to begin with.</param>
        /// <param name="source">Pointer to the source buffer.
        /// If the value is 0, the function returns the required initial value for the crc.</param>
        /// <param name="source_size">Size of the source buffer.</param>
        /// <returns></returns>
        public static uint ZLibCRC32(uint crc, byte[] source, uint source_size)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ZLibCRC32Windows(crc, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ZLibCRC32Linux(crc, source, source_size);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ZLibCRC32MacOS(crc, source, source_size);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Tag creation and destruction

        /// <summary>
        /// Allocates a new <see cref="FITAG"/> object.
        /// This object must be destroyed with a call to
        /// <see cref="FreeImageAPI.FreeImage.DeleteTag(FITAG)"/> when no longer in use.
        /// </summary>
        /// <returns>The new <see cref="FITAG"/>.</returns>
        public static FITAG CreateTag()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CreateTagWindows();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CreateTagLinux();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CreateTagMacOS();
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Delete a previously allocated <see cref="FITAG"/> object.
        /// </summary>
        /// <param name="tag">The <see cref="FITAG"/> to destroy.</param>
        public static void DeleteTag(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                DeleteTagWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                DeleteTagLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                DeleteTagMacOS(tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Creates and returns a copy of a <see cref="FITAG"/> object.
        /// </summary>
        /// <param name="tag">The <see cref="FITAG"/> to clone.</param>
        /// <returns>The new <see cref="FITAG"/>.</returns>
        public static FITAG CloneTag(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CloneTagWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CloneTagLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CloneTagMacOS(tag);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Tag accessors

        ///// <summary>
        ///// Returns the tag field name (unique inside a metadata model).
        ///// </summary>
        ///// <param name="tag">The tag field.</param>
        ///// <returns>The field name.</returns>
        //public static unsafe string GetTagKey(FITAG tag) { return PtrToStr(GetTagKey_(tag)); }
        //[DllImport(FreeImageLibrary, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagKey")]
        //private static unsafe extern byte* GetTagKey_(FITAG tag);

        ///// <summary>
        ///// Returns the tag description.
        ///// </summary>
        ///// <param name="tag">The tag field.</param>
        ///// <returns>The description or NULL if unavailable.</returns>
        //public static unsafe string GetTagDescription(FITAG tag) { return PtrToStr(GetTagDescription_(tag)); }
        //[DllImport(FreeImageLibrary, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_GetTagDescription")]
        //private static unsafe extern byte* GetTagDescription_(FITAG tag);

        /// <summary>
        /// Returns the tag ID.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <returns>The ID or 0 if unavailable.</returns>
        public static ushort GetTagID(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTagIDWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTagIDLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTagIDMacOS(tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the tag data type.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <returns>The tag type.</returns>
        public static FREE_IMAGE_MDTYPE GetTagType(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTagTypeWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTagTypeLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTagTypeMacOS(tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the number of components in the tag (in tag type units).
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <returns>The number of components.</returns>
        public static uint GetTagCount(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTagCountWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTagCountLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTagCountMacOS(tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the length of the tag value in bytes.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <returns>The length of the tag value.</returns>
        public static uint GetTagLength(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTagLengthWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTagLengthLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTagLengthMacOS(tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Returns the tag value.
        /// It is up to the programmer to interpret the returned pointer correctly,
        /// according to the results of GetTagType and GetTagCount.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <returns>Pointer to the value.</returns>
        public static IntPtr GetTagValue(FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetTagValueWindows(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetTagValueLinux(tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetTagValueMacOS(tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the tag field name.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="key">The new name.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagKey(FITAG tag, string key)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagKeyWindows(tag, key);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagKeyLinux(tag, key);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagKeyMacOS(tag, key);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the tag description.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="description">The new description.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagDescription(FITAG tag, string description)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagDescriptionWindows(tag, description);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagDescriptionLinux(tag, description);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagDescriptionMacOS(tag, description);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the tag ID.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="id">The new ID.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagID(FITAG tag, ushort id)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagIDWindows(tag, id);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagIDLinux(tag, id);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagIDMacOS(tag, id);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the tag data type.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="type">The new type.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagType(FITAG tag, FREE_IMAGE_MDTYPE type)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagTypeWindows(tag, type);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagTypeLinux(tag, type);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagTypeMacOS(tag, type);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the number of data in the tag.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="count">New number of data.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagCount(FITAG tag, uint count)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagCountWindows(tag, count);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagCountLinux(tag, count);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagCountMacOS(tag, count);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the length of the tag value in bytes.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="length">The new length.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagLength(FITAG tag, uint length)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagLengthWindows(tag, length);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagLengthLinux(tag, length);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagLengthMacOS(tag, length);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Sets the tag value.
        /// </summary>
        /// <param name="tag">The tag field.</param>
        /// <param name="value">Pointer to the new value.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetTagValue(FITAG tag, byte[] value)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetTagValueWindows(tag, value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetTagValueLinux(tag, value);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetTagValueMacOS(tag, value);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Metadata iterator

        /// <summary>
        /// Provides information about the first instance of a tag that matches the metadata model.
        /// </summary>
        /// <param name="model">The model to match.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="tag">Tag that matches the metadata model.</param>
        /// <returns>Unique search handle that can be used to call FindNextMetadata or FindCloseMetadata.
        /// Null if the metadata model does not exist.</returns>
        public static FIMETADATA FindFirstMetadata(FREE_IMAGE_MDMODEL model, FIBITMAP dib, out FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FindFirstMetadataWindows(model, dib, out tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FindFirstMetadataLinux(model, dib, out tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FindFirstMetadataMacOS(model, dib, out tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Find the next tag, if any, that matches the metadata model argument in a previous call
        /// to FindFirstMetadata, and then alters the tag object contents accordingly.
        /// </summary>
        /// <param name="mdhandle">Unique search handle provided by FindFirstMetadata.</param>
        /// <param name="tag">Tag that matches the metadata model.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool FindNextMetadata(FIMETADATA mdhandle, out FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FindNextMetadataWindows(mdhandle, out tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FindNextMetadataLinux(mdhandle, out tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FindNextMetadataMacOS(mdhandle, out tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Closes the specified metadata search handle and releases associated resources.
        /// </summary>
        /// <param name="mdhandle">The handle to close.</param>
        public static void FindCloseMetadata_(FIMETADATA mdhandle)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                FindCloseMetadata_Windows(mdhandle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                FindCloseMetadata_Linux(mdhandle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                FindCloseMetadata_MacOS(mdhandle);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Metadata setter and getter

        /// <summary>
        /// Retrieve a metadata attached to a dib.
        /// </summary>
        /// <param name="model">The metadata model to look for.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="key">The metadata field name.</param>
        /// <param name="tag">A FITAG structure returned by the function.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetMetadata(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, out FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetMetadataWindows(model, dib, key, out tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetMetadataLinux(model, dib, key, out tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetMetadataMacOS(model, dib, key, out tag);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Attach a new FreeImage tag to a dib.
        /// </summary>
        /// <param name="model">The metadata model used to store the tag.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="key">The tag field name.</param>
        /// <param name="tag">The FreeImage tag to be attached.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetMetadata(FREE_IMAGE_MDMODEL model, FIBITMAP dib, string key, FITAG tag)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetMetadataWindows(model, dib, key, tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetMetadataLinux(model, dib, key, tag);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetMetadataMacOS(model, dib, key, tag);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Metadata helper functions

        /// <summary>
        /// Returns the number of tags contained in the model metadata model attached to the input dib.
        /// </summary>
        /// <param name="model">The metadata model.</param>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Number of tags contained in the metadata model.</returns>
        public static uint GetMetadataCount(FREE_IMAGE_MDMODEL model, FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetMetadataCountWindows(model, dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetMetadataCountLinux(model, dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetMetadataCountMacOS(model, dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Copies the metadata of FreeImage bitmap to another.
        /// </summary>
        /// <param name="dst">The FreeImage bitmap to copy the metadata to.</param>
        /// <param name="src">The FreeImage bitmap to copy the metadata from.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool CloneMetadata(FIBITMAP dst, FIBITMAP src)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CloneMetadataWindows(dst, src);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CloneMetadataLinux(dst, src);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CloneMetadataMacOS(dst, src);
            else
                throw new NotSupportedException();
        }


        ///// <summary>
        ///// Converts a FreeImage tag structure to a string that represents the interpreted tag value.
        ///// The function is not thread safe.
        ///// </summary>
        ///// <param name="model">The metadata model.</param>
        ///// <param name="tag">The interpreted tag value.</param>
        ///// <param name="Make">Reserved.</param>
        ///// <returns>The representing string.</returns>
        //public static unsafe string TagToString(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make) { return PtrToStr(TagToString_(model, tag, Make)); }
        //[DllImport(FreeImageLibrary, CharSet = CharSet.Ansi, EntryPoint = "FreeImage_TagToString")]
        //private static unsafe extern byte* TagToString_(FREE_IMAGE_MDMODEL model, FITAG tag, uint Make);

        #endregion

        #region Rotation and flipping

        /// <summary>
        /// This function rotates a 1-, 8-bit greyscale or a 24-, 32-bit color image by means of 3 shears.
        /// 1-bit images rotation is limited to integer multiple of 90°.
        /// <c>null</c> is returned for other values.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="angle">The angle of rotation.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        [Obsolete("RotateClassic is deprecated (use Rotate instead).")]
        public static FIBITMAP RotateClassic(FIBITMAP dib, double angle)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return RotateClassicWindows(dib, angle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return RotateClassicLinux(dib, angle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RotateClassicMacOS(dib, angle);
            else
                throw new NotSupportedException();
        }


        public static FIBITMAP Rotate(FIBITMAP dib, double angle, IntPtr backgroundColor)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return RotateWindows(dib, angle, backgroundColor);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return RotateLinux(dib, angle, backgroundColor);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RotateMacOS(dib, angle, backgroundColor);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// This function performs a rotation and / or translation of an 8-bit greyscale,
        /// 24- or 32-bit image, using a 3rd order (cubic) B-Spline.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="angle">The angle of rotation.</param>
        /// <param name="x_shift">Horizontal image translation.</param>
        /// <param name="y_shift">Vertical image translation.</param>
        /// <param name="x_origin">Rotation center x-coordinate.</param>
        /// <param name="y_origin">Rotation center y-coordinate.</param>
        /// <param name="use_mask">When true the irrelevant part of the image is set to a black color,
        /// otherwise, a mirroring technique is used to fill irrelevant pixels.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP RotateEx(FIBITMAP dib, double angle, double x_shift, double y_shift, double x_origin, double y_origin, bool use_mask)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return RotateExWindows(dib, angle, x_shift, y_shift, x_origin, y_origin, use_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return RotateExLinux(dib, angle, x_shift, y_shift, x_origin, y_origin, use_mask);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RotateExMacOS(dib, angle, x_shift, y_shift, x_origin, y_origin, use_mask);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Flip the input dib horizontally along the vertical axis.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool FlipHorizontal(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FlipHorizontalWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FlipHorizontalLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FlipHorizontalMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Flip the input dib vertically along the horizontal axis.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool FlipVertical(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FlipVerticalWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FlipVerticalLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FlipVerticalMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Performs a lossless rotation or flipping on a JPEG file.
        /// </summary>
        /// <param name="src_file">Source file.</param>
        /// <param name="dst_file">Destination file; can be the source file; will be overwritten.</param>
        /// <param name="operation">The operation to apply.</param>
        /// <param name="perfect">To avoid lossy transformation, you can set the perfect parameter to true.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool JPEGTransform(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return JPEGTransformWindows(src_file, dst_file, operation, perfect);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return JPEGTransformLinux(src_file, dst_file, operation, perfect);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return JPEGTransformMacOS(src_file, dst_file, operation, perfect);
            else
                throw new NotSupportedException();
        }

        /// <summary>
        /// Performs a lossless rotation or flipping on a JPEG file.
        /// Supports UNICODE filenames.
        /// </summary>
        /// <param name="src_file">Source file.</param>
        /// <param name="dst_file">Destination file; can be the source file; will be overwritten.</param>
        /// <param name="operation">The operation to apply.</param>
        /// <param name="perfect">To avoid lossy transformation, you can set the perfect parameter to true.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool JPEGTransformU(string src_file, string dst_file, FREE_IMAGE_JPEG_OPERATION operation, bool perfect)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return JPEGTransformUWindows(src_file, dst_file, operation, perfect);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return JPEGTransformULinux(src_file, dst_file, operation, perfect);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return JPEGTransformUMacOS(src_file, dst_file, operation, perfect);
            else
                throw new NotSupportedException();
        }

        #endregion

        #region Upsampling / downsampling

        /// <summary>
        /// Performs resampling (or scaling, zooming) of a greyscale or RGB(A) image
        /// to the desired destination width and height.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="dst_width">Destination width.</param>
        /// <param name="dst_height">Destination height.</param>
        /// <param name="filter">The filter to apply.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Rescale(FIBITMAP dib, int dst_width, int dst_height, FREE_IMAGE_FILTER filter)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return RescaleWindows(dib, dst_width, dst_height, filter);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return RescaleLinux(dib, dst_width, dst_height, filter);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return RescaleMacOS(dib, dst_width, dst_height, filter);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Creates a thumbnail from a greyscale or RGB(A) image, keeping aspect ratio.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="max_pixel_size">Thumbnail square size.</param>
        /// <param name="convert">When true HDR images are transperantly converted to standard images.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP MakeThumbnail(FIBITMAP dib, int max_pixel_size, bool convert)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return MakeThumbnailWindows(dib, max_pixel_size, convert);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return MakeThumbnailLinux(dib, max_pixel_size, convert);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MakeThumbnailMacOS(dib, max_pixel_size, convert);
            else
                throw new NotSupportedException();
        }


        public static FIBITMAP EnlargeCanvas(FIBITMAP dib, int left, int top, int right, int bottom, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return EnlargeCanvasWindows(dib, left, top, right, bottom, color, options);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return EnlargeCanvasLinux(dib, left, top, right, bottom, color, options);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return EnlargeCanvasMacOS(dib, left, top, right, bottom, color, options);
            else
                throw new NotSupportedException();
        }

        #endregion

        #region Color manipulation

        /// <summary>
        /// Perfoms an histogram transformation on a 8-, 24- or 32-bit image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="lookUpTable">The lookup table.
        /// It's size is assumed to be 256 in length.</param>
        /// <param name="channel">The color channel to be transformed.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool AdjustCurve(FIBITMAP dib, byte[] lookUpTable, FREE_IMAGE_COLOR_CHANNEL channel)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AdjustCurveWindows(dib, lookUpTable, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AdjustCurveLinux(dib, lookUpTable, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AdjustCurveMacOS(dib, lookUpTable, channel);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Performs gamma correction on a 8-, 24- or 32-bit image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="gamma">The parameter represents the gamma value to use (gamma > 0).
        /// A value of 1.0 leaves the image alone, less than one darkens it, and greater than one lightens it.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool AdjustGamma(FIBITMAP dib, double gamma)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AdjustGammaWindows(dib, gamma);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AdjustGammaLinux(dib, gamma);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AdjustGammaMacOS(dib, gamma);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Adjusts the brightness of a 8-, 24- or 32-bit image by a certain amount.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="percentage">A value 0 means no change,
        /// less than 0 will make the image darker and greater than 0 will make the image brighter.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool AdjustBrightness(FIBITMAP dib, double percentage)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AdjustBrightnessWindows(dib, percentage);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AdjustBrightnessLinux(dib, percentage);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AdjustBrightnessMacOS(dib, percentage);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Adjusts the contrast of a 8-, 24- or 32-bit image by a certain amount.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="percentage">A value 0 means no change,
        /// less than 0 will decrease the contrast and greater than 0 will increase the contrast of the image.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool AdjustContrast(FIBITMAP dib, double percentage)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AdjustContrastWindows(dib, percentage);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AdjustContrastLinux(dib, percentage);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AdjustContrastMacOS(dib, percentage);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Inverts each pixel data.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool Invert(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return InvertWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return InvertLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return InvertMacOS(dib);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Computes the image histogram.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="histo">Array of integers with a size of 256.</param>
        /// <param name="channel">Channel to compute from.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetHistogram(FIBITMAP dib, int[] histo, FREE_IMAGE_COLOR_CHANNEL channel)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetHistogramWindows(dib, histo, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetHistogramLinux(dib, histo, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetHistogramMacOS(dib, histo, channel);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Channel processing

        /// <summary>
        /// Retrieves the red, green, blue or alpha channel of a 24- or 32-bit image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="channel">The color channel to extract.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP GetChannel(FIBITMAP dib, FREE_IMAGE_COLOR_CHANNEL channel)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetChannelWindows(dib, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetChannelLinux(dib, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetChannelMacOS(dib, channel);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Insert a 8-bit dib into a 24- or 32-bit image.
        /// Both images must have to same width and height.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="dib8">Handle to the bitmap to insert.</param>
        /// <param name="channel">The color channel to replace.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetChannel(FIBITMAP dib, FIBITMAP dib8, FREE_IMAGE_COLOR_CHANNEL channel)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetChannelWindows(dib, dib8, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetChannelLinux(dib, dib8, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetChannelMacOS(dib, dib8, channel);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Retrieves the real part, imaginary part, magnitude or phase of a complex image.
        /// </summary>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="channel">The color channel to extract.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP GetComplexChannel(FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetComplexChannelWindows(src, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetComplexChannelLinux(src, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetComplexChannelMacOS(src, channel);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Set the real or imaginary part of a complex image.
        /// Both images must have to same width and height.
        /// </summary>
        /// <param name="dst">Handle to a FreeImage bitmap.</param>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="channel">The color channel to replace.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetComplexChannel(FIBITMAP dst, FIBITMAP src, FREE_IMAGE_COLOR_CHANNEL channel)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SetComplexChannelWindows(dst, src, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SetComplexChannelLinux(dst, src, channel);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SetComplexChannelMacOS(dst, src, channel);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Copy / Paste / Composite routines

        /// <summary>
        /// Copy a sub part of the current dib image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="left">Specifies the left position of the cropped rectangle.</param>
        /// <param name="top">Specifies the top position of the cropped rectangle.</param>
        /// <param name="right">Specifies the right position of the cropped rectangle.</param>
        /// <param name="bottom">Specifies the bottom position of the cropped rectangle.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Copy(FIBITMAP dib, int left, int top, int right, int bottom)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CopyWindows(dib, left, top, right, bottom);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CopyLinux(dib, left, top, right, bottom);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CopyMacOS(dib, left, top, right, bottom);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Alpha blend or combine a sub part image with the current dib image.
        /// The bit depth of the dst bitmap must be greater than or equal to the bit depth of the src.
        /// </summary>
        /// <param name="dst">Handle to a FreeImage bitmap.</param>
        /// <param name="src">Handle to a FreeImage bitmap.</param>
        /// <param name="left">Specifies the left position of the sub image.</param>
        /// <param name="top">Specifies the top position of the sub image.</param>
        /// <param name="alpha">alpha blend factor.
        /// The source and destination images are alpha blended if alpha=0..255.
        /// If alpha > 255, then the source image is combined to the destination image.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool Paste(FIBITMAP dst, FIBITMAP src, int left, int top, int alpha)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return PasteWindows(dst, src, left, top, alpha);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return PasteLinux(dst, src, left, top, alpha);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return PasteMacOS(dst, src, left, top, alpha);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// This function composite a transparent foreground image against a single background color or
        /// against a background image.
        /// </summary>
        /// <param name="fg">Handle to a FreeImage bitmap.</param>
        /// <param name="useFileBkg">When true the background of fg is used if it contains one.</param>
        /// <param name="appBkColor">The application background is used if useFileBkg is false.</param>
        /// <param name="bg">Image used as background when useFileBkg is false or fg has no background
        /// and appBkColor is null.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Composite(FIBITMAP fg, bool useFileBkg, ref RGBQUAD appBkColor, FIBITMAP bg)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CompositeWindows(fg, useFileBkg, ref appBkColor, bg);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CompositeLinux(fg, useFileBkg, ref appBkColor, bg);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CompositeMacOS(fg, useFileBkg, ref appBkColor, bg);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// This function composite a transparent foreground image against a single background color or
        /// against a background image.
        /// </summary>
        /// <param name="fg">Handle to a FreeImage bitmap.</param>
        /// <param name="useFileBkg">When true the background of fg is used if it contains one.</param>
        /// <param name="appBkColor">The application background is used if useFileBkg is false
        /// and 'appBkColor' is not null.</param>
        /// <param name="bg">Image used as background when useFileBkg is false or fg has no background
        /// and appBkColor is null.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Composite(FIBITMAP fg, bool useFileBkg, RGBQUAD[] appBkColor, FIBITMAP bg)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return CompositeWindows(fg, useFileBkg, appBkColor, bg);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return CompositeLinux(fg, useFileBkg, appBkColor, bg);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return CompositeMacOS(fg, useFileBkg, appBkColor, bg);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Performs a lossless crop on a JPEG file.
        /// </summary>
        /// <param name="src_file">Source filename.</param>
        /// <param name="dst_file">Destination filename.</param>
        /// <param name="left">Specifies the left position of the cropped rectangle.</param>
        /// <param name="top">Specifies the top position of the cropped rectangle.</param>
        /// <param name="right">Specifies the right position of the cropped rectangle.</param>
        /// <param name="bottom">Specifies the bottom position of the cropped rectangle.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool JPEGCrop(string src_file, string dst_file, int left, int top, int right, int bottom)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return JPEGCropWindows(src_file, dst_file, left, top, right, bottom);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return JPEGCropLinux(src_file, dst_file, left, top, right, bottom);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return JPEGCropMacOS(src_file, dst_file, left, top, right, bottom);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Performs a lossless crop on a JPEG file.
        /// Supports UNICODE filenames.
        /// </summary>
        /// <param name="src_file">Source filename.</param>
        /// <param name="dst_file">Destination filename.</param>
        /// <param name="left">Specifies the left position of the cropped rectangle.</param>
        /// <param name="top">Specifies the top position of the cropped rectangle.</param>
        /// <param name="right">Specifies the right position of the cropped rectangle.</param>
        /// <param name="bottom">Specifies the bottom position of the cropped rectangle.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool JPEGCropU(string src_file, string dst_file, int left, int top, int right, int bottom)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return JPEGCropUWindows(src_file, dst_file, left, top, right, bottom);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return JPEGCropULinux(src_file, dst_file, left, top, right, bottom);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return JPEGCropUMacOS(src_file, dst_file, left, top, right, bottom);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Applies the alpha value of each pixel to its color components.
        /// The aplha value stays unchanged.
        /// Only works with 32-bits color depth.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool PreMultiplyWithAlpha(FIBITMAP dib)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return PreMultiplyWithAlphaWindows(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return PreMultiplyWithAlphaLinux(dib);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return PreMultiplyWithAlphaMacOS(dib);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Miscellaneous algorithms

        /// <summary>
        /// Solves a Poisson equation, remap result pixels to [0..1] and returns the solution.
        /// </summary>
        /// <param name="Laplacian">Handle to a FreeImage bitmap.</param>
        /// <param name="ncycle">Number of cycles in the multigrid algorithm (usually 2 or 3)</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP MultigridPoissonSolver(FIBITMAP Laplacian, int ncycle)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return MultigridPoissonSolverWindows(Laplacian, ncycle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return MultigridPoissonSolverLinux(Laplacian, ncycle);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return MultigridPoissonSolverMacOS(Laplacian, ncycle);
            else
                throw new NotSupportedException();
        }


        #endregion

        #region Colors

        /// <summary>
        /// Creates a lookup table to be used with <see cref="AdjustCurve"/> which may adjusts brightness and
        /// contrast, correct gamma and invert the image with a single call to <see cref="AdjustCurve"/>.
        /// </summary>
        /// <param name="lookUpTable">Output lookup table to be used with <see cref="AdjustCurve"/>.
        /// The size of 'lookUpTable' is assumed to be 256.</param>
        /// <param name="brightness">Percentage brightness value where -100 &lt;= brightness &lt;= 100.
        /// <para>A value of 0 means no change, less than 0 will make the image darker and greater
        /// than 0 will make the image brighter.</para></param>
        /// <param name="contrast">Percentage contrast value where -100 &lt;= contrast &lt;= 100.
        /// <para>A value of 0 means no change, less than 0 will decrease the contrast
        /// and greater than 0 will increase the contrast of the image.</para></param>
        /// <param name="gamma">Gamma value to be used for gamma correction.
        /// <para>A value of 1.0 leaves the image alone, less than one darkens it,
        /// and greater than one lightens it.</para></param>
        /// <param name="invert">If set to true, the image will be inverted.</param>
        /// <returns>The number of adjustments applied to the resulting lookup table
        /// compared to a blind lookup table.</returns>
        /// <remarks>
        /// This function creates a lookup table to be used with <see cref="AdjustCurve"/> which may adjust
        /// brightness and contrast, correct gamma and invert the image with a single call to
        /// <see cref="AdjustCurve"/>. If more than one of these image display properties need to be adjusted,
        /// using a combined lookup table should be preferred over calling each adjustment function
        /// separately. That's particularly true for huge images or if performance is an issue. Then,
        /// the expensive process of iterating over all pixels of an image is performed only once and
        /// not up to four times.
        /// <para/>
        /// Furthermore, the lookup table created does not depend on the order, in which each single
        /// adjustment operation is performed. Due to rounding and byte casting issues, it actually
        /// matters in which order individual adjustment operations are performed. Both of the following
        /// snippets most likely produce different results:
        /// <para/>
        /// <code>
        /// // snippet 1: contrast, brightness
        /// AdjustContrast(dib, 15.0);
        /// AdjustBrightness(dib, 50.0); 
        /// </code>
        /// <para/>
        /// <code>
        /// // snippet 2: brightness, contrast
        /// AdjustBrightness(dib, 50.0);
        /// AdjustContrast(dib, 15.0);
        /// </code>
        /// <para/>
        /// Better and even faster would be snippet 3:
        /// <para/>
        /// <code>
        /// // snippet 3:
        /// byte[] lut = new byte[256];
        /// GetAdjustColorsLookupTable(lut, 50.0, 15.0, 1.0, false);
        /// AdjustCurve(dib, lut, FREE_IMAGE_COLOR_CHANNEL.FICC_RGB);
        /// </code>
        /// <para/>
        /// This function is also used internally by <see cref="AdjustColors"/>, which does not return the
        /// lookup table, but uses it to call <see cref="AdjustCurve"/> on the passed image.
        /// </remarks>
        public static int GetAdjustColorsLookupTable(byte[] lookUpTable, double brightness, double contrast, double gamma, bool invert)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetAdjustColorsLookupTableWindows(lookUpTable, brightness, contrast, gamma, invert);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetAdjustColorsLookupTableLinux(lookUpTable, brightness, contrast, gamma, invert);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetAdjustColorsLookupTableMacOS(lookUpTable, brightness, contrast, gamma, invert);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Adjusts an image's brightness, contrast and gamma as well as it may
        /// optionally invert the image within a single operation.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="brightness">Percentage brightness value where -100 &lt;= brightness &lt;= 100.
        /// <para>A value of 0 means no change, less than 0 will make the image darker and greater
        /// than 0 will make the image brighter.</para></param>
        /// <param name="contrast">Percentage contrast value where -100 &lt;= contrast &lt;= 100.
        /// <para>A value of 0 means no change, less than 0 will decrease the contrast
        /// and greater than 0 will increase the contrast of the image.</para></param>
        /// <param name="gamma">Gamma value to be used for gamma correction.
        /// <para>A value of 1.0 leaves the image alone, less than one darkens it,
        /// and greater than one lightens it.</para>
        /// This parameter must not be zero or smaller than zero.
        /// If so, it will be ignored and no gamma correction will be performed on the image.</param>
        /// <param name="invert">If set to true, the image will be inverted.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        /// <remarks>
        /// This function adjusts an image's brightness, contrast and gamma as well as it
        /// may optionally invert the image within a single operation. If more than one of
        /// these image display properties need to be adjusted, using this function should
        /// be preferred over calling each adjustment function separately. That's particularly
        /// true for huge images or if performance is an issue.
        /// <para/>
        /// This function relies on <see cref="GetAdjustColorsLookupTable"/>,
        /// which creates a single lookup table, that combines all adjustment operations requested.
        /// <para/>
        /// Furthermore, the lookup table created by <see cref="GetAdjustColorsLookupTable"/> does
        /// not depend on the order, in which each single adjustment operation is performed.
        /// Due to rounding and byte casting issues, it actually matters in which order individual
        /// adjustment operations are performed. Both of the following snippets most likely produce
        /// different results:
        /// <para/>
        /// <code>
        /// // snippet 1: contrast, brightness
        /// AdjustContrast(dib, 15.0);
        /// AdjustBrightness(dib, 50.0);
        /// </code>
        /// <para/>
        /// <code>
        /// // snippet 2: brightness, contrast
        /// AdjustBrightness(dib, 50.0);
        /// AdjustContrast(dib, 15.0);
        /// </code>
        /// <para/>
        /// Better and even faster would be snippet 3:
        /// <para/>
        /// <code>
        /// // snippet 3:
        /// AdjustColors(dib, 50.0, 15.0, 1.0, false);
        /// </code>
        /// </remarks>
        public static bool AdjustColors(FIBITMAP dib, double brightness, double contrast, double gamma, bool invert)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AdjustColorsWindows(dib, brightness, contrast, gamma, invert);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return AdjustColorsLinux(dib, brightness, contrast, gamma, invert);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return AdjustColorsMacOS(dib, brightness, contrast, gamma, invert);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Applies color mapping for one or several colors on a 1-, 4- or 8-bit
        /// palletized or a 16-, 24- or 32-bit high color image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="srccolors">Array of colors to be used as the mapping source.</param>
        /// <param name="dstcolors">Array of colors to be used as the mapping destination.</param>
        /// <param name="count">The number of colors to be mapped. This is the size of both
        /// srccolors and dstcolors.</param>
        /// <param name="ignore_alpha">If true, 32-bit images and colors are treated as 24-bit.</param>
        /// <param name="swap">If true, source and destination colors are swapped, that is,
        /// each destination color is also mapped to the corresponding source color.</param>
        /// <returns>The total number of pixels changed.</returns>
        /// <remarks>
        /// This function maps up to <paramref name="count"/> colors specified in
        /// <paramref name="srccolors"/> to these specified in <paramref name="dstcolors"/>.
        /// Thereby, color <i>srccolors[N]</i>, if found in the image, will be replaced by color
        /// <i>dstcolors[N]</i>. If <paramref name="swap"/> is <b>true</b>, additionally all colors
        /// specified in <paramref name="dstcolors"/> are also mapped to these specified
        /// in <paramref name="srccolors"/>. For high color images, the actual image data will be
        /// modified whereas, for palletized images only the palette will be changed.
        /// <para/>
        /// The function returns the number of pixels changed or zero, if no pixels were changed. 
        /// <para/>
        /// Both arrays <paramref name="srccolors"/> and <paramref name="dstcolors"/> are assumed
        /// not to hold less than <paramref name="count"/> colors.
        /// <para/>
        /// For 16-bit images, all colors specified are transparently converted to their 
        /// proper 16-bit representation (either in RGB555 or RGB565 format, which is determined
        /// by the image's red- green- and blue-mask).
        /// <para/>
        /// <b>Note, that this behaviour is different from what <see cref="ApplyPaletteIndexMapping"/> does,
        /// which modifies the actual image data on palletized images.</b>
        /// </remarks>
        public static uint ApplyColorMapping(FIBITMAP dib, RGBQUAD[] srccolors, RGBQUAD[] dstcolors, uint count, bool ignore_alpha, bool swap)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ApplyColorMappingWindows(dib, srccolors, dstcolors, count, ignore_alpha, swap);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ApplyColorMappingLinux(dib, srccolors, dstcolors, count, ignore_alpha, swap);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ApplyColorMappingMacOS(dib, srccolors, dstcolors, count, ignore_alpha, swap);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Swaps two specified colors on a 1-, 4- or 8-bit palletized
        /// or a 16-, 24- or 32-bit high color image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="color_a">One of the two colors to be swapped.</param>
        /// <param name="color_b">The other of the two colors to be swapped.</param>
        /// <param name="ignore_alpha">If true, 32-bit images and colors are treated as 24-bit.</param>
        /// <returns>The total number of pixels changed.</returns>
        /// <remarks>
        /// This function swaps the two specified colors <paramref name="color_a"/> and
        /// <paramref name="color_b"/> on a palletized or high color image.
        /// For high color images, the actual image data will be modified whereas, for palletized
        /// images only the palette will be changed.
        /// <para/>
        /// <b>Note, that this behaviour is different from what <see cref="SwapPaletteIndices"/> does,
        /// which modifies the actual image data on palletized images.</b>
        /// <para/>
        /// This is just a thin wrapper for <see cref="ApplyColorMapping"/> and resolves to:
        /// <para/>
        /// <code>
        /// return ApplyColorMapping(dib, color_a, color_b, 1, ignore_alpha, true);
        /// </code>
        /// </remarks>
        public static uint SwapColors(FIBITMAP dib, ref RGBQUAD color_a, ref RGBQUAD color_b, bool ignore_alpha)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SwapColorsWindows(dib, ref color_a, ref color_b, ignore_alpha);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SwapColorsLinux(dib, ref color_a, ref color_b, ignore_alpha);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SwapColorsMacOS(dib, ref color_a, ref color_b, ignore_alpha);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Applies palette index mapping for one or several indices
        /// on a 1-, 4- or 8-bit palletized image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="srcindices">Array of palette indices to be used as the mapping source.</param>
        /// <param name="dstindices">Array of palette indices to be used as the mapping destination.</param>
        /// <param name="count">The number of palette indices to be mapped. This is the size of both
        /// srcindices and dstindices</param>
        /// <param name="swap">If true, source and destination palette indices are swapped, that is,
        /// each destination index is also mapped to the corresponding source index.</param>
        /// <returns>The total number of pixels changed.</returns>
        /// <remarks>
        /// This function maps up to <paramref name="count"/> palette indices specified in
        /// <paramref name="srcindices"/> to these specified in <paramref name="dstindices"/>.
        /// Thereby, index <i>srcindices[N]</i>, if present in the image, will be replaced by index
        /// <i>dstindices[N]</i>. If <paramref name="swap"/> is <b>true</b>, additionally all indices
        /// specified in <paramref name="dstindices"/> are also mapped to these specified in 
        /// <paramref name="srcindices"/>.
        /// <para/>
        /// The function returns the number of pixels changed or zero, if no pixels were changed.
        /// Both arrays <paramref name="srcindices"/> and <paramref name="dstindices"/> are assumed not to
        /// hold less than <paramref name="count"/> indices.
        /// <para/>
        /// <b>Note, that this behaviour is different from what <see cref="ApplyColorMapping"/> does, which
        /// modifies the actual image data on palletized images.</b>
        /// </remarks>
        public static uint ApplyPaletteIndexMapping(FIBITMAP dib, byte[] srcindices, byte[] dstindices, uint count, bool swap)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return ApplyPaletteIndexMappingWindows(dib, srcindices, dstindices, count, swap);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return ApplyPaletteIndexMappingLinux(dib, srcindices, dstindices, count, swap);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return ApplyPaletteIndexMappingMacOS(dib, srcindices, dstindices, count, swap);
            else
                throw new NotSupportedException();
        }


        /// <summary>
        /// Swaps two specified palette indices on a 1-, 4- or 8-bit palletized image.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="index_a">One of the two palette indices to be swapped.</param>
        /// <param name="index_b">The other of the two palette indices to be swapped.</param>
        /// <returns>The total number of pixels changed.</returns>
        /// <remarks>
        /// This function swaps the two specified palette indices <i>index_a</i> and
        /// <i>index_b</i> on a palletized image. Therefore, not the palette, but the
        /// actual image data will be modified.
        /// <para/>
        /// <b>Note, that this behaviour is different from what <see cref="SwapColors"/> does on palletized images,
        /// which only swaps the colors in the palette.</b>
        /// <para/>
        /// This is just a thin wrapper for <see cref="ApplyColorMapping"/> and resolves to:
        /// <para/>
        /// <code>
        /// return ApplyPaletteIndexMapping(dib, index_a, index_b, 1, true);
        /// </code>
        /// </remarks>
        public static uint SwapPaletteIndices(FIBITMAP dib, ref byte index_a, ref byte index_b)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return SwapPaletteIndicesWindows(dib, ref index_a, ref index_b);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return SwapPaletteIndicesLinux(dib, ref index_a, ref index_b);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return SwapPaletteIndicesMacOS(dib, ref index_a, ref index_b);
            else
                throw new NotSupportedException();
        }


        public static bool FillBackground(FIBITMAP dib, IntPtr color, FREE_IMAGE_COLOR_OPTIONS options)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return FillBackgroundWindows(dib, color, options);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return FillBackgroundLinux(dib, color, options);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return FillBackgroundMacOS(dib, color, options);
            else
                throw new NotSupportedException();
        }


        #endregion

    }
}
