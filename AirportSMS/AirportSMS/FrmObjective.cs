using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AirportSMS.FrmFlightMovement;

namespace AirportSMS
{
    public partial class FrmObjective : Form
    {
        public FrmObjective()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.CopySelectedtoClipboard(DGV_Objective);
            }
            catch
            {

            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AirportSMS_Class asmscls = new AirportSMS_Class();
                asmscls.PasteClipboardToDatagridview(DGV_Objective);
            }
            catch
            {

            }
        }

        private void TxtNoOfRowsGen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DGV_Objective.Rows.Clear();
                int n;
                if(TxtNoOfRowsGen.Text == "")
                {
                    n = 0;
                }
                else
                {
                    n = Convert.ToInt32(TxtNoOfRowsGen.Text);
                    for(int i=0; i<n;i++)
                    {
                        DGV_Objective.Rows.Add();
                        DGV_Objective.Rows[i].Cells[0].Value = i + 1;
                    }
                }
                   
            }
            catch
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMain fm = (FrmMain)Application.OpenForms["FrmMain"];
            string projectFolder = string.Empty;
            if (fm.TxtProjectLocation.Text == "")
            {
                MessageBox.Show("No project found....Open project first");
            }
            else
            {
                projectFolder = fm.TxtProjectLocation.Text;
                SaveOrCreateFMData(projectFolder);
                MessageBox.Show("Objective data saved successfully");
            }
        }


        private void SaveOrCreateFMData(string projectFolder)
        {
            string folderPath = Path.Combine(projectFolder, "SMSObjective");
            string filePath = Path.Combine(folderPath, "SMSObjective.json");

            bool exists = Directory.Exists(folderPath) && File.Exists(filePath);
            string confirmMessage = exists
                ? "File already exists. Are you sure you want to overwrite it?"
                : "Are you sure you want to save the data?";

            // 1. Ask User for confirmation
            DialogResult result = MessageBox.Show(confirmMessage, "Confirm Save",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; // Do nothing
            }

            try
            {
                // 2. Ensure Folder exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 3. Prepare the data object
                FMDataWrapper dataToSave = new FMDataWrapper
                {
                    //CurrentYear = GetGridData(DGV_FMs_CurrentYear),
                    //PreviousYear = GetGridData(DGV_FMs_PreviousYear)
                };

                // 4. Serialize and Write (File.WriteAllText overwrites by default)
                string jsonString = JsonSerializer.Serialize(dataToSave, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, jsonString);

                //MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
