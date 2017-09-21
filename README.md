# FreeImageResizer

Cross-platform (Windows, Linux, MacOS) very minimal FreeImage .Net Core wrapper for resizing images

## Example

Resize PNG image to 200x200

```csharp
FIBITMAP dib = FreeImage.Load(FREE_IMAGE_FORMAT.FIF_PNG, filePatch, FREE_IMAGE_LOAD_FLAGS.DEFAULT);
FIBITMAP dibResized = FreeImage.Rescale(dib, 200, 200, FREE_IMAGE_FILTER.FILTER_LANCZOS3);
FreeImage.Unload(dib);
FreeImage.Save(FREE_IMAGE_FORMAT.FIF_PNG, dibResized, filePatch, FREE_IMAGE_SAVE_FLAGS.DEFAULT);
FreeImage.Unload(dibResized);
```

## Nuget

https://www.nuget.org/packages/FreeImageResizer/