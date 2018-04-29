using System.Drawing;

namespace NetworkSecurity
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbEncrypted = new System.Windows.Forms.GroupBox();
            this.lblEncryptDuration = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblBrowseEncryptedBinaryFile = new System.Windows.Forms.Label();
            this.btnBrowseEncryptedBinaryFile = new System.Windows.Forms.Button();
            this.lblEncryptedText = new System.Windows.Forms.Label();
            this.txtEncryptedText = new System.Windows.Forms.TextBox();
            this.gbDecrypted = new System.Windows.Forms.GroupBox();
            this.lblDecryptDuration = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblBrowseDecryptedBinaryFile = new System.Windows.Forms.Label();
            this.btnBrowseDecryptedBinaryFile = new System.Windows.Forms.Button();
            this.lblDecryptedText = new System.Windows.Forms.Label();
            this.txtDecryptedText = new System.Windows.Forms.TextBox();
            this.rbtnSelectTextType = new System.Windows.Forms.RadioButton();
            this.rbtnSelectBinaryType = new System.Windows.Forms.RadioButton();
            this.cmbCryptoTypes = new System.Windows.Forms.ComboBox();
            this.gbCrypto = new System.Windows.Forms.GroupBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbEncrypted.SuspendLayout();
            this.gbDecrypted.SuspendLayout();
            this.gbCrypto.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 73);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.splitContainer.Panel1.Controls.Add(this.gbEncrypted);
            this.splitContainer.Panel1MinSize = 50;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitContainer.Panel2.Controls.Add(this.gbDecrypted);
            this.splitContainer.Panel2MinSize = 50;
            this.splitContainer.Size = new System.Drawing.Size(1014, 532);
            this.splitContainer.SplitterDistance = 502;
            this.splitContainer.TabIndex = 1;
            // 
            // gbEncrypted
            // 
            this.gbEncrypted.BackColor = System.Drawing.Color.Thistle;
            this.gbEncrypted.Controls.Add(this.lblEncryptDuration);
            this.gbEncrypted.Controls.Add(this.btnDecrypt);
            this.gbEncrypted.Controls.Add(this.lblBrowseEncryptedBinaryFile);
            this.gbEncrypted.Controls.Add(this.btnBrowseEncryptedBinaryFile);
            this.gbEncrypted.Controls.Add(this.lblEncryptedText);
            this.gbEncrypted.Controls.Add(this.txtEncryptedText);
            this.gbEncrypted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEncrypted.Location = new System.Drawing.Point(0, 0);
            this.gbEncrypted.Name = "gbEncrypted";
            this.gbEncrypted.Size = new System.Drawing.Size(502, 532);
            this.gbEncrypted.TabIndex = 0;
            this.gbEncrypted.TabStop = false;
            this.gbEncrypted.Text = "Encrypted";
            // 
            // lblEncryptDuration
            // 
            this.lblEncryptDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEncryptDuration.AutoSize = true;
            this.lblEncryptDuration.Location = new System.Drawing.Point(31, 412);
            this.lblEncryptDuration.Name = "lblEncryptDuration";
            this.lblEncryptDuration.Size = new System.Drawing.Size(114, 17);
            this.lblEncryptDuration.TabIndex = 6;
            this.lblEncryptDuration.Text = "Encrypt Duration";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrypt.Location = new System.Drawing.Point(318, 484);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(148, 36);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Decrypt =>";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // lblBrowseEncryptedBinaryFile
            // 
            this.lblBrowseEncryptedBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrowseEncryptedBinaryFile.AutoSize = true;
            this.lblBrowseEncryptedBinaryFile.Location = new System.Drawing.Point(31, 350);
            this.lblBrowseEncryptedBinaryFile.Name = "lblBrowseEncryptedBinaryFile";
            this.lblBrowseEncryptedBinaryFile.Size = new System.Drawing.Size(107, 17);
            this.lblBrowseEncryptedBinaryFile.TabIndex = 4;
            this.lblBrowseEncryptedBinaryFile.Text = "Binary File Path";
            // 
            // btnBrowseEncryptedBinaryFile
            // 
            this.btnBrowseEncryptedBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseEncryptedBinaryFile.Location = new System.Drawing.Point(34, 294);
            this.btnBrowseEncryptedBinaryFile.Name = "btnBrowseEncryptedBinaryFile";
            this.btnBrowseEncryptedBinaryFile.Size = new System.Drawing.Size(432, 43);
            this.btnBrowseEncryptedBinaryFile.TabIndex = 3;
            this.btnBrowseEncryptedBinaryFile.Text = "Browse Binary File";
            this.btnBrowseEncryptedBinaryFile.UseVisualStyleBackColor = true;
            // 
            // lblEncryptedText
            // 
            this.lblEncryptedText.AutoSize = true;
            this.lblEncryptedText.Location = new System.Drawing.Point(31, 45);
            this.lblEncryptedText.Name = "lblEncryptedText";
            this.lblEncryptedText.Size = new System.Drawing.Size(107, 17);
            this.lblEncryptedText.TabIndex = 2;
            this.lblEncryptedText.Text = "Encrypted Text:";
            // 
            // txtEncryptedText
            // 
            this.txtEncryptedText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncryptedText.Location = new System.Drawing.Point(34, 65);
            this.txtEncryptedText.Multiline = true;
            this.txtEncryptedText.Name = "txtEncryptedText";
            this.txtEncryptedText.Size = new System.Drawing.Size(432, 223);
            this.txtEncryptedText.TabIndex = 0;
            // 
            // gbDecrypted
            // 
            this.gbDecrypted.BackColor = System.Drawing.Color.PowderBlue;
            this.gbDecrypted.Controls.Add(this.lblDecryptDuration);
            this.gbDecrypted.Controls.Add(this.btnEncrypt);
            this.gbDecrypted.Controls.Add(this.lblBrowseDecryptedBinaryFile);
            this.gbDecrypted.Controls.Add(this.btnBrowseDecryptedBinaryFile);
            this.gbDecrypted.Controls.Add(this.lblDecryptedText);
            this.gbDecrypted.Controls.Add(this.txtDecryptedText);
            this.gbDecrypted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDecrypted.Location = new System.Drawing.Point(0, 0);
            this.gbDecrypted.Name = "gbDecrypted";
            this.gbDecrypted.Size = new System.Drawing.Size(508, 532);
            this.gbDecrypted.TabIndex = 1;
            this.gbDecrypted.TabStop = false;
            this.gbDecrypted.Text = "Decrypted";
            // 
            // lblDecryptDuration
            // 
            this.lblDecryptDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDecryptDuration.AutoSize = true;
            this.lblDecryptDuration.Location = new System.Drawing.Point(33, 412);
            this.lblDecryptDuration.Name = "lblDecryptDuration";
            this.lblDecryptDuration.Size = new System.Drawing.Size(115, 17);
            this.lblDecryptDuration.TabIndex = 13;
            this.lblDecryptDuration.Text = "Decrypt Duration";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEncrypt.Location = new System.Drawing.Point(36, 484);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(148, 36);
            this.btnEncrypt.TabIndex = 12;
            this.btnEncrypt.Text = "<= Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // lblBrowseDecryptedBinaryFile
            // 
            this.lblBrowseDecryptedBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBrowseDecryptedBinaryFile.AutoSize = true;
            this.lblBrowseDecryptedBinaryFile.Location = new System.Drawing.Point(33, 350);
            this.lblBrowseDecryptedBinaryFile.Name = "lblBrowseDecryptedBinaryFile";
            this.lblBrowseDecryptedBinaryFile.Size = new System.Drawing.Size(107, 17);
            this.lblBrowseDecryptedBinaryFile.TabIndex = 11;
            this.lblBrowseDecryptedBinaryFile.Text = "Binary File Path";
            // 
            // btnBrowseDecryptedBinaryFile
            // 
            this.btnBrowseDecryptedBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDecryptedBinaryFile.Location = new System.Drawing.Point(36, 294);
            this.btnBrowseDecryptedBinaryFile.Name = "btnBrowseDecryptedBinaryFile";
            this.btnBrowseDecryptedBinaryFile.Size = new System.Drawing.Size(434, 43);
            this.btnBrowseDecryptedBinaryFile.TabIndex = 10;
            this.btnBrowseDecryptedBinaryFile.Text = "Browse Binary File";
            this.btnBrowseDecryptedBinaryFile.UseVisualStyleBackColor = true;
            // 
            // lblDecryptedText
            // 
            this.lblDecryptedText.AutoSize = true;
            this.lblDecryptedText.Location = new System.Drawing.Point(33, 45);
            this.lblDecryptedText.Name = "lblDecryptedText";
            this.lblDecryptedText.Size = new System.Drawing.Size(108, 17);
            this.lblDecryptedText.TabIndex = 9;
            this.lblDecryptedText.Text = "Decrypted Text:";
            // 
            // txtDecryptedText
            // 
            this.txtDecryptedText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecryptedText.Location = new System.Drawing.Point(36, 65);
            this.txtDecryptedText.Multiline = true;
            this.txtDecryptedText.Name = "txtDecryptedText";
            this.txtDecryptedText.Size = new System.Drawing.Size(434, 223);
            this.txtDecryptedText.TabIndex = 8;
            // 
            // rbtnSelectTextType
            // 
            this.rbtnSelectTextType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSelectTextType.AutoSize = true;
            this.rbtnSelectTextType.Checked = true;
            this.rbtnSelectTextType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSelectTextType.Location = new System.Drawing.Point(826, 27);
            this.rbtnSelectTextType.Name = "rbtnSelectTextType";
            this.rbtnSelectTextType.Size = new System.Drawing.Size(56, 21);
            this.rbtnSelectTextType.TabIndex = 6;
            this.rbtnSelectTextType.TabStop = true;
            this.rbtnSelectTextType.Text = "Text";
            this.rbtnSelectTextType.UseVisualStyleBackColor = true;
            // 
            // rbtnSelectBinaryType
            // 
            this.rbtnSelectBinaryType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSelectBinaryType.AutoSize = true;
            this.rbtnSelectBinaryType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSelectBinaryType.Location = new System.Drawing.Point(905, 27);
            this.rbtnSelectBinaryType.Name = "rbtnSelectBinaryType";
            this.rbtnSelectBinaryType.Size = new System.Drawing.Size(69, 21);
            this.rbtnSelectBinaryType.TabIndex = 7;
            this.rbtnSelectBinaryType.Text = "Binary";
            this.rbtnSelectBinaryType.UseVisualStyleBackColor = true;
            // 
            // cmbCryptoTypes
            // 
            this.cmbCryptoTypes.FormattingEnabled = true;
            this.cmbCryptoTypes.Location = new System.Drawing.Point(22, 26);
            this.cmbCryptoTypes.Name = "cmbCryptoTypes";
            this.cmbCryptoTypes.Size = new System.Drawing.Size(234, 24);
            this.cmbCryptoTypes.TabIndex = 8;
            // 
            // gbCrypto
            // 
            this.gbCrypto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCrypto.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gbCrypto.Controls.Add(this.lblKey);
            this.gbCrypto.Controls.Add(this.txtKey);
            this.gbCrypto.Controls.Add(this.rbtnSelectBinaryType);
            this.gbCrypto.Controls.Add(this.rbtnSelectTextType);
            this.gbCrypto.Controls.Add(this.cmbCryptoTypes);
            this.gbCrypto.Location = new System.Drawing.Point(2, 1);
            this.gbCrypto.Name = "gbCrypto";
            this.gbCrypto.Size = new System.Drawing.Size(1010, 70);
            this.gbCrypto.TabIndex = 2;
            this.gbCrypto.TabStop = false;
            this.gbCrypto.Text = "Cryptography Type Selector";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(387, 28);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(36, 17);
            this.lblKey.TabIndex = 10;
            this.lblKey.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(429, 26);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(180, 22);
            this.txtKey.TabIndex = 9;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKey.UseSystemPasswordChar = true;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(0, 607);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(1014, 15);
            this.progress.Step = 1;
            this.progress.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1014, 623);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.gbCrypto);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Cryptography Example";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbEncrypted.ResumeLayout(false);
            this.gbEncrypted.PerformLayout();
            this.gbDecrypted.ResumeLayout(false);
            this.gbDecrypted.PerformLayout();
            this.gbCrypto.ResumeLayout(false);
            this.gbCrypto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbEncrypted;
        private System.Windows.Forms.GroupBox gbDecrypted;
        private System.Windows.Forms.Label lblEncryptedText;
        private System.Windows.Forms.TextBox txtEncryptedText;
        private System.Windows.Forms.Label lblBrowseEncryptedBinaryFile;
        private System.Windows.Forms.Button btnBrowseEncryptedBinaryFile;
        private System.Windows.Forms.RadioButton rbtnSelectBinaryType;
        private System.Windows.Forms.RadioButton rbtnSelectTextType;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblBrowseDecryptedBinaryFile;
        private System.Windows.Forms.Button btnBrowseDecryptedBinaryFile;
        private System.Windows.Forms.Label lblDecryptedText;
        private System.Windows.Forms.TextBox txtDecryptedText;
        private System.Windows.Forms.ComboBox cmbCryptoTypes;
        private System.Windows.Forms.GroupBox gbCrypto;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblEncryptDuration;
        private System.Windows.Forms.Label lblDecryptDuration;
    }
}

