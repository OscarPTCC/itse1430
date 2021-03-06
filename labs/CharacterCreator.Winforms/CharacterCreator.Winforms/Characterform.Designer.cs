﻿namespace CharacterCreator.Winforms
{
    partial class Characterform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._comboBoxRace = new System.Windows.Forms.ComboBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtHP = new System.Windows.Forms.TextBox();
            this._txtStrength = new System.Windows.Forms.TextBox();
            this._txtMagic = new System.Windows.Forms.TextBox();
            this._txtSkill = new System.Windows.Forms.TextBox();
            this._txtLuck = new System.Windows.Forms.TextBox();
            this._txtSpeed = new System.Windows.Forms.TextBox();
            this._txtDefense = new System.Windows.Forms.TextBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this._comboProfession = new System.Windows.Forms.ComboBox();
            this._error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._error)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(82, 31);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(100, 23);
            this._txtName.TabIndex = 0;
            this._txtName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Profession";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Attributes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Strength";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(461, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Magic";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Skill";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(461, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Speed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Luck";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(461, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Defense";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(274, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "HP";
            // 
            // _comboBoxRace
            // 
            this._comboBoxRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxRace.FormattingEnabled = true;
            this._comboBoxRace.Items.AddRange(new object[] {
            "",
            "Beorc",
            "Laguz",
            "Manakete",
            "Taguel"});
            this._comboBoxRace.Location = new System.Drawing.Point(82, 113);
            this._comboBoxRace.Name = "_comboBoxRace";
            this._comboBoxRace.Size = new System.Drawing.Size(121, 23);
            this._comboBoxRace.TabIndex = 3;
            this._comboBoxRace.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateRace);
            // 
            // _txtDescription
            // 
            this._txtDescription.Location = new System.Drawing.Point(82, 157);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(169, 124);
            this._txtDescription.TabIndex = 6;
            // 
            // _txtHP
            // 
            this._txtHP.Location = new System.Drawing.Point(340, 73);
            this._txtHP.Name = "_txtHP";
            this._txtHP.Size = new System.Drawing.Size(100, 23);
            this._txtHP.TabIndex = 2;
            this._txtHP.Text = "20";
            this._txtHP.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateHP);
            // 
            // _txtStrength
            // 
            this._txtStrength.Location = new System.Drawing.Point(340, 113);
            this._txtStrength.Name = "_txtStrength";
            this._txtStrength.Size = new System.Drawing.Size(100, 23);
            this._txtStrength.TabIndex = 4;
            this._txtStrength.Text = "6";
            this._txtStrength.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateStrength);
            // 
            // _txtMagic
            // 
            this._txtMagic.Location = new System.Drawing.Point(522, 113);
            this._txtMagic.Name = "_txtMagic";
            this._txtMagic.Size = new System.Drawing.Size(100, 23);
            this._txtMagic.TabIndex = 5;
            this._txtMagic.Text = "6";
            this._txtMagic.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateMagic);
            // 
            // _txtSkill
            // 
            this._txtSkill.Location = new System.Drawing.Point(340, 157);
            this._txtSkill.Name = "_txtSkill";
            this._txtSkill.Size = new System.Drawing.Size(100, 23);
            this._txtSkill.TabIndex = 7;
            this._txtSkill.Text = "6";
            this._txtSkill.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateSkill);
            // 
            // _txtLuck
            // 
            this._txtLuck.Location = new System.Drawing.Point(340, 197);
            this._txtLuck.Name = "_txtLuck";
            this._txtLuck.Size = new System.Drawing.Size(100, 23);
            this._txtLuck.TabIndex = 9;
            this._txtLuck.Text = "6";
            this._txtLuck.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateLuck);
            // 
            // _txtSpeed
            // 
            this._txtSpeed.Location = new System.Drawing.Point(522, 157);
            this._txtSpeed.Name = "_txtSpeed";
            this._txtSpeed.Size = new System.Drawing.Size(100, 23);
            this._txtSpeed.TabIndex = 8;
            this._txtSpeed.Text = "6";
            this._txtSpeed.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateSpeed);
            // 
            // _txtDefense
            // 
            this._txtDefense.Location = new System.Drawing.Point(522, 197);
            this._txtDefense.Name = "_txtDefense";
            this._txtDefense.Size = new System.Drawing.Size(100, 23);
            this._txtDefense.TabIndex = 10;
            this._txtDefense.Text = "6";
            this._txtDefense.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateDefense);
            // 
            // _btnSave
            // 
            this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnSave.Location = new System.Drawing.Point(461, 258);
            this._btnSave.MaximumSize = new System.Drawing.Size(75, 23);
            this._btnSave.MinimumSize = new System.Drawing.Size(75, 23);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 11;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(547, 258);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 12;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(461, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 30);
            this.label13.TabIndex = 25;
            this.label13.Text = "HP caps out at 52.\r\nAll other stats cap at 40.";
            // 
            // _comboProfession
            // 
            this._comboProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboProfession.FormattingEnabled = true;
            this._comboProfession.Items.AddRange(new object[] {
            "",
            "Hero",
            "Archer",
            "Thief",
            "Priest",
            "Mage",
            "Armored Knight"});
            this._comboProfession.Location = new System.Drawing.Point(82, 73);
            this._comboProfession.Name = "_comboProfession";
            this._comboProfession.Size = new System.Drawing.Size(121, 23);
            this._comboProfession.TabIndex = 1;
            this._comboProfession.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateProfession);
            // 
            // _error
            // 
            this._error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._error.ContainerControl = this;
            // 
            // Characterform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(640, 299);
            this.Controls.Add(this._comboProfession);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtDefense);
            this.Controls.Add(this._txtSpeed);
            this.Controls.Add(this._txtLuck);
            this.Controls.Add(this._txtSkill);
            this.Controls.Add(this._txtMagic);
            this.Controls.Add(this._txtStrength);
            this.Controls.Add(this._txtHP);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._comboBoxRace);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(656, 338);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(656, 338);
            this.Name = "Characterform";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            ((System.ComponentModel.ISupportInitialize)(this._error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox _comboBoxRace;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.TextBox _txtHP;
        private System.Windows.Forms.TextBox _txtStrength;
        private System.Windows.Forms.TextBox _txtMagic;
        private System.Windows.Forms.TextBox _txtSkill;
        private System.Windows.Forms.TextBox _txtLuck;
        private System.Windows.Forms.TextBox _txtSpeed;
        private System.Windows.Forms.TextBox _txtDefense;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox _comboProfession;
        private System.Windows.Forms.ErrorProvider _error;
    }
}