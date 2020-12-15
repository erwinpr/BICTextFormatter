using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace BICTextFormatter
{
    public partial class frmMain : Form
    {
        public string outputPath = "";
        public frmMain()
        {
            InitializeComponent();
            btnProcess.Enabled = false;
            lnkOutput.Visible = false;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); //Show The File Dialog Box
            String filePath = openFileDialog1.FileName;
            
            txtPath.Text = filePath;
            if (txtPath.Text != "") {
                btnProcess.Enabled = true;
            }    
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            List<bicSource> bicSources = new List<bicSource>();
            List<string> lines = File.ReadAllLines(txtPath.Text).ToList();
            List<string> newLines = new List<string>();

            string separator = "\t";
            string newLine = "";
            

            //Data Structure
            string fiu = ""; //FIU(3)
            string bicNo = ""; //BIC#(11)
            //string bicINo = ""; //BICI#(1)
            string bicName = ""; //BIC_NAME(105)
            string bicDept = ""; //BIC_DEPT(70)
            string bicCity = ""; //BIC_CITY(30)
            string bicType = ""; //BIC_TYPE(4)
            string bicAdd1 = ""; //BIC_ADD1(35)
            string bicAdd2 = ""; //BIC_ADD2(35)
            string bicAdd3 = ""; //BIC_ADD3(35)
            string bicAdd4 = ""; //BIC_ADD4(35)

            int counter = 0;

            foreach (string line in lines)
            {
                counter++;
                if (counter > 1)
                {
                    string[] entries = line.Split(separator.ToCharArray());

                    bicSource newBicSource = new bicSource();

                    newBicSource.tag = entries[0];
                    newBicSource.modificationFlag = entries[1];
                    newBicSource.bicCode = entries[2];
                    newBicSource.branchCode = entries[3];
                    newBicSource.institutionName = entries[4];
                    newBicSource.branchInformation = entries[5];
                    newBicSource.cityHeading = entries[6];
                    newBicSource.subtypeIndication = entries[7];
                    newBicSource.valueAddedServices = entries[8];
                    newBicSource.extraInfo = entries[9];
                    newBicSource.physicalAddr1 = entries[10];
                    newBicSource.physicalAddr2 = entries[11];
                    newBicSource.physicalAddr3 = entries[12];
                    newBicSource.physicalAddr4 = entries[13];
                    newBicSource.location = entries[14];
                    newBicSource.countryName = entries[15];
                    newBicSource.pobNumber = entries[16];
                    newBicSource.pobLocation = entries[17];
                    newBicSource.pobCountryName = entries[18];

                    bicSources.Add(newBicSource);

                    //assign value(s) 
                    fiu = newBicSource.tag + newBicSource.modificationFlag; //FIU(3)
                    bicNo = newBicSource.bicCode + newBicSource.branchCode; //BIC#(14)
                    //bicINo = "0"; //BICI#(1)
                    bicName = newBicSource.institutionName.PadRight(105); //BIC_NAME(105)
                    bicDept = newBicSource.bicCode.PadRight(70); //BIC_DEPT(70)
                    bicCity = newBicSource.cityHeading.PadRight(30); //BIC_CITY(30)
                    bicType = newBicSource.subtypeIndication.PadRight(4); //BIC_TYPE(4)
                    bicAdd1 = newBicSource.physicalAddr1.PadRight(35); //BIC_ADD1(35)
                    bicAdd2 = newBicSource.physicalAddr2.PadRight(35); //BIC_ADD2(35)
                    bicAdd3 = newBicSource.physicalAddr3.PadRight(35); //BIC_ADD3(35)
                    bicAdd4 = newBicSource.physicalAddr4.PadRight(35); //BIC_ADD4(35)

                    newLine = fiu + bicNo + bicName + bicDept
                    + bicCity + bicType + bicAdd1
                    + bicAdd2 + bicAdd3 + bicAdd4;

                    //add to collection for writing
                    newLines.Add(newLine);

                    lblProcess.Text = "Processing...";
                }
            }

            String currentDir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            outputPath = currentDir + "//Output//FI.DAT";
            File.WriteAllLines(outputPath, newLines);

            lblProcess.Text = "Conversion Done, check Output Folder!";
            lnkOutput.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void lnkOutput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @".\Output\");
        }
    }
}
