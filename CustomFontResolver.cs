using PdfSharp.Fonts;
using System.IO;

/* Clase para resolver los problemas de fuente al usar Linux */
public class CustomFontResolver : IFontResolver
{
    private static readonly byte[] DejaVu;

    static CustomFontResolver()
    {
        // Cargar la fuente desde el sistema
        DejaVu = File.ReadAllBytes("/usr/share/fonts/truetype/dejavu/DejaVuSans.ttf");
    }

    public byte[] GetFont(string faceName)
    {
        if (faceName == "DejaVuSans") return DejaVu;
        return null!;
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        if (familyName.Equals("DejaVu Sans", StringComparison.OrdinalIgnoreCase))
        {
            return new FontResolverInfo("DejaVuSans");
        }

        // fallback
        return new FontResolverInfo("DejaVuSans");
    }
}
