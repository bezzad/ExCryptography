using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using NetworkSecurity.Helper;

namespace NetworkSecurity
{
    public partial class MainForm : Form
    {
        public string Key => txtKey.Text ?? "default key";
        
        public EnumCryptographyAlgorithms SelectedCryptographyAlgorithm  //eli
        {
            get
            {
                Enum.TryParse(cmbCryptoTypes.SelectedItem.ToString(), true, out EnumCryptographyAlgorithms algorithm);
                return algorithm;
            }
        }


        //eli
        public FileInfo EncryptedFileInfo => new FileInfo(lblBrowseEncryptedBinaryFile.Text);
        public FileInfo DecryptedFileInfo => new FileInfo(lblBrowseDecryptedBinaryFile.Text);

        public MainForm()
        {
            InitializeComponent();

            //
            // Declare events for UI controls
            //
            txtDecryptedText.TextChanged += (sender, args) => rbtnSelectTextType.Checked = true;
            txtEncryptedText.TextChanged += (sender, args) => rbtnSelectTextType.Checked = true;
            lblBrowseDecryptedBinaryFile.TextChanged += (sender, args) => rbtnSelectBinaryType.Checked = true;
            lblBrowseEncryptedBinaryFile.TextChanged += (sender, args) => rbtnSelectBinaryType.Checked = true;

            btnBrowseDecryptedBinaryFile.Click += BtnBrowseBinaryFile_Click;
            btnBrowseEncryptedBinaryFile.Click += BtnBrowseBinaryFile_Click;

            btnDecrypt.Click += BtnDecrypt_Click;
            btnEncrypt.Click += BtnEncrypt_Click;
        }


        private void BtnBrowseBinaryFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = @"Binary files (*.exe;*.dll;*.bat)|*.exe;*.dll;*.bat|All files (*.*)|*.*",
                Title = @"Open binary file"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (((Control)sender).Name.Replace("btn", "lbl") == nameof(lblBrowseDecryptedBinaryFile))
                    lblBrowseDecryptedBinaryFile.Text = ofd.FileName;
                else
                    lblBrowseEncryptedBinaryFile.Text = ofd.FileName;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = splitContainer.Size.Width / 2 - 2;   //eli
            foreach (EnumCryptographyAlgorithms al in Enum.GetValues(typeof(EnumCryptographyAlgorithms)))
            {
                cmbCryptoTypes.Items.Add(al.ToString());   //eli
            }

            cmbCryptoTypes.SelectedIndex = 0;
        }


        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();

            try
            {
                if (rbtnSelectTextType.Checked) // Text Encryption
                {
                    txtEncryptedText.Text = txtDecryptedText.Text.Encrypt(Key, SelectedCryptographyAlgorithm);
                    timer.Stop();
                }
                else
                {
                    var deFile = DecryptedFileInfo;
                    if (deFile.Exists && !string.IsNullOrEmpty(deFile.DirectoryName)) // Binary Encryption
                    {
                        var decryptedBytes = File.ReadAllBytes(deFile.FullName);
                        var encryptedBytes = decryptedBytes.Encrypt(Key, SelectedCryptographyAlgorithm);
                        var encryptedFile = Path.Combine(deFile.DirectoryName, deFile.Name + ".encrypted");
                        File.WriteAllBytes(encryptedFile, encryptedBytes);
                        lblBrowseEncryptedBinaryFile.Text = encryptedFile;
                        timer.Stop();
                        MessageBox.Show($@"The encrypted file stored in: {encryptedFile}");
                    }
                }
            }
            catch (Exception exp)
            {
                timer.Stop();
                MessageBox.Show(exp.Message, @"Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  //eli
            }
            finally
            {
                lblEncryptDuration.Text = $@"Encrypt Duration: {timer.ElapsedMilliseconds}ms"; //eli
            }

        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();
            var decryptionAlgorithm = SelectedCryptographyAlgorithm;
            if (decryptionAlgorithm.GetCryptoServiceProvider() is HashAlgorithm)
            {
                MessageBox.Show(@"Can not decrypt hashed contents!!!", @"Decryption Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (rbtnSelectTextType.Checked) // Text Decryption
                {
                    txtDecryptedText.Text = txtEncryptedText.Text.Decrypt(Key, SelectedCryptographyAlgorithm);
                    timer.Stop();
                }
                else
                {
                    var enFile = EncryptedFileInfo;
                    if (enFile.Exists && !string.IsNullOrEmpty(enFile.DirectoryName)) // Binary Decryption   //eli:DirectoryName
                    {
                        var encryptedBytes = File.ReadAllBytes(enFile.FullName);
                        var decryptedBytes = encryptedBytes.Decrypt(Key, SelectedCryptographyAlgorithm);
                        var decryptedFile = Path.Combine(enFile.DirectoryName, enFile.Name.Replace(".encrypted", ""));
                        File.WriteAllBytes(decryptedFile, decryptedBytes);
                        lblBrowseDecryptedBinaryFile.Text = decryptedFile;
                        timer.Stop();
                        MessageBox.Show($@"The decrypted file stored in: {decryptedFile}");
                    }
                }
            }
            catch (Exception exp)
            {
                timer.Stop();
                MessageBox.Show(exp.Message, @"Decryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblDecryptDuration.Text = $@"Decrypt Duration: {timer.ElapsedMilliseconds}ms";
            }
        }
    }


}
