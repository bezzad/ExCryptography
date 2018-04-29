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
        public string GetKey()
        {
            return string.IsNullOrWhiteSpace(txtKey.Text) ? "default_key" : txtKey.Text;
        }

        public EnumCryptographyAlgorithms GetSelectedAlgorithm()
        {
            return (EnumCryptographyAlgorithms)cmbCryptoTypes.SelectedItem;            
        }


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
                Filter = @"Binary files (*.exe;*.dll;*.bat;*.encrypted)|*.exe;*.dll;*.bat;*.encrypted|All files (*.*)|*.*",
                Title = @"Open binary file"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (((Control)sender).Name.Replace("btn", "lbl") == nameof(lblBrowseDecryptedBinaryFile))
                    lblBrowseDecryptedBinaryFile.Text = ofd.FileName;
                else
                    lblBrowseEncryptedBinaryFile.Text = ofd.FileName;

                rbtnSelectBinaryType.Checked = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // fill algorithm combo box on main form
            foreach (EnumCryptographyAlgorithms al in Enum.GetValues(typeof(EnumCryptographyAlgorithms)))
            {
                cmbCryptoTypes.Items.Add(al);   
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
                    txtEncryptedText.Text = txtDecryptedText.Text.Encrypt(GetKey(), GetSelectedAlgorithm());
                    timer.Stop();
                }
                else // is binary 
                {
                    var deFile = DecryptedFileInfo;
                    if (deFile.Exists) // Binary Encryption
                    {
                        var decryptedBytes = File.ReadAllBytes(deFile.FullName);
                        var encryptedBytes = decryptedBytes.Encrypt(GetKey(), GetSelectedAlgorithm());
                        var encryptedFilePath = Path.Combine(deFile.DirectoryName, deFile.Name + ".encrypted");
                        File.WriteAllBytes(encryptedFilePath, encryptedBytes);
                        lblBrowseEncryptedBinaryFile.Text = encryptedFilePath;
                        timer.Stop();
                        MessageBox.Show($@"The encrypted file stored in: {encryptedFilePath}");
                    }
                }
            }
            catch (Exception exp)
            {
                timer.Stop();
                MessageBox.Show(exp.Message, @"Encryption Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            finally
            {
                lblEncryptDuration.Text = $@"Encrypt Duration: {timer.ElapsedMilliseconds}ms"; 
            }

        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            var timer = Stopwatch.StartNew();
            var decryptionAlgorithm = GetSelectedAlgorithm();
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
                    txtDecryptedText.Text = txtEncryptedText.Text.Decrypt(GetKey(), GetSelectedAlgorithm());
                    timer.Stop();
                }
                else
                {
                    var encFile = EncryptedFileInfo;
                    if (encFile.Exists) // Binary Decryption
                    {
                        var encryptedBytes = File.ReadAllBytes(encFile.FullName);
                        var decryptedBytes = encryptedBytes.Decrypt(GetKey(), GetSelectedAlgorithm());
                        var decryptedFilePath = Path.Combine(encFile.DirectoryName, encFile.Name.Replace(".encrypted", ""));
                        File.WriteAllBytes(decryptedFilePath, decryptedBytes);
                        lblBrowseDecryptedBinaryFile.Text = decryptedFilePath;
                        timer.Stop();
                        MessageBox.Show($@"The decrypted file stored in: {decryptedFilePath}");
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
