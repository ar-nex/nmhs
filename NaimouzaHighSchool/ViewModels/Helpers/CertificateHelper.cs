using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using MigraModel = MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace NaimouzaHighSchool.ViewModels.Helpers
{
    public class CertificateHelper
    {
        public string GenerateDocumentBaseDirectory()
        {
            string mydocumentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathString = Path.Combine(mydocumentDirectory, "nmhs-nexap");
            Directory.CreateDirectory(pathString);
            return pathString;
        }

        public void CreateCharacterCertificatePDF(string[] CertificateData) 
        {
            if (CertificateData.Length != 13)
            {
                return;
            }
            else
            {
                string currentYear = DateTime.Today.ToString("yyyy");
                string stdName = CertificateData[0];
                string xchild = (CertificateData[7] == "Boy") ? "son" : "daughter";
                string fatherName = CertificateData[1];
                string vill = CertificateData[2];
                string po = CertificateData[3];
                string ps = CertificateData[4];
                string dist = CertificateData[5];
                string pin = CertificateData[6];
                string xhe = (CertificateData[7] == "Boy") ? "he" : "she";
                string Xhe = (CertificateData[7] == "Boy") ? "He" : "She";
                string wis = ((CertificateData[11].IndexOf(currentYear) >= 0)) ? "is" : "was";
                string stdClass = CertificateData[8];
                string stdsec = CertificateData[9];
                string roll = CertificateData[10];
                string stdSession = CertificateData[11];
                string Hir = (CertificateData[7] == "Boy") ? "His" : "Her";
                string hir = (CertificateData[7] == "Boy") ? "his" : "her";
                string dob = CertificateData[12];



                // Generate nmhs-nexap directory in my document folder
                string containerfolder = this.GenerateDocumentBaseDirectory();
                MigraModel.Document doc = new MigraModel.Document();
                MigraModel.Section sec = doc.AddSection();
                sec.PageSetup = doc.DefaultPageSetup.Clone();
                sec.PageSetup.TopMargin = ".7cm";

                MigraDoc.DocumentObjectModel.Shapes.TextFrame tframe = sec.AddTextFrame();
                tframe.AddImage("nmhs-logo.jpg");
                tframe.Left = "-.5cm";
                tframe.Top = "0.7cm";
                tframe.RelativeVertical = MigraModel.Shapes.RelativeVertical.Page;
                tframe.RelativeHorizontal = MigraModel.Shapes.RelativeHorizontal.Margin;

                MigraModel.Paragraph paraSchoolName = sec.AddParagraph();
                paraSchoolName.Format.Font.Name = "Times New Roman";
                paraSchoolName.Format.Alignment = MigraModel.ParagraphAlignment.Center;
                paraSchoolName.Format.Font.Size = 25;
                paraSchoolName.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkBlue;
                string schoolName = "NAIMOUZA HIGH SCHOOL";
                paraSchoolName.AddFormattedText(schoolName, MigraModel.TextFormat.Bold);

                MigraModel.Paragraph paraSchoolAddress = sec.AddParagraph();
                paraSchoolAddress.Format.Font.Size = 14;
                paraSchoolAddress.Format.Alignment = MigraModel.ParagraphAlignment.Center;
                string addrs = "Vill. & P.O. Sujapur, Dist. Malda, 732206";
                paraSchoolAddress.AddText(addrs);

                MigraModel.Paragraph paraSchoolMeta = sec.AddParagraph();
                paraSchoolMeta.Format.Font.Size = 10;
                paraSchoolMeta.Format.Alignment = MigraModel.ParagraphAlignment.Center;
                string meta = "INDEX NO. - R1-110, CONTACT NO. - 03512-246525";
                paraSchoolMeta.AddFormattedText(meta, MigraModel.TextFormat.NotBold);

                MigraModel.Paragraph paraAdmissionMeta = sec.AddParagraph();
                paraAdmissionMeta.Format.Font.Size = 10;
                paraAdmissionMeta.Format.Alignment = MigraModel.ParagraphAlignment.Right;
                string admNo = "12345";
                string admYear = "2016";
                string ameta = "Admission Sl. " + admNo + " of " + admYear;
                paraAdmissionMeta.AddFormattedText(ameta, MigraModel.TextFormat.Bold);

                MigraModel.Paragraph para_a = sec.AddParagraph();
                para_a.Format.Font.Name = "Lucida Handwriting";
                para_a.Format.Font.Size = 16;
                para_a.Format.Font.Color = MigraModel.Colors.DarkBlue;
                para_a.Format.Alignment = MigraModel.ParagraphAlignment.Justify;
                para_a.AddLineBreak();
                para_a.AddLineBreak();
                para_a.AddLineBreak();
                para_a.AddLineBreak();
                para_a.AddLineBreak();
                para_a.AddTab();


                string para_aText = "This is to certify that " + stdName + ", " + xchild + " of " + fatherName + ", Vill. " + vill + ", P.O. " + po + ", P.S. " + ps + ", Dist. " + dist + ", PIN-" + pin + " is personally known to me.";
                para_a.AddText(para_aText);

                MigraModel.Paragraph para_b = sec.AddParagraph();
                para_b.Format.Font.Name = "Lucida Handwriting";
                para_b.Format.Font.Size = 16;
                para_b.Format.Font.Color = MigraModel.Colors.DarkBlue;
                para_b.Format.Alignment = MigraModel.ParagraphAlignment.Justify;
                para_b.AddLineBreak();
                para_b.AddTab();
                string para_aTextb = Xhe + " comes of a respectable family. " + Xhe + " " + wis + " reading in Class " + stdClass + ", Sec. " + stdsec + ", Roll " + roll + ", Session " + stdSession + ".";
                para_b.AddText(para_aTextb);

                MigraModel.Paragraph para_c = sec.AddParagraph();
                para_c.Format.Font.Name = "Lucida Handwriting";
                para_c.Format.Font.Size = 16;
                para_c.Format.Font.Color = MigraModel.Colors.DarkBlue;
                para_c.Format.Alignment = MigraModel.ParagraphAlignment.Justify;
                para_c.AddLineBreak();
                para_c.AddTab();
                string paraTextc = Hir + " date of birth as per School records is " + dob + ".";
                para_c.AddText(paraTextc);

                MigraModel.Paragraph para_d = sec.AddParagraph();
                para_d.Format.Font.Name = "Lucida Handwriting";
                para_d.Format.Font.Size = 16;
                para_d.Format.Font.Color = MigraModel.Colors.DarkBlue;
                para_d.Format.Alignment = MigraModel.ParagraphAlignment.Justify;
                para_d.AddLineBreak();
                para_d.AddTab();
                string paraTextd = "So far I know, " + xhe + " bears a good moral character. I wish " + hir + " every success in life.";
                para_d.AddText(paraTextd);


                MigraDoc.DocumentObjectModel.Shapes.TextFrame tframeHMaster = sec.AddTextFrame();
                MigraModel.Paragraph paraHMaster = tframeHMaster.AddParagraph();
                paraHMaster.Format.Font.Size = "14";
                paraHMaster.Format.Alignment = MigraModel.ParagraphAlignment.Center;
                string txt1 = "Headmaster";
                string txt2 = "Naimuza High School";
                string txt3 = "Sujapur, Malda";
                paraHMaster.AddText(txt1);
                paraHMaster.AddLineBreak();
                paraHMaster.AddText(txt2);
                paraHMaster.AddLineBreak();
                paraHMaster.AddText(txt3);
                tframeHMaster.Width = "6cm";
                tframeHMaster.Left = "10cm";
                tframeHMaster.Top = "19cm";
                tframeHMaster.RelativeVertical = MigraModel.Shapes.RelativeVertical.Page;
                tframeHMaster.RelativeHorizontal = MigraModel.Shapes.RelativeHorizontal.Margin;

                MigraDoc.Rendering.PdfDocumentRenderer docRend = new MigraDoc.Rendering.PdfDocumentRenderer(false);
                docRend.Document = doc;
                try
                {
                    docRend.RenderDocument();
                }
                catch (Exception e)
                {

                    System.Windows.MessageBox.Show(e.Message);
                    return;
                }
                string fname = "CHR_"+stdName + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".pdf";
                string pathString = Path.Combine(containerfolder, fname);
                docRend.PdfDocument.Save(pathString);

                System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
                processInfo.FileName = pathString;
                System.Diagnostics.Process.Start(processInfo);
            }
        }
    }
}
