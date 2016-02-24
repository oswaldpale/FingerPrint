using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFA3_Example.xml;

namespace PDFA3_Example {
    public class App {
        public static void Main(string[] args) {

            // Load invoice.xml here
		    InvoiceType invoice = Deserialize<InvoiceType>("../../resources/invoice.xml");

            // Start building our document
            Document document = new Document();

            // Create PdfAWriter with PdfAConformanceLevel.PDF_A_3B option if you
            // want to get a PDF/A-3b compliant document.
            PdfAWriter writer = PdfAWriter.GetInstance(document,
                    new FileStream("pdfa3-example.pdf", FileMode.Create),
                    PdfAConformanceLevel.PDF_A_3B);
            // Create XMP metadata. It's a PDF/A requirement.
            writer.CreateXmpMetadata();

            document.Open();

            // Set output intent. PDF/A requirement.
            ICC_Profile icc = ICC_Profile
                    .GetInstance(new FileStream(
                            "../../resources/sRGB Color Space Profile.icm", FileMode.Open));
            writer.SetOutputIntents("Custom", "", "http://www.color.org",
                    "sRGB IEC61966-2.1", icc);

            // All fonts shall be embedded. PDF/A requirement.
            Font bold10 = FontFactory.GetFont(
                    "../../resources/FreeSansBold.ttf",
                    BaseFont.WINANSI, BaseFont.EMBEDDED, 10);
            Font normal9 = FontFactory.GetFont(
                    "../../resources/FreeSans.ttf",
                    BaseFont.WINANSI, BaseFont.EMBEDDED, 9);
            Font bold9 = FontFactory.GetFont(
                    "../../resources/FreeSansBold.ttf",
                    BaseFont.WINANSI, BaseFont.EMBEDDED, 9);
            Font normal8 = FontFactory.GetFont(
                    "../../resources/FreeSans.ttf",
                    BaseFont.WINANSI, BaseFont.EMBEDDED, 8);


            // Creating PDF/A-3 compliant attachment.
            PdfDictionary parameters = new PdfDictionary();
            parameters.Put(PdfName.MODDATE, new PdfDate());
            PdfFileSpecification fileSpec = PdfFileSpecification.FileEmbedded(
                    writer, "../../resources/invoice.xml",
                    "invoice.xml", null, "application/xml", parameters, 0);
            fileSpec.Put(new PdfName("AFRelationship"), new PdfName("Data"));
            writer.AddFileAttachment("invoice.xml", fileSpec);
            PdfArray array = new PdfArray();
            array.Add(fileSpec.Reference);
            writer.ExtraCatalog.Put(new PdfName("AF"), array);

            // From here on we can add content to the PDF just like we would do for
            // a regular PDF.

            // Building header.
            document.Add(new Paragraph("Invoice number: " + invoice.Number, bold10));
            document.Add(new Paragraph("\n", normal8));
            document.Add(new Paragraph("Dear " + invoice.Name + ",", normal9));
            document.Add(new Paragraph(
                "Thank you for your order with amiando. The order for \"Technical Conference Europe 2013\" from June 18, 2013 until June 19, 2013 is calculated as follows:",
                normal9));
            document.Add(new Paragraph("\n", normal8));

            // Building "Ticket category" table.
            if (invoice.Tickets != null) {
                PdfPTable table = new PdfPTable(new float[] {40, 15, 15, 15, 15});
                table.AddCell(new Paragraph("Ticket category", bold9));
                table.AddCell(new Paragraph("Amount", bold9));
                table.AddCell(new Paragraph("Price (net)", bold9));
                table.AddCell(new Paragraph("VAT", bold9));
                table.AddCell(new Paragraph("Price (gross)", bold9));
                if (invoice.Tickets.Ticket != null) {
                    IList<TicketType> tickets = invoice.Tickets.Ticket;
                    foreach (TicketType ticket in tickets) {
                        table.AddCell(new Paragraph(ticket.Category, normal9));
                        table.AddCell(new Paragraph(ticket.Amount, normal9));
                        table.AddCell(new Paragraph(ticket.PriceNet, normal9));
                        table.AddCell(new Paragraph(ticket.Vat, normal9));
                        table.AddCell(new Paragraph(ticket.PriceGross, normal9));
                    }
                }
                table.AddCell(new Paragraph("Subtotal tickets", bold9));
                table.AddCell(new Paragraph(" ", bold9));
                table.AddCell(new Paragraph(" ", bold9));
                table.AddCell(new Paragraph(" ", bold9));
                table.AddCell(new Paragraph(invoice.Tickets.Subtotal,
                    bold9));
                document.Add(table);
                document.Add(new Paragraph("\n", normal8));
            }

            // Building "Total" table
            if (invoice.Total != null) {
                PdfPTable table = new PdfPTable(new float[] {70, 15, 15});
                table.AddCell(new Paragraph("Total", bold9));
                table.AddCell(new Paragraph("VAT", bold9));
                table.AddCell(new Paragraph("Price (gross)", bold9));
                if (invoice.Total.Subtotal != null) {
                    table.AddCell(new Paragraph("Subtotal tickets", normal9));
                    table.AddCell(new Paragraph(" ", normal9));
                    table.AddCell(new Paragraph(invoice.Total.Subtotal.PriceGross, normal9));
                    if (invoice.Total.Subtotal.InvoiceAmountNet != null) {
                        table.AddCell(new Paragraph("     Invoice amount (net)",
                            normal8));
                        table.AddCell(new Paragraph(invoice.Total.Subtotal.InvoiceAmountNet.Vat,
                            normal8));
                        table.AddCell(new Paragraph(invoice.Total
                            .Subtotal.InvoiceAmountNet
                            .PriceGross, normal8));
                    }
                    if (invoice.Total.Subtotal.IncludedVat != null) {
                        table.AddCell(new Paragraph("     Included VAT", normal8));
                        table.AddCell(new Paragraph(invoice.Total
                            .Subtotal.IncludedVat.Vat, normal8));
                        table.AddCell(new Paragraph(invoice.Total
                            .Subtotal.IncludedVat.PriceGross,
                            normal8));
                    }
                    table.AddCell(new Paragraph("Invoice amount", bold10));
                    table.AddCell(new Paragraph(" ", bold10));
                    table.AddCell(new Paragraph(invoice.Total
                        .InvoiceAmount, bold10));
                }
                document.Add(table);
            }

            document.Close();
        }


        public static T Deserialize<T>(string xmlPath) {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(xmlPath, FileMode.Open);
            T result = (T)serializer.Deserialize(fs);
            fs.Close();
            return result;
        }

    }
}
