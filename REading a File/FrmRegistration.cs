﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REading_a_File
{

    public partial class FrmRegistration : Form
    {
        
        public FrmRegistration()
        {
            InitializeComponent();

            panel1.BackColor = Color.FromArgb(100, Color.WhiteSmoke);

            cbProgram.Items.AddRange(new string[]
{
    "BS Computer Science",
    "BS Information Technology",
    "BS Information Systems",
    "BS Software Engineering",
    "BS Data Science",
    "BS Civil Engineering",
    "BS Electrical Engineering",
    "BS Mechanical Engineering",
    "BS Architecture",
    "BS Accountancy",
    "BS Business Administration",
    "BS Marketing Management",
    "BS Psychology",
    "BS Nursing",
    "BS Medical Technology",
    "BS Pharmacy",
    "BS Biology",
    "BS Mathematics",
    "BA Communication",
    "BA Political Science",
    "BA Economics",
    "BA English Language Studies",
    "Bachelor of Elementary Education",
    "Bachelor of Secondary Education"
});

            if (cbProgram.Items.Count > 0)
                cbProgram.SelectedIndex = 0;

            cbGender.Items.AddRange(new string[]
             {
    "Male",
    "Famale"
             });

            if (cbGender.Items.Count > 0)
                cbGender.SelectedIndex = 0;
        }
        

        private void ClearFields()
        {
            txtStudentNo.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMI.Clear();
            txtAge.Clear();
            txtContactNo.Clear();

            cbProgram.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;

            dtpBirthday.Value = DateTime.Now;

            // Optional: put cursor back to Student No
            txtStudentNo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text;
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string middleInitial = txtMI.Text;
            string program = cbProgram.Text;
            string gender = cbGender.Text;
            string age = txtAge.Text;
            string birthday = dtpBirthday.Text;
            string contactNo = txtContactNo.Text;

            // Optional: validate
            if (string.IsNullOrWhiteSpace(studentNo) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Make array of registration info
            string[] registrationInfo =
            {
        "STUDENT REGISTRATION DETAILS",
        "-----------------------------",
        $"Student No.: {studentNo}",
        $"Name: {lastName}, {firstName} {middleInitial}",
        $"Program: {program}",
        $"Gender: {gender}",
        $"Age: {age}",
        $"Birthday: {birthday}",
        $"Contact No.: {contactNo}",
        "-----------------------------",
        "" // blank line
    };

            try
            {

                string projectRoot = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string folderPath = Path.Combine(projectRoot, "Files");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, FileName.SetFileName);


                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (string line in registrationInfo)
                    {
                        writer.WriteLine(line);
                    }
                }

                MessageBox.Show("Registration saved successfully to:\n" + filePath,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving registration: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ClearFields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            frmStudentRecord.Show();
            this.Hide();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {

        }
    }
    }

