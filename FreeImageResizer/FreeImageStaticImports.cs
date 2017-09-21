using FreeImageAPI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FreeImageAPI
{
    public static partial class FreeImage
    {
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
        /// Note that this function only works on MS Windows operating systems. On other systems, the function does nothing and returns FALSE.
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

        /// <summary>
        /// Performs resampling (or scaling, zooming) of a greyscale or RGB(A) image
        /// to the desired destination width and height.
        /// </summary>
        /// <param name="dib">Handle to a FreeImage bitmap.</param>
        /// <param name="dst_width">Destination width.</param>
        /// <param name="dst_height">Destination height.</param>
        /// <param name="filter">The filter to apply.</param>
        /// <returns>Handle to a FreeImage bitmap.</returns>
        public static FIBITMAP Rescale(FIBITMAP dib, uint dst_width, uint dst_height, FREE_IMAGE_FILTER filter)
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


        
    }
}
