using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

class ExportPasswords
{
    public static void ToPdf(List<ClassPasswordItem.PasswordItem> passwords)
    {
        // Resolver de fuente (igual que antes, para Linux)
        GlobalFontSettings.FontResolver = new CustomFontResolver();

        var document = new PdfDocument();
        document.Info.Title = "Lista de contraseñas";

        var page = document.AddPage();
        var gfx = XGraphics.FromPdfPage(page);

        var fontTitle = new XFont("DejaVu Sans", 18, XFontStyleEx.Bold);
        var fontText = new XFont("DejaVu Sans", 12, XFontStyleEx.Regular);

        // Título
        gfx.DrawString("Listado de Contraseñas", fontTitle, XBrushes.Black,
            new XRect(0, 20, page.Width.Point, 40), XStringFormats.TopCenter);

        // Coordenadas iniciales
        double y = 60;

        foreach (var pass in passwords)
        {
            string line = $"ID: {pass.Id} | Nombre: {pass.Name} | Contraseña: {pass.Pass}";
            gfx.DrawString(line, fontText, XBrushes.Black,
                new XRect(40, y, page.Width.Point - 80, 20), XStringFormats.TopLeft);

            y += 20;

            // Si llegás al final de la página, agregá otra
            if (y > page.Height - 40)
            {
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                y = 40;
            }
        }

        document.Save("Passwords.pdf");
        Console.WriteLine("PDF generado: Passwords.pdf");
    }
}