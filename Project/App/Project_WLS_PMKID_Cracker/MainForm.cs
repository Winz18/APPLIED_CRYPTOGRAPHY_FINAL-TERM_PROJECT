using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_WLS_PMKID_Cracker
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtHelp.Text = "\n1. Open Wireshark and start capturing packets.\n" +
                "2. Filter packets by typing 'eapol' in the filter box.\n" +
                "3. Find the packet with the PMKID hash.\n" +
                "4. Right click on the packet and select 'Copy' -> 'Bytes' -> 'Hex Stream'.\n" +
                "5. Paste the copied hex stream into the 'PMKID' text box.\n" +
                "6. Enter the SSID, BSSID, Client MAC and Wordlist path.\n" +
                "7. Click 'Crack' to start the cracking process.\n" +
                "8. The program will stop when the password is found or the process is cancelled.\n\n" +
                "This app is created by $eCui_WinZ from HCMUTE ISC with <3";
        }

        private void btnCrack_Click(object sender, EventArgs e)
        {
            try
            {
                string ssid = txtSSID.Text;
                string bssid = txtBSSID.Text.Replace(":", "");
                string clientMac = txtClientMAC.Text.Replace(":", "");
                string pmkid = txtPMKID.Text;
                string wordlistPath = txtWordlistPath.Text;

                int threads = 5;

                byte[] bssidBytes = StringToByteArray(bssid);
                byte[] clientMacBytes = StringToByteArray(clientMac);
                byte[] pmkidBytes = StringToByteArray(pmkid);

                cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;

                Task.Run(() => FindPassword(ssid, bssidBytes, clientMacBytes, pmkidBytes, wordlistPath,
                    threads, cancellationToken));
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error occurred: {exception.Message}");
            }
        }

        private async Task FindPassword(string ssid, byte[] bssid, byte[] clientMac, byte[] pmkid, string wordlistPath, int threads, CancellationToken cancellationToken)
        {
            try
            {
                using (StreamReader reader = new StreamReader(wordlistPath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;

                        string password = line.Trim();
                        byte[] pmk = PBKDF2(password, ssid, 4096, 32);
                        byte[] calculatedPmkid = CalculatePmkid(pmk, bssid, clientMac);

                        if (ByteArrayCompare(calculatedPmkid, pmkid))
                        {
                            MessageBox.Show($"CRACKED WPA2 KEY: {password}");
                            cancellationTokenSource.Cancel();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}");
            }
        }

        private byte[] PBKDF2(string password, string ssid, int iterations, int outputBytes)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(ssid), iterations))
            {
                return deriveBytes.GetBytes(outputBytes);
            }
        }

        private byte[] CalculatePmkid(byte[] pmk, byte[] bssid, byte[] clientMac)
        {
            using (HMACSHA1 hmac = new HMACSHA1(pmk))
            {
                byte[] pmkid = hmac.ComputeHash(Encoding.UTF8.GetBytes("PMK Name").Concat(bssid).Concat(clientMac).ToArray());
                return pmkid;
            }
        }

        private bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }
            return true;
        }

        private byte[] StringToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
