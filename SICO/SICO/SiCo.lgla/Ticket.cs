using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace SiCo.lgla
{
    public class Ticket
    {
        #region Declaraciones

        private readonly ArrayList footerLines = new ArrayList();
        private readonly ArrayList headerLines = new ArrayList();
        private readonly ArrayList items = new ArrayList();
        private readonly SolidBrush myBrush = new SolidBrush(Color.Black);
        private readonly ArrayList subHeaderLines = new ArrayList();
        private readonly ArrayList totales = new ArrayList();
        private int count;

        private string fontName = "Lucida Console";
        private int fontSize = 9;

        private Graphics gfx;
        private Image headerImage;
        private int imageHeight;
        private float leftMargin;

        private string line;
        private int maxChar = 35;
        private int maxCharDescription = 20;
        private Font printFont;
        private float topMargin = 3;

        #endregion

        #region Constructor

        #endregion

        #region Propiedades

        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set { if (value != maxCharDescription) maxCharDescription = value; }
        }

        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        #endregion

        #region Metodos

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(string cantidad, string item, string price)
        {
            var newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(cantidad, item, price));
        }

        public void AddTotal(string name, string price)
        {
            var newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "=";
            return dotted;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            var pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = impresora;
            pr.PrintPage += pr_PrintPage;
            pr.Print();
        }

        private void pr_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            DrawImage();
            DrawHeader();
            DrawSubHeader();
            DrawItems();
            DrawTotales();
            DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }

        private float YPosition()
        {
            return topMargin + (count*printFont.GetHeight(gfx) + imageHeight);
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int) leftMargin, (int) YPosition()));
                    double height = ((double) headerImage.Height/58)*15;
                    imageHeight = (int) Math.Round(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush,
                                   leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeader in subHeaderLines)
            {
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(),
                                       new StringFormat());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush,
                                   leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;

                    line = DottedLine();

                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawItems()
        {
            var ordIt = new OrderItem('?');

            gfx.DrawString("CANT  DESCRIPCION           IMPORTE", printFont, myBrush, leftMargin, YPosition(),
                           new StringFormat());

            count++;
            DrawEspacio();

            foreach (string item in items)
            {
                line = ordIt.GetItemCantidad(item);

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                line = ordIt.GetItemPrice(item);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                string name = ordIt.GetItemName(item);

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    while (itemLenght > maxCharDescription)
                    {
                        line = ordIt.GetItemName(item);
                        gfx.DrawString("      " + line.Substring(currentChar, maxCharDescription), printFont, myBrush,
                                       leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxCharDescription;
                        itemLenght -= maxCharDescription;
                    }

                    line = ordIt.GetItemName(item);
                    gfx.DrawString("      " + line.Substring(currentChar, line.Length - currentChar), printFont, myBrush,
                                   leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("      " + ordIt.GetItemName(item), printFont, myBrush, leftMargin, YPosition(),
                                   new StringFormat());

                    count++;
                }
            }

            leftMargin = 0;
            DrawEspacio();
            line = DottedLine();

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();
        }

        private void DrawTotales()
        {
            var ordTot = new OrderTotal('?');

            foreach (string total in totales)
            {
                line = ordTot.GetTotalCantidad(total);
                line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0;

                line = "      " + ordTot.GetTotalName(total);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footer in footerLines)
            {
                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar, maxChar), printFont, myBrush, leftMargin, YPosition(),
                                       new StringFormat());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar, line.Length - currentChar), printFont, myBrush,
                                   leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "";

            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
        }

        #endregion
    }

    public class OrderItem
    {
        private readonly char[] delimitador = new[] {'?'};

        public OrderItem(char delimit)
        {
            delimitador = new[] {delimit};
        }

        public string GetItemCantidad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetItemName(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[2];
        }

        public string GenerateItem(string cantidad, string itemName, string price)
        {
            return cantidad + delimitador[0] + itemName + delimitador[0] + price;
        }
    }

    public class OrderTotal
    {
        private readonly char[] delimitador = new[] {'?'};

        public OrderTotal(char delimit)
        {
            delimitador = new[] {delimit};
        }

        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateTotal(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    }
}